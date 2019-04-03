using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleSystem.Items;

namespace BattleSystem.Characters
{
    public class Character
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Health { get; private set; }
        public int Mana { get; private set; }
        public int Strength { get; private set; }
        public int Intelligence { get; private set; }
        public int Agility { get; private set; }
        public int Constitution { get; private set; }
        public int Luck { get; private set; }
        public bool IsAlive { get; private set; }
        public List<IItem>Inventory;

        private int MaxHealth { get; set; }
        private int MaxMana { get; set; }
                
        public Character(string name, Dictionary<string, int> stats)
        {
            IsAlive = true;
            Name = name;
            Level = stats["Level"];
            Strength = stats["Strength"];
            Intelligence = stats["Intelligence"];
            Agility = stats["Agility"];
            Constitution = stats["Constitution"];
            Luck = stats["Luck"];
            Inventory = new List<IItem>();

            MaxHealth = SetMaxHealth(Level, Constitution);
            Health = MaxHealth;
            MaxMana = SetMaxMana(Level, Intelligence);
            Mana = MaxMana;
        }

        private int SetMaxHealth(int level, int constitution)
        {
            var MaxAmount = 9999;
            MaxHealth = 200 + (10 * (level * constitution));

            if (MaxHealth >= MaxAmount)
            {
                MaxHealth = MaxAmount;
            }

            return MaxHealth;
        }

        private int SetMaxMana(int level, int intelligence)
        {
            var MaxAmount = 999;
            MaxMana = (level * intelligence) + (2 * intelligence);

            if (MaxMana >= MaxAmount)
            {
                MaxMana = MaxAmount;
            }

            return MaxMana;
        }

        public int ReduceHealth(int amount)
        {
            Health = Health - amount;

            if (Health <= 0)
            {
                IsAlive = false;
                Health = 0;
            }

            return Health;
        }

        public int IncreaseHealth(int amount)
        {
            var availableToHeal = MaxHealth - Health;
            int amountHealed = 0;
            
            if (availableToHeal >= 0)
            {
                if (availableToHeal >= amount)
                {
                    amountHealed = amount;
                }
                else
                {
                    amountHealed = availableToHeal;
                }

                IsAlive = true;
                Health += amountHealed;
            }

            return amountHealed;
        }

        public int TakeDamageMagical(Character attacker)
        {
            int MaxAmount = 9999;
            int attackSeed = ((attacker.Intelligence * 10) + (attacker.Level * attacker.Level));
            int attackAmount;
            
            Random rand = new Random();
            attackAmount = rand.Next(attackSeed - (attackSeed / 10), attackSeed + (attackSeed / 10));

            if (attacker.IsCritical())
                attackAmount = attacker.GetCriticalAttack(attackAmount);

            if (attackAmount > MaxAmount)
                attackAmount = MaxAmount;

            ReduceHealth(attackAmount);

            return attackAmount;
        }

        public int TakeDamagePhysical(Character attacker)
        {
            int MaxAmount = 9999;
            int attackAmount;
            int attackSeed;

            if (attacker.Agility < attacker.Strength)
                attackSeed = ((attacker.Strength * 10) + (attacker.Level * attacker.Level));
            else
                attackSeed = ((attacker.Agility * 10) + (attacker.Level * attacker.Level));

            Random rand = new Random();
            attackAmount = rand.Next(attackSeed - (attackSeed / 20), attackSeed + (attackSeed / 20));

            if (attacker.IsCritical())
                attackAmount = attacker.GetCriticalAttack(attackAmount);

            if (attackAmount > MaxAmount)
                attackAmount = MaxAmount;

            ReduceHealth(attackAmount);

            return attackAmount;
        }

        public void LevelUp()
        {
            Level = ++Level;
            Strength = ++Strength;
            Intelligence = ++Intelligence;
            Agility = ++Agility;
            Constitution = ++Constitution;

            if (Level % 5 == 0)
            {
                Luck = ++Luck;
            }

            MaxHealth = SetMaxHealth(Level, Constitution);
            Health = MaxHealth;
            MaxMana = SetMaxMana(Level, Intelligence);
            Mana = MaxMana;
        }

        public IItem AddItem(IItem newItem)
        {
            Inventory.Add(newItem);

            return newItem;
        }

        public IItem RemoveItem(IItem item)
        {
            Inventory.Remove(item);

            return item;
        }
        
        public int UseItem(Character targetCharacter, IItem item)
        {
            if (item.Quantity > 0)
            {
                var itemValue = item.Use(targetCharacter);

                if (Inventory.Where(i => i.Name == item.Name).Select(i => i.Quantity).Single() <= 0)
                {
                    RemoveItem(item);
                }

                return itemValue;
            }
            else
            {
                Console.WriteLine("No items in inventory!");
                return 0;
            }
        }

        public Character[] UseMultiItem(Character[] targetCharacters, IItem item)
        {
            return item.Use(targetCharacters);
        }
        
        private int GetCriticalAttack(int attackAmount)
        {
            Random rand = new Random();
            int criticalAmount = rand.Next((attackAmount + (attackAmount / 10)), attackAmount + (attackAmount / 5));
            return criticalAmount;
        }
        
        private bool IsCritical()
        {
            Random rand = new Random();
            int number = rand.Next(0, 100);

            if (number >= 90 - Luck)
                return true;
            else
                return false;
        }
        
    }
}
