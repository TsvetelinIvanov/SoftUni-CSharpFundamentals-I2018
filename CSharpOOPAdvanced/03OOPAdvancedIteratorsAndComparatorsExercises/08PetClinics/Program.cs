using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Pet> pets = new List<Pet>();
        List<PetClinic> petClinics = new List<PetClinic>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] commandArgs = Console.ReadLine().Split();
            string command = commandArgs[0];
            switch (command)
            {
                case "Create":
                    string objectToCreation = commandArgs[1];
                    if (objectToCreation == "Pet")
                    {
                        string name = commandArgs[2];
                        int age = int.Parse(commandArgs[3]);
                        string kind = commandArgs[4];
                        
                        Pet pet = new Pet(name, age, kind);
                        pets.Add(pet);
                    }
                    else if (objectToCreation == "Clinic")
                    {
                        try
                        {
                            string name = commandArgs[2];
                            int roomsCount = int.Parse(commandArgs[3]);
                            
                            PetClinic petClinic = new PetClinic(name, roomsCount);
                            petClinics.Add(petClinic);
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                    }

                    break;
                case "Add":
                    string petName = commandArgs[1];
                    string clinicName = commandArgs[2];
                    Pet petToAdding = pets.FirstOrDefault(p => p.Name == petName);
                    PetClinic petClinicToAddPet = petClinics.FirstOrDefault(c => c.Name == clinicName);
                    Console.WriteLine(petClinicToAddPet.Add(petToAdding)); 
                    break;
                case "Release":
                    clinicName = commandArgs[1];
                    PetClinic petClinicToRelease = petClinics.FirstOrDefault(c => c.Name == clinicName);
                    Console.WriteLine(petClinicToRelease.Release());
                    break;
                case "HasEmptyRooms":
                    clinicName = commandArgs[1];
                    PetClinic petClinicToCheckForEmptyRooms = petClinics.FirstOrDefault(c => c.Name == clinicName);
                    Console.WriteLine(petClinicToCheckForEmptyRooms.HasEmptyRoom);
                    break;
                case "Print": 
                    if (commandArgs.Length == 3)
                    {
                        clinicName = commandArgs[1];
                        int roomNumber = int.Parse(commandArgs[2]);
                        PetClinic petClinicToPrint = petClinics.FirstOrDefault(c => c.Name == clinicName);
                        Console.WriteLine(petClinicToPrint.Print(roomNumber));
                    }
                    else if (commandArgs.Length == 2)
                    {
                        clinicName = commandArgs[1];                        
                        PetClinic petClinicToPrint = petClinics.FirstOrDefault(c => c.Name == clinicName);
                        Console.WriteLine(petClinicToPrint.Print());
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }
        }
    }
}
