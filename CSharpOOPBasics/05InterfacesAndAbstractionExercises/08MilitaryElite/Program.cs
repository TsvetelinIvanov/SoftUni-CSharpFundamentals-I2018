using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Soldier> soldiers = GetSoldiers();
        foreach (Soldier soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }

    private static List<Soldier> GetSoldiers()
    {
        List<Soldier> soldiers = new List<Soldier>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] soldierData = input.Split();
            string soldierType = soldierData[0];
            string id = soldierData[1];
            string firstName = soldierData[2];
            string lastName = soldierData[3];
            
            switch (soldierType)
            {
                case "Spy":
                    int codeNumber = int.Parse(soldierData[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                    break;
                case "Private":
                    decimal privateSalary = decimal.Parse(soldierData[4]);
                    Private @private = new Private(id, firstName, lastName, privateSalary);
                    soldiers.Add(@private);
                    break;
                case "LeutenantGeneral":
                    decimal lieutenantGeneralSalary = decimal.Parse(soldierData[4]);
                    LeutenantGeneral lieutenantGeneral = new LeutenantGeneral(id, firstName, lastName, lieutenantGeneralSalary);
                    for (int i = 5; i < soldierData.Length; i++)
                    {
                        string soldierId = soldierData[i];
                        List<Private> privateSoldiers = new List<Private>();
                        foreach (Soldier soldier in soldiers)
                        {
                            if (soldier is Private)
                            {
                                privateSoldiers.Add((Private)soldier);
                            }
                        }

                        Private private1 = privateSoldiers.Single(s => s.Id == soldierId);
                        lieutenantGeneral.Privates.Add(private1);
                    }

                    soldiers.Add(lieutenantGeneral);
                    break;
                case "Engineer":
                    try
                    {
                        decimal engineerSalary = decimal.Parse(soldierData[4]);
                        string engineerCorps = soldierData[5];
                        Engineer engineer = new Engineer(id, firstName, lastName, engineerSalary, engineerCorps);
                        for (int i = 6; i < soldierData.Length; i += 2)
                        {
                            string repairPart = soldierData[i];
                            int repairHours = int.Parse(soldierData[i + 1]);
                            Repair repair = new Repair(repairPart, repairHours);
                            engineer.Repairs.Add(repair);
                        }

                        soldiers.Add(engineer);
                    }
                    catch (ArgumentException)
                    {
                        
                    }
                    break;
                case "Commando":
                    try
                    {
                        decimal commandoSalary = decimal.Parse(soldierData[4]);
                        string commandoCorps = soldierData[5];
                        Commando commando = new Commando(id, firstName, lastName, commandoSalary, commandoCorps);
                        for (int i = 6; i < soldierData.Length; i += 2)
                        {
                            try
                            {
                                string codeName = soldierData[i];
                                string state = soldierData[i + 1];
                                Mission mission = new Mission(codeName, state);
                                commando.Missions.Add(mission);
                            }
                            catch (ArgumentException)
                            {
                                
                            }
                        }

                        soldiers.Add(commando);
                    }
                    catch (ArgumentException)
                    {
                        
                    }

                    break;
            }
        }

        return soldiers;
    }
}
