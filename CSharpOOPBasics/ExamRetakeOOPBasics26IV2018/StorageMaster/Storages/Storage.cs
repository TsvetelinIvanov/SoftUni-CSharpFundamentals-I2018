using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster
{
    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlotsCount;
        private readonly Vehicle[] garage;
        private readonly List<Product> products;

        protected Storage(string name, int capacity, int garageSlotsCount, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlotsCount = garageSlotsCount;
            this.garage = new Vehicle[garageSlotsCount];
            this.products = new List<Product>();

            this.InitializeGarage(vehicles);
        }

        public int GarageSlotsCount
        {
            get { return this.garageSlotsCount; }
            private set { this.garageSlotsCount = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public IReadOnlyCollection<Vehicle> Garage
        {
            get { return Array.AsReadOnly(this.garage); }
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return this.products.AsReadOnly(); }
        }

        bool IsFull => this.Products.Sum(p => p.Weight) >= this.Capacity;

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            int vehiclesCount = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                this.garage[vehiclesCount++] = vehicle;
            }
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.garage.Length)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            //It is't in instructions:
            if (garageSlot < 0)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            Vehicle vehicle = this.garage[garageSlot];
            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);
            bool isFreeGarageSlot = deliveryLocation.Garage.Any(v => v == null);
            if (!isFreeGarageSlot)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;

            //int garageSlotDeliveryLocationVehicle = deliveryLocation.AddVehicle(vehicle);
            int garageSlotDeliveryLocationVehicle = Array.IndexOf(deliveryLocation.garage, null);
            deliveryLocation.garage[garageSlotDeliveryLocationVehicle] = vehicle;

            return garageSlotDeliveryLocationVehicle;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);
            int unloudedProductsCount = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                Product product = vehicle.Unload();
                this.products.Add(product);
                unloudedProductsCount++;
            }

            return unloudedProductsCount;
        }

        //private int AddVehicle(Vehicle vehicle)
        //{
        //    int freeGarageSlotIndex = Array.IndexOf(this.garage, null);
        //    this.garage[freeGarageSlotIndex] = vehicle;

        //    return freeGarageSlotIndex;
        //}
    }
}