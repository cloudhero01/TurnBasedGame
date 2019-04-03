using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BattleSystem.Characters;
using BattleSystem.Items;

namespace BattleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: 
                //Add console UI for character action selection
                //Add queue for character actions
                //Add logic to record character details to file to preserve combat changes for next fight.

            //Initialize
            Dictionary<string, int> Hero1Stats = new Dictionary<string, int>();
            Dictionary<string, int> Hero2Stats = new Dictionary<string, int>();

            Hero1Stats.Add("Level", 1);
            Hero1Stats.Add("Strength", 15);
            Hero1Stats.Add("Intelligence", 11);
            Hero1Stats.Add("Agility", 12);
            Hero1Stats.Add("Constitution", 14);
            Hero1Stats.Add("Luck", 10);
            
            Hero2Stats.Add("Level", 1);
            Hero2Stats.Add("Strength", 12);
            Hero2Stats.Add("Intelligence", 10);
            Hero2Stats.Add("Agility", 16);
            Hero2Stats.Add("Constitution", 12);
            Hero2Stats.Add("Luck", 15);

            Character hero1 = new Character("Cloud", Hero1Stats);
            Character hero2 = new Character("Tifa", Hero2Stats);
                        
            int itemCount = 1;
            
            //Battle Begins
            Console.WriteLine("\n{0} {1} added to {2}'s inventory!", itemCount, hero1.AddItem(new Items.Potion(itemCount)).Name, hero1.Name);
            Console.WriteLine("{0} {1} added to {2}'s inventory!", itemCount, hero1.AddItem(new Items.HiPotion(itemCount)).Name, hero1.Name);

            Console.WriteLine("\n{0} attacks {1} with {2} damage!", hero2.Name, hero1.Name, hero1.TakeDamagePhysical(hero2));
            Console.WriteLine("{0}'s health is currently {1}.", hero1.Name, hero1.Health);
            Console.WriteLine("{0}'s mana is currently {1}.", hero1.Name, hero1.Mana);

            hero1.UseItem(hero1, hero1.Inventory.Where(i => i.Name == nameof(Items.Potion)).Select(i => i).Single());

            Console.WriteLine("\n{0}'s health is currently {1}.", hero1.Name, hero1.Health);
            Console.WriteLine("{0} attacks {1} with {2} damage!", hero2.Name, hero1.Name, hero1.TakeDamagePhysical(hero2));
            Console.WriteLine("{0}'s health is currently {1}.", hero1.Name, hero1.Health);

            Console.WriteLine();
            hero1.UseItem(hero1, hero1.Inventory.Where(i => i.Name == nameof(Items.HiPotion)).Select(i => i).Single());
            Console.WriteLine("{0}'s health is currently {1}.", hero1.Name, hero1.Health);

            Console.WriteLine("\n{0} currently has {1} {2}.", hero1.Name, hero1.Inventory.Where(i => i.Name == nameof(Items.Potion)).Count(), nameof(Items.Potion));
            Console.WriteLine("{0} currently has {1} {2}.", hero1.Name, hero1.Inventory.Where(i => i.Name == nameof(Items.HiPotion)).Count(), nameof(Items.HiPotion));
            
            Console.ReadLine();
        }
    }
}
