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
    public class EnemyRatTests
    {
        [TestMethod()]
        public void EventHandleTestRat()
        {
            StringBuilder resultMassage = new StringBuilder(50);
            Player player = new Player(250, 26, 0, 4);
            Data data = new Data(player);
            EnemyRat e = new EnemyRat(1);
            data.weapons.Add(0, new Tuple<int, string>(10, "Кинжала"));
            e.EventHandle(data.player, data);
            bool result = false;
            if (resultMassage == resultMassage.Append("Крыса мертва."))
            {
                result = true;
            }
            Assert.IsTrue(result);           
        }
    }
}