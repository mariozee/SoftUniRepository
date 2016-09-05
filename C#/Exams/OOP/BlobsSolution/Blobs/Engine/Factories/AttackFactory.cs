namespace Blobs.Engine.Factories
{
    using Interfaces;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AttackFactory : IAttackFactory
    {
        public IAttack CreateAttack(string attackType)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == attackType);
            IAttack attack = (IAttack)Activator.CreateInstance(type);

            return attack;
        }
    }
}
