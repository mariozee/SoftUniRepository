namespace LearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;
    using Infrastructure;
    using Data;
    using Models;

    public class BangaloreUniversityEngine : IEngine
    {
        public void Run()
        {
            var dataBase = new BangaloreUniversityDate();
            User user = null;

            while (true)
            {
                string url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }

                var route = new Route(url);
                var controllerType = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControlerName);
                var controller = Activator.CreateInstance(controllerType, dataBase, user) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, @params) as Interfaces.View;
                    Console.WriteLine(view.Display());
                    user = controller.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(p =>
            {
                if (p.ParameterType == typeof(int))
                {
                    return int.Parse(route.Parameters[p.Name]);
                }

                else
                {
                    return route.Parameters[p.Name];
                }
            })
            .ToArray();                
        }
    }
}
