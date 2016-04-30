using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.EnemyEvents;

namespace DAO.Tests
{
    [TestClass()]
    public class GameLogicTests
    {

        private GameLogic qwe;
        private Player player;
        public Random random;

        [TestInitialize]
        public void Init()
        {
            random = new Random();
            qwe = new GameLogic();
            player = new Player(250, 26, 0, 4);
        }

        [TestMethod()]
        public void InitWeaponsTest()
        {
            qwe.data = new Data(player);
            qwe.data.weapons = new Dictionary<int, Tuple<int, string>>();
            qwe.InitWeapons();
            var quantity = qwe.data.weapons.Count();
            Assert.AreEqual(quantity, 4);
        }

        [TestMethod()]
        public void GeneratePlayerTest()
        {
            int max_player_health = random.Next(100, 300);
            int strength = random.Next(5, 15);
            int agility = random.Next(1, 30);
            if (max_player_health > 300 && max_player_health < 100) Assert.Fail("такое невозможно");
            if (strength > 15 && strength < 5) Assert.Fail("такое невозможно");
            if (agility > 30 && agility < 1) Assert.Fail("такое невозможно");           
            
        }

        [TestMethod()]
        public void GenerateEventTest()
        {
            var Event = qwe.GenerateEvent().CloneEvent();
            Assert.IsInstanceOfType(Event, typeof(IEvent));
        }

        [TestMethod()]
        public void CheckGameTestDead()
        {
            qwe.data = new Data(player);
            qwe.data.player.health = 0;
            qwe.CheckGame();
            Assert.AreEqual(true, qwe.IsEndGame);
        }

        [TestMethod()]
        public void CheckGameTestWin()
        {
            qwe.data = new Data(player);
            qwe.data.player.gold = 20000;
            qwe.CheckGame();
            Assert.AreEqual(true, qwe.IsEndGame);
        }

        [TestMethod()]
        public void IsStepFinishedTestTrue()
        {
            var vE = new EnemyRat(-1);
            Assert.IsTrue(qwe.IsStepFinished(vE));
        }

        [TestMethod()]
        public void IsStepFinishedTestFalse()
        {
            var vE = new EnemySkeleton(21, 1);
            Assert.IsFalse(qwe.IsStepFinished(vE));
        }
       
    }
}