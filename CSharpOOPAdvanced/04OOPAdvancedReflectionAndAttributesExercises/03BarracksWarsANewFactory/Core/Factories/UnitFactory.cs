using System;
using System.Linq;
using System.Reflection;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitTypeString)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type unitType = assembly.GetTypes().FirstOrDefault(t => t.Name == unitTypeString);
            if (unitType == null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }

            //if (!unitType.GetInterfaces().Any(i => i == typeof(IUnit)))
            if (!typeof(IUnit).IsAssignableFrom(unitType))
            {
                throw new ArgumentException($"{unitTypeString} is not an Unit Type!");
            }

            IUnit unit = (IUnit)Activator.CreateInstance(unitType);

            return unit;
        }
    }
}
