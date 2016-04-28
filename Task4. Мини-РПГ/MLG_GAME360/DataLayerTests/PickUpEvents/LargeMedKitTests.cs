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
    public class LargeMedKitTests
    {
        private Player player = new Player(180, 130, 0, 4);
        [TestMethod()]
        public void EventHandleTestLargeMedRit()
        {
            player.health = 13;
            Data data = new Data(player);
            int hpRegen = 71;
            LargeMedKit e = new LargeMedKit(hpRegen);
            e.EventHandle(player, data);
            Assert.AreEqual(84, player.health);
        }
    }
}