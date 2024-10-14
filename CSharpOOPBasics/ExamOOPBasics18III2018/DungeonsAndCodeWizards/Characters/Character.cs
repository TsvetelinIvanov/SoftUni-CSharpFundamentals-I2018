using System;

namespace DungeonsAndCodeWizards
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth
        {
            get { return this.baseHealth; }
            private set { this.baseHealth = value; }
        }

        public double Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }

                this.health = value;
                //this.health = Math.Min(value, this.BaseHealth);
            }
        }

        public double BaseArmor
        {
            get { return this.baseArmor; }
            private set { this.baseArmor = value; }
        }

        public double Armor
        {
            get { return this.armor; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > this.BaseArmor)
                {
                    value = this.BaseArmor;
                }

                this.armor = value;
                //this.armor = Math.Min(value, this.BaseArmor);
            }
        }

        public double AbilityPoints
        {
            get { return this.abilityPoints; }
            private set { this.abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return this.bag; }
            private set { this.bag = value; }
        }

        public Faction Faction
        {
            get { return this.faction; }
            protected set
            {
                this.faction = value;
            }
        }

        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

        public virtual double RestHealMultiplier
        {
            get { return 0.2; }

        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            //if (!this.IsAlive)
            //{
            //    throw new InvalidOperationException("Must be alive to perform this action!");
            //}

            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health -= hitPoints;
                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void Rest()
        {
            this.EnsureAlive();
            //if (!this.IsAlive)
            //{
            //    throw new InvalidOperationException("Must be alive to perform this action!");
            //}

            //this.Health = Math.Min(this.Health + this.BaseHealth * RestHealMultiplier, this.BaseHealth);
            this.Health += this.baseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            //if (!this.IsAlive)
            //{
            //    throw new InvalidOperationException("Must be alive to perform this action!");
            //}

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.EnsureAlive();
            //if (!this.IsAlive || !character.IsAlive)
            //{
            //    throw new InvalidOperationException("Must be alive to perform this action!");
            //}

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.EnsureAlive();
            //if (!this.IsAlive || !character.IsAlive)
            //{
            //    throw new InvalidOperationException("Must be alive to perform this action!");
            //}

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        private void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {this.TakeStatus()}";
        }

        private string TakeStatus()
        {
            return this.IsAlive ? "Alive" : "Dead";
        }
    }
}
