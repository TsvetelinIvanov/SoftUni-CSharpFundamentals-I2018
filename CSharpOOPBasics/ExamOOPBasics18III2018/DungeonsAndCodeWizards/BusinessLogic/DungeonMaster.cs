using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.BusinessLogic
{
    public class DungeonMaster
    {
        private List<Character> characters;
        //private List<Character> cSharpCharacters;
        //private List<Character> javaCharacters;
        private Stack<Item> items;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private int lastSurvivorRoundsCount;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            //this.cSharpCharacters = new List<Character>();
            //this.javaCharacters = new List<Character>();
            this.items = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            string factionString = args[0];
            string type = args[1];
            string name = args[2];
            Character character = characterFactory.CreateCharacter(factionString, type, name);
            //if (character.Faction == Faction.CSharp)
            //{
            //    this.cSharpCharacters.Add(character);
            //}
            //else if (character.Faction == Faction.Java)
            //{
            //    this.javaCharacters.Add(character);
            //}

            this.characters.Add(character);

            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = this.itemFactory.CreateItem(itemName);
            this.items.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = FindCharacter(characterName);
            //Character character = this.characters.FirstOrDefault(ch => ch.Name == characterName);
            //Character character = this.cSharpCharacters.FirstOrDefault(ch => ch.Name == characterName) ??
            //    this.javaCharacters.FirstOrDefault(ch => ch.Name == characterName);
            //if (character == null)
            //{
            //    throw new ArgumentException($"Character {characterName} not found!");
            //}

            if (items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = items.Pop();
            character.ReceiveItem(item);

            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.FindCharacter(characterName);
            //Character character = this.cSharpCharacters.FirstOrDefault(ch => ch.Name == characterName) ??
            //    this.javaCharacters.FirstOrDefault(ch => ch.Name == characterName);
            //if (character == null)
            //{
            //    throw new ArgumentException($"Character {characterName} not found!");
            //}

            string itemName = args[1];
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {item.GetType().Name}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.FindCharacter(giverName);
            //Character giver = this.cSharpCharacters.FirstOrDefault(ch => ch.Name == giverName) ??
            //    this.javaCharacters.FirstOrDefault(ch => ch.Name == giverName);
            //if (giver == null)
            //{
            //    throw new ArgumentException($"Giver {giverName} not found!");
            //}

            Character receiver = this.FindCharacter(receiverName);
            //Character receiver = this.cSharpCharacters.FirstOrDefault(ch => ch.Name == receiverName) ??
            //    this.javaCharacters.FirstOrDefault(ch => ch.Name == receiverName);
            //if (receiver == null)
            //{
            //    throw new ArgumentException($"Receiver {receiverName} not found!");
            //}

            Item item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            return $"{giver.Name} used {item.GetType().Name} on {receiver.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.FindCharacter(giverName);
            //Character giver = this.cSharpCharacters.FirstOrDefault(ch => ch.Name == giverName) ??
            //    this.javaCharacters.FirstOrDefault(ch => ch.Name == giverName);
            //if (giver == null)
            //{
            //    throw new ArgumentException($"Character {giverName} not found!");
            //    //throw new ArgumentException($"Giver {giverName} not found!");
            //}

            Character receiver = this.FindCharacter(receiverName);
            //Character receiver = this.cSharpCharacters.FirstOrDefault(ch => ch.Name == receiverName) ??
            //    this.javaCharacters.FirstOrDefault(ch => ch.Name == receiverName);
            //if (receiver == null)
            //{
            //    throw new ArgumentException($"Character {receiverName} not found!");
            //}

            Item item = giver.Bag.GetItem(itemName);
            giver.GiveCharacterItem(item, receiver);

            return $"{giver.Name} gave {receiver.Name} {item.GetType().Name}.";
        }

        //public string GetStats()
        //{
        //    IOrderedEnumerable<Character> sortedCharacters = this.characters.OrderByDescending(a => a.IsAlive).ThenByDescending(a => a.Health);
        //    string result = string.Join(Environment.NewLine, sortedCharacters);

        //    return result;
        //}
        public string GetStats()
        {
            //List<Character> characters = cSharpCharacters.Concat(javaCharacters).ToList();
            //List<Character> aliveCharacters = characters.Where(ch => ch.IsAlive).OrderByDescending(ch => ch.Health).ToList();
            //List<Character> deadCharacters = characters.Where(ch => !ch.IsAlive).OrderByDescending(ch => ch.Health).ToList();
            List<Character> aliveCharacters = this.characters.Where(ch => ch.IsAlive).OrderByDescending(ch => ch.Health).ToList();
            List<Character> deadCharacters = this.characters.Where(ch => !ch.IsAlive).OrderByDescending(ch => ch.Health).ToList();
            List<Character> orderedCharacters = aliveCharacters.Concat(deadCharacters).ToList();

            StringBuilder getStatsBuilder = new StringBuilder();
            foreach (Character character in orderedCharacters)
            {
                getStatsBuilder.AppendLine(character.ToString());
            }

            return getStatsBuilder.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.FindCharacter(attackerName);
            //Character attacker = this.cSharpCharacters.FirstOrDefault(ch => ch.Name == attackerName) ??
            //    this.javaCharacters.FirstOrDefault(ch => ch.Name == attackerName);
            //if (attacker == null)
            //{
            //    throw new ArgumentException($"Character {attackerName} not found!");
            //    //throw new ArgumentException($"Attacker {attackerName} not found!");
            //}

            Character receiver = this.FindCharacter(receiverName);
            //Character receiver = this.cSharpCharacters.FirstOrDefault(ch => ch.Name == receiverName) ??
            //   this.javaCharacters.FirstOrDefault(ch => ch.Name == receiverName);
            //if (receiver == null)
            //{
            //    throw new ArgumentException($"Character {receiverName} not found!");
            //}

            if (!(attacker is Warrior))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            Warrior attackerWarrior = (Warrior)attacker;
            //if (!(attacker is IAttackable attackerWarrior))
            //{
            //    throw new ArgumentException($"{attacker.Name} cannot attack!");
            //}

            attackerWarrior.Attack(receiver);

            StringBuilder attackBuilder = new StringBuilder();
            attackBuilder.Append($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has " +
                $"{receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive)
            {
                attackBuilder.Append($"{Environment.NewLine}{receiver.Name} is dead!");
            }

            return attackBuilder.ToString();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = this.FindCharacter(healerName);
            //Character healer = this.cSharpCharacters.FirstOrDefault(ch => ch.Name == healerName) ??
            //    this.javaCharacters.FirstOrDefault(ch => ch.Name == healerName);
            //if (healer == null)
            //{
            //    throw new ArgumentException($"Character {healerName} not found!");
            //    //throw new ArgumentException($"Healer {healerName} not found!");
            //}

            Character receiver = this.FindCharacter(receiverName);
            //Character receiver = this.cSharpCharacters.FirstOrDefault(ch => ch.Name == receiverName) ??
            //   this.javaCharacters.FirstOrDefault(ch => ch.Name == receiverName);
            //if (receiver == null)
            //{
            //    throw new ArgumentException($"Character {receiverName} not found!");
            //}

            if (!(healer is Cleric))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            Cleric healerCleric = (Cleric)healer;
            //if (!(healer is IHealable healerCleric))
            //{
            //    throw new ArgumentException($"{healer.Name} cannot heal!");
            //}

            healerCleric.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

        }

        //public string EndTurn()
        public string EndTurn(string[] args)
        {
            //List<Character> characters = this.cSharpCharacters.Concat(this.javaCharacters).ToList();            
            //List<Character> aliveCharacters = characters.Where(ch => ch.IsAlive).OrderByDescending(ch => ch.Health).ToList();
            List<Character> aliveCharacters = this.characters.Where(ch => ch.IsAlive).ToList();
            StringBuilder endTurnBuilder = new StringBuilder();
            foreach (Character character in aliveCharacters)
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                endTurnBuilder.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (aliveCharacters.Count <= 1)
            {
                this.lastSurvivorRoundsCount++;
            }

            return endTurnBuilder.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            //List<Character> characters = this.cSharpCharacters.Concat(this.javaCharacters).ToList();            
            //List<Character> aliveCharacters = characters.Where(ch => ch.IsAlive).OrderByDescending(ch => ch.Health).ToList();
            List<Character> aliveCharacters = this.characters.Where(ch => ch.IsAlive).ToList();
            bool isOneOrZeroSurvivor = aliveCharacters.Count <= 1;
            bool isGameOverRound = this.lastSurvivorRoundsCount > 1;

            return isOneOrZeroSurvivor && isGameOverRound;
        }

        private Character FindCharacter(string name)
        {
            Character character = this.characters.FirstOrDefault(e => e.Name == name);
            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            return character;
        }
    }
}
