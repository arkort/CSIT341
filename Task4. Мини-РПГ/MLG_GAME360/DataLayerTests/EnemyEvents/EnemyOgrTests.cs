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
    public class EnemyOgrTests
    {
        private Player player;
        Data data;
        bool test = false;
        EnemyOgr eO;

       [TestInitialize]
        public void Init()
        {
            eO = new EnemyOgr(-10, 0);
            player = new Player(200, 130, 0, 4);
            data = new Data(player);
            data.weapons.Add(0, new Tuple<int, string>(10, "Кинжала"));
        }
        [TestMethod()]
        public void EventHandleTestOgr()
        {          
            eO.EventHandle(data.player, data);
            int g = player.gold;
            if (g >= 175 && g <= 250)
            {
                test = true;
            }
            Assert.AreEqual(test, true);
        }
    }
}