using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleSystem.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleSystem.Characters;

namespace BattleSystem.Items.Tests
{
    [TestClass()]
    public class PotionTests
    {
        [TestMethod()]
        public void PotionTest()
        {
            Potion potion = new Potion();
            
            Assert.AreEqual(potion.Name, nameof(Potion));
            Assert.AreEqual(potion.Quantity, 0);
        }

        [TestMethod()]
        public void PotionTest1()
        {
            var quantity = 6;
            Potion potion = new Potion(quantity);

            Assert.AreEqual(potion.Name, nameof(Potion));
            Assert.AreEqual(potion.Quantity, quantity);
        }

        [TestMethod()]
        public void UseTest()
        {
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
            characterTest.ReduceHealth(50);

            var quantity = 6;
            Potion potion = new Potion(quantity);
            
            Assert.AreEqual(potion.Use(characterTest), 50);
        }

        [TestMethod()]
        public void UseTest1()
        {
            Dictionary<string, int> Hero1Stats = new Dictionary<string, int>();
            Dictionary<string, int> Hero2Stats = new Dictionary<string, int>();
            int healthReduction = 20;

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

            var quantity = 6;
            Potion potion = new Potion(quantity);

            var player1StartHealth = player1.Health;
            var player2StartHealth = player2.Health;
            
            player1.ReduceHealth(healthReduction);
            player2.ReduceHealth(healthReduction);
            potion.Use(new Character[] { player1, player2 });

            Assert.AreEqual(player1StartHealth, player1.Health);
            Assert.AreEqual(player2StartHealth, player2.Health);
        }

        [TestMethod()]
        public void IncreaseSingleHealthTest()
        {
            //TODO: Validate increase health for single character
        }

        [TestMethod()]
        public void ReduceQuantityTest()
        {
            //TODO:  Validate reduction
        }

        [TestMethod()]
        public void ReduceQuantityTest1()
        {
            //TODO:  Validate reduction with specific number
        }
    }
}