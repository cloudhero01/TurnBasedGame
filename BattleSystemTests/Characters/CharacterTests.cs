using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleSystem.Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSystem.Characters.Tests
{
    [TestClass()]
    public class CharacterTests
    {
        [TestMethod()]
        public void CharacterTest()
        {
            Dictionary<string, int> Hero1Stats = new Dictionary<string, int>();
            var Level = 1;
            var Strength = 15;
            var Intelligence = 11;
            var Agility = 12;
            var Constitution = 14;
            var Luck = 10;

            Character characterTest = new Character(
                name: "Player1", 
                stats: new Dictionary<string, int>() {
                    { "Level", Level },
                    { "Strength", Strength },
                    { "Intelligence", Intelligence },
                    { "Agility", Agility },
                    { "Constitution", Constitution },
                    { "Luck", Luck }
                }); 

            Assert.AreEqual(characterTest.Level, Level);
            Assert.AreEqual(characterTest.Strength, Strength);
            Assert.AreEqual(characterTest.Intelligence, Intelligence);
            Assert.AreEqual(characterTest.Agility, Agility);
            Assert.AreEqual(characterTest.Constitution, Constitution);
            Assert.AreEqual(characterTest.Luck, Luck);
            Assert.IsTrue(characterTest.Health > 0);
            Assert.IsTrue(characterTest.Mana > 0);
        }

        [TestMethod()]
        public void ReduceHealthTest()
        {
            var healthReduction = 50;

            Dictionary<string, int> player1Stats = new Dictionary<string, int>();
            player1Stats.Add("Level", 1);
            player1Stats.Add("Strength", 15);
            player1Stats.Add("Intelligence", 11);
            player1Stats.Add("Agility", 12);
            player1Stats.Add("Constitution", 14);
            player1Stats.Add("Luck", 10);

            Character player1 = new Character(name: "Player1", stats: player1Stats);

            var player1HealthStart = player1.Health;
            var player1HealthReduced = player1.ReduceHealth(50);

            Assert.AreEqual(player1HealthStart, player1HealthReduced + healthReduction);
        }

        [TestMethod()]
        public void IncreaseHealthTest()
        {
            var healthIncrease = 50;

            Dictionary<string, int> player1Stats = new Dictionary<string, int>();
            player1Stats.Add("Level", 1);
            player1Stats.Add("Strength", 15);
            player1Stats.Add("Intelligence", 11);
            player1Stats.Add("Agility", 12);
            player1Stats.Add("Constitution", 14);
            player1Stats.Add("Luck", 10);

            Character player1 = new Character(name: "Player1", stats: player1Stats);

            var player1HealthStart = player1.Health;
            player1.ReduceHealth(healthIncrease);
            var player1HealthIncreased = player1.Health + player1.IncreaseHealth(healthIncrease);

            Assert.AreEqual(player1HealthStart, player1HealthIncreased, "Current health not equal to expected health!");
        }

        [TestMethod()]
        public void TakeDamageMagicalTest()
        {
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

            Character player1 = new Character("Player1", Hero1Stats);
            Character player2 = new Character("Player2", Hero2Stats);

            var player1HealthStart = player1.Health;
            var damageDone = player1.TakeDamageMagical(player2);
            var player1HealthReduced = player1HealthStart - damageDone;

            Assert.AreEqual(player1.Health, player1HealthReduced);
        }

        [TestMethod()]
        public void TakeDamagePhysicalTest()
        {
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

            Character player1 = new Character("Player1", Hero1Stats);
            Character player2 = new Character("Player2", Hero2Stats);

            var player1HealthStart = player1.Health;
            var damageDone = player1.TakeDamagePhysical(player2);
            var player1HealthReduced = player1HealthStart - damageDone;

            Assert.AreEqual(player1HealthReduced, player1.Health);
        }

        [TestMethod()]
        public void LevelUpTest()
        {
            Dictionary<string, int> Hero1Stats = new Dictionary<string, int>();
            Hero1Stats.Add("Level", 4);
            Hero1Stats.Add("Strength", 15);
            Hero1Stats.Add("Intelligence", 11);
            Hero1Stats.Add("Agility", 12);
            Hero1Stats.Add("Constitution", 14);
            Hero1Stats.Add("Luck", 10);
            Character player1 = new Character("Player1", Hero1Stats);
            var player1StartingLevel = player1.Level;

            player1.LevelUp();
                        
            Assert.AreEqual(Hero1Stats["Level"] + 1, player1.Level, "Level is not equal!");
            Assert.AreEqual(Hero1Stats["Strength"] + 1, player1.Strength, "Strength is not equal!");
            Assert.AreEqual(Hero1Stats["Intelligence"] + 1, player1.Intelligence, "Intelligence is not equal!");
            Assert.AreEqual(Hero1Stats["Agility"] + 1, player1.Agility, "Agility is not equal!");
            Assert.AreEqual(Hero1Stats["Constitution"] + 1, player1.Constitution, "Consititution is not equal!");
            Assert.AreEqual(Hero1Stats["Luck"] + 1, player1.Luck, "Luck is not equal!");
        }

        [TestMethod()]
        public void AddItemTest()
        {
            var itemQuantity = 5;
            Dictionary<string, int> Hero1Stats = new Dictionary<string, int>();
            Hero1Stats.Add("Level", 1);
            Hero1Stats.Add("Strength", 15);
            Hero1Stats.Add("Intelligence", 11);
            Hero1Stats.Add("Agility", 12);
            Hero1Stats.Add("Constitution", 14);
            Hero1Stats.Add("Luck", 10);
            Character player1 = new Character("Player1", Hero1Stats);

            player1.AddItem(new Items.HiPotion(itemQuantity));
            var addedTtemQuantity = player1.Inventory.Where(i => i.Name == nameof(Items.HiPotion)).Select(i => i.Quantity).Single();

            Assert.AreEqual(itemQuantity, addedTtemQuantity, "Item quantity is not equal!");
        }

        [TestMethod()]
        public void RemoveItemTest()
        {
            //TODO:  Validate removal of item from inventory
        }

        [TestMethod()]
        public void UseItemTest()
        {
            //TODO:  Validate action of item on single character
        }

        [TestMethod()]
        public void UseMultiItemTest()
        {
            //TODO:  Validate action of item on multiple characters
        }
    }
}