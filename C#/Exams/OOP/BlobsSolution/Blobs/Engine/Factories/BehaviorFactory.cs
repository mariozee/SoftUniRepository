namespace Blobs.Engine.Factories
{
    using Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class BehaviorFactory : IBehaviorFactory
    {
        public IBehavior CreateBehavior(string behaviorType)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == behaviorType);
            IBehavior behavior = (IBehavior)Activator.CreateInstance(type);

            return behavior;
        }
    }
}
