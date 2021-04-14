using System;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) : base(name, 100, 50, 40, new Satchel(), faction)
        {
            this.Name = name;
            this.Faction = faction;
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Equals(character))
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction.Equals(character.Faction))
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}