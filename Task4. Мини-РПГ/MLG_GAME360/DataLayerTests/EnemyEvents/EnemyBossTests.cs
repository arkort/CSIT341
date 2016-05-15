using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.EnemyEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EnemyEvents.Tests
{
    [TestClass()]
    public class EnemyBossTests
    {
        private Player player;

        [TestInitialize]
        public void Init()
        {
            player = new Player(200, 130, 0, 4);
        }
        [TestMethod()]
        public void EventHandleTestBoss()
        {
            Data data = new Data(player);
            EnemySkeleton e = new En(31, -1);
            data.weapons.Add(0, new Tuple<int, string>(10, "Кинжала"));
            string result = e.EventHandle(data.player, data);
            string[] hf = result.Split(' ');
            string skeletonD = (hf[7]) + " " + (hf[8]);
            string expected = "Скелет мертв.";
            Assert.AreEqual(expected, skeletonD);
        }
    }
}