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
    public class EnemyEventTests
    {
        private Player player;
        EnemySkeleton eS;

        [TestInitialize]
        public void Init()
        {
            eS = new EnemySkeleton(31,0);
            player = new Player(250, 26, 0, 4);
        }

        [TestMethod()]
        public void IsMissTest()
        {
            int agility1 = player.agility;
            agility1 = -1;
            var result = eS.IsMiss(player);            
            Assert.AreEqual(result, false);
        }
    }
}