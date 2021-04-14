using System;

namespace StorageMaster
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(name);
                case "DistributionCenter":
                    return new DistributionCenter(name);
                case "Warehouse":
                    return new Warehouse(name);
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }

            //The same made with Reflection:
            //Type storageType = this.GetType().Assembly.GetTypes()
            //    .FirstOrDefault(t => typeof(Storage).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);
            //if (storageType == null)
            //{
            //    throw new InvalidOperationException("Invalid storage type!");
            //}

            //try
            //{
            //    Storage storage = (Storage)Activator.CreateInstance(storageType, name);

            //    return storage;
            //}
            //catch (TargetInvocationException tie)
            //{
            //    throw tie.InnerException;
            //}
        }
    }
}