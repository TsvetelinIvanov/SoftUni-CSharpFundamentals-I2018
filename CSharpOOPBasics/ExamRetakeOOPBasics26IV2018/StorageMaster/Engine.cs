using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly StorageMaster storageMaster;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string input;
            while ((input = this.reader.ReadLine()) != "END")
            {
                try
                {
                    string output = this.ProcessInput(input);
                    this.writer.WriteLine(output);
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine("Error: " + ioe.Message);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }

            this.writer.WriteLine(this.storageMaster.GetSummary());
        }

        private string ProcessInput(string input)
        {
            string[] commandArgs = input.Split();
            string command = commandArgs[0];

            string output = string.Empty;
            switch (command)
            {
                case "AddProduct":
                    string productType = commandArgs[1];
                    double price = double.Parse(commandArgs[2]);
                    output = this.storageMaster.AddProduct(productType, price);
                    break;
                case "RegisterStorage":
                    string storageType = commandArgs[1];
                    string name = commandArgs[2];
                    output = this.storageMaster.RegisterStorage(storageType, name);
                    break;
                case "SelectVehicle":
                    string storageName = commandArgs[1];
                    int garageSlot = int.Parse(commandArgs[2]);
                    output = this.storageMaster.SelectVehicle(storageName, garageSlot);
                    break;
                case "LoadVehicle":
                    IEnumerable<string> productNames = commandArgs.Skip(1);
                    output = this.storageMaster.LoadVehicle(productNames);
                    break;
                case "SendVehicleTo":
                    string sourceName = commandArgs[1];
                    int sourceGarageSlot = int.Parse(commandArgs[2]);
                    string destinationName = commandArgs[3];
                    output = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                    break;
                case "UnloadVehicle":
                    storageName = commandArgs[1];
                    garageSlot = int.Parse(commandArgs[2]);
                    output = this.storageMaster.UnloadVehicle(storageName, garageSlot);
                    break;
                case "GetStorageStatus":
                    storageName = commandArgs[1];
                    output = this.storageMaster.GetStorageStatus(storageName);
                    break;
                default:
                    throw new ArgumentException("INVALID COMMAND");
            }

           return output;
        }
    }
}