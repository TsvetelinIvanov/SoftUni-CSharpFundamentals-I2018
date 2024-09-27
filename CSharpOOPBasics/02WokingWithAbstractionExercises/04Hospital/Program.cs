using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<string, List<string>> doktors = new Dictionary<string, List<string>>();
        Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

        string patientInfoInput = Console.ReadLine();
        while (patientInfoInput != "Output")
        {
            string[] patientInfo = patientInfoInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string departament = patientInfo[0];
            string doctorFirstName = patientInfo[1];
            string doctorSecondName = patientInfo[2];
            string pacient = patientInfo[3];
            
            string doctorFullName = doctorFirstName + " " + doctorSecondName;
            if (!doktors.ContainsKey(doctorFullName))
            {
                doktors[doctorFullName] = new List<string>();
            }

            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }

            bool isPlaceFree = departments[departament].SelectMany(x => x).Count() < 60;
            if (isPlaceFree)
            {
                int roomNumber = 0;
                doktors[doctorFullName].Add(pacient);
                for (int room = 0; room < departments[departament].Count; room++)
                {
                    if (departments[departament][room].Count < 3)
                    {
                        roomNumber = room;
                        break;
                    }
                }

                departments[departament][roomNumber].Add(pacient);
            }

            patientInfoInput = Console.ReadLine();
        }

        string commandInput = Console.ReadLine().Trim();
        while (commandInput != "End")
        {
            string[] command = commandInput.Split();
            if (command.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[command[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (command.Length == 2 && int.TryParse(command[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departments[command[0]][room - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doktors[command[0] + " " + command[1]].OrderBy(x => x)));
            }

            commandInput = Console.ReadLine().Trim();
        }
    }
}
