using System;

namespace StorageMaster
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            switch (type)
            {
                case "Van":
                    return new Van();
                case "Truck":
                    return new Truck();
                case "Semi":
                    return new Semi();
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }

            //The same made with Reflection:
            //Type vehicleType = this.GetType().Assembly.GetTypes()
            //    .FirstOrDefault(t => typeof(Vehicle).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);
            //if (vehicleType == null)
            //{
            //    throw new InvalidOperationException("Invalid vehicle type!");
            //}

            //try
            //{
            //    Vehicle vehicle = (Vehicle)Activator.CreateInstance(vehicleType);

            //    return vehicle;
            //}
            //catch (TargetInvocationException tie)
            //{
            //    throw tie.InnerException;
            //}
        }
    }
}