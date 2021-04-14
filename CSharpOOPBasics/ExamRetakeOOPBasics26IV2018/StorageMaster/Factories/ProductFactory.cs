using System;

namespace StorageMaster
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)        
        {
            switch (type)
            {
                case "Gpu":
                    return new Gpu(price);
                case "HardDrive":
                    return new HardDrive(price);
                case "Ram":
                    return new Ram(price);
                case "SolidStateDrive":
                    return new SolidStateDrive(price);
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }

            //The same made with Reflection:
            //Type productType = this.GetType().Assembly.GetTypes()
            //    .FirstOrDefault(t => typeof(Product).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);
            //if (productType == null)
            //{
            //    throw new InvalidOperationException("Invalid product type!");
            //}

            //try
            //{
            //    Product product = (Product)Activator.CreateInstance(productType, price);

            //    return product;
            //}
            //catch(TargetInvocationException tie)
            //{
            //    throw tie.InnerException;
            //}
        }
    }
}