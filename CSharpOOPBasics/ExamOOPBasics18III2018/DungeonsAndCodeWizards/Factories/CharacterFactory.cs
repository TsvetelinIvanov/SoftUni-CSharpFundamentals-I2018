using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionString, string type, string name)
        //public Character CreateCharacter(string[] methodArgs)
        {
            //string factionString = methodArgs[0];
            //string type = methodArgs[1];
            //string name = methodArgs[2];

            bool isValidFaction = Enum.TryParse(typeof(Faction), factionString, out object factionObjekt);
            if (!isValidFaction)
            {
                throw new ArgumentException($"Invalid faction \"{factionString}\"!");
            }

            //if (!Enum.TryParse<Faction>(factionString, out var faction))
            //{
            //    throw new ArgumentException($"Invalid faction \"{factionString}\"!");
            //}

            Faction faction = (Faction)factionObjekt;
            
            switch (type)
            {
                case "Warrior":
                    return new Warrior(name, faction);
                case "Cleric":
                    return new Cleric(name, faction);
                default:
                    throw new ArgumentException($"Invalid character type \"{ type }\"!");
            }
        }

        //With reflection:
        //public Character CreateCharacter(string faction, string type, string name)
        //{
        //    if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
        //    {
        //        throw new ArgumentException($"Invalid faction \"{faction}\"!");
        //    }

        //    Type characterType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
        //    if (characterType == null)
        //    {
        //        throw new ArgumentException($"Invalid character type \"{type}\"!");
        //    }

        //    Character character = (Character)Activator.CreateInstance(characterType, name, parsedFaction);

        //    return character;
        //}
    }
}
