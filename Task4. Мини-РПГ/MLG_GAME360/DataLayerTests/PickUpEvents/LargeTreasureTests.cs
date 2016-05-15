using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.PickUpEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PickUpEvents.Tests
{
    [TestClass()]
    public class LargeTreasureTests
    {
        private Player player;
        Data data;    

        [TestInitialize]
        public void Init()
        {
            data = new Data(player);
            player = new Player(250, 26, 0, 4);
            data.weapons.Add(0, new Tuple<int, string>(10, "Кинжала"));
        }
        [TestMethod()]
        public void EventHandleTestLargeTreasure()
        {
            LargeTreasure qwe = new LargeTreasure(501);
            player.gold = 0;
            qwe.EventHandle(player, data);
            Assert.AreEqual(501, player.gold);
        }
    }
}