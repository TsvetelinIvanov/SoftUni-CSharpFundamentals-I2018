using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> departments = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Output")
            {
                string[] patientData = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string department = patientData[0];
                string doctor = patientData[1] + " " + patientData[2];
                string patient = patientData[3];

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<string>();
                }

                if (departments[department].Count <= 60)
                {
                    departments[department].Add(patient);
                }                    

                if (!doctors.ContainsKey(doctor))
                {
                    doctors.Add(doctor, new List<string>());
                }

                if (departments[department].Count <= 60)
                {
                    doctors[doctor].Add(patient);
                }                    
            }
            
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int room = 0;
                if (commands.Length == 1)
                {
                    foreach (string patient in departments[commands[0]])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else if (int.TryParse(commands[1], out room))
                {
                    int skip = 3 * (room - 1);
                    foreach (string patient in departments[commands[0]].Skip(skip).Take(3).OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    string doctor = commands[0] + " " + commands[1];
                    foreach (string patient in doctors[doctor].OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }
    }
}
