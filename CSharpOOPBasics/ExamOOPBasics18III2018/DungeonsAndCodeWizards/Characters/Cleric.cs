using System;

namespace DungeonsAndCodeWizards
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) : base(name, 50, 25, 40, new Backpack(), faction)
        {
            this.Name = name;
            this.Faction = faction;
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (!this.Faction.Equals(character.Faction))
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            //character.Health = Math.Min(character.BaseHealth, character.Health + this.AbilityPoints);
            character.Health += this.AbilityPoints;
        }
    }
}