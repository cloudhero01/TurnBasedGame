using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleSystem.Characters;

namespace BattleSystem.Items
{
    public interface IItem
    {
        string Name { get; set; }
        int Quantity { get; set; }

        int ReduceQuantity();
        int ReduceQuantity(int quantity);
        int Use(Character targetCharacter);
        Character[] Use(Character[] characterList);
    }
        
    public class Potion : IItem
    {
        public string Name { get; set; } = nameof(Items.Potion);
        public int Quantity { get; set; }

        public Potion()
        {
            Quantity = 0;
        }

        public Potion(int quantity)
        {
            Quantity = quantity;
        }

        public int Use(Character character)
        {
            return IncreaseSingleHealth(character);
        }
            
        public Character[] Use(Character[] characterList)
        {
            return IncreaseMultiHealth(characterList);
        }

        //Heal for 50
        public int IncreaseSingleHealth(Character targetCharacter)
        {
            int increaseAmount = 50;

            if (Quantity > 0)
            {
                int healthIncrease = targetCharacter.IncreaseHealth(increaseAmount);
                Console.WriteLine("Healed {0} with {1} for {2} HP!", targetCharacter.Name, nameof(Items.Potion), healthIncrease);

                ReduceQuantity();
                return healthIncrease;
            }
            else
                return 0;
        }

        //Heal everyone for 20
        private Character[] IncreaseMultiHealth(Character[] targetCharacterList)
        {
            int increaseAmount = 20;

            if (Quantity > 0)
            {
                foreach (Character currentCharacter in targetCharacterList)
                {
                    int healthIncrease = currentCharacter.IncreaseHealth(increaseAmount);

                    Console.WriteLine("Healed {0} with {1} for {2} HP!", currentCharacter.Name, nameof(Items.Potion), healthIncrease);
                }

                ReduceQuantity();
            }

            return targetCharacterList;
        }

        public int ReduceQuantity()
        {
            return Quantity--;
        }

        public int ReduceQuantity(int quantity)
        {
            return Quantity - quantity;
        }
    }

    public class HiPotion : IItem
    {
        public string Name { get; set; } = nameof(Items.HiPotion);
        public int Quantity { get; set; }

        public HiPotion()
        {
            Quantity = 0;
        }

        public HiPotion(int quantity)
        {
            Quantity = quantity;
        }

        public int Use(Character character)
        {
            return IncreaseSingleHealth(character);
        }

        public Character[] Use(Character[] characterList)
        {
            return IncreaseMultiHealth(characterList);
        }

        //Heal for 500
        private int IncreaseSingleHealth(Character targetCharacter)
        {
            int increaseAmount = 500;

            if (Quantity > 0)
            {
                int healthIncrease = targetCharacter.IncreaseHealth(increaseAmount);
                Console.WriteLine("Healed {0} with {1} for {2} HP!", targetCharacter.Name, nameof(Items.Potion), healthIncrease);

                ReduceQuantity();
                return healthIncrease;
            }
            else
                return 0;
        }

        //Heal everyone for 200
        private Character[] IncreaseMultiHealth(Character[] targetCharacterList)
        {
            int increaseAmount = 200;

            if (Quantity > 0)
            {
                foreach (Character currentCharacter in targetCharacterList)
                {
                    int healthIncrease = currentCharacter.IncreaseHealth(increaseAmount);

                    Console.WriteLine("Healed {0} with {1} for {2} HP!", currentCharacter.Name, nameof(Items.HiPotion), healthIncrease);                    
                }

                ReduceQuantity();
            }
                
            return targetCharacterList;
        }

        public int ReduceQuantity()
        {
            return Quantity--;
        }

        public int ReduceQuantity(int quantity)
        {
            return Quantity -= quantity;
        }
    }
}
