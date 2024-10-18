using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
    public class StorageMaster
    {               
        private Vehicle currentVehicle;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private readonly Dictionary<string, Storage> storages;
        private readonly Dictionary<string, Stack<Product>> productsPool;

        public StorageMaster()
        {                        
            this.currentVehicle = null;
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.storages = new Dictionary<string, Storage>();
            this.productsPool = new Dictionary<string, Stack<Product>>();
        }

        public string AddProduct(string type, double price)
        {
            if (!this.productsPool.ContainsKey(type))
            {
                this.productsPool[type] = new Stack<Product>();
            }

            Product product = productFactory.CreateProduct(type, price);
            this.productsPool[type].Push(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storages[storage.Name] = storage;

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages[storageName];
            Vehicle vehicle = storage.GetVehicle(garageSlot);
            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;
            foreach (string productName in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }
                
                if (!this.productsPool.ContainsKey(productName) || !this.productsPool[productName].Any())
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                Product product = this.productsPool[productName].Pop();
                this.currentVehicle.LoadProduct(product);
                loadedProductsCount++;
            }

            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {            
            if (!this.storages.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            Storage sourceStorage = storages[sourceName];
            
            if (!this.storages.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage destinationStorage = storages[destinationName];

            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationStorage.Name} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = storages[storageName];
            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int productsInVehicle = vehicle.Trunk.Count;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = storages[storageName];
            string[] stockInfo = storage.Products.GroupBy(p => p.GetType().Name)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .OrderByDescending(p => p.Count).ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})").ToArray();

            double productsWeight = storage.Products.Sum(p => p.Weight);
            string stockFormat = string.Format("Stock ({0}/{1}): [{2}]", productsWeight, storage.Capacity, string.Join(", ", stockInfo));
            string[] vehicleNames = storage.Garage.Select(v => v?.GetType().Name ?? "empty").ToArray();
            string storageStatus = stockFormat + $"{Environment.NewLine}Garage: [{string.Join("|", vehicleNames)}]";

            return storageStatus;
        }

        public string GetSummary()
        {
            StringBuilder getSummaryBuilder = new StringBuilder();
            foreach (Storage storage in this.storages.Values.OrderByDescending(s => s.Products.Sum(p => p.Price)))
            {
                getSummaryBuilder.AppendLine($"{storage.Name}:{Environment.NewLine}" +
                    $"Storage worth: ${storage.Products.Sum(p => p.Price):F2}");
            }

            return getSummaryBuilder.ToString().TrimEnd();
        }
    }
}
