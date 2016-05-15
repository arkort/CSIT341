using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PickUpEvents
{
    public class LargeTreasure : IEvent
    {
        public int gold { get; set; }

        public LargeTreasure(int gold)
        {
            this.gold = gold;
        }

        public string EventHandle(Player player, Data data)
        {
            player.gold += gold;
            string resultString = "Вы нашли большой сундук с сокровищами + " + this.gold.ToString() + " золота.";
            return resultString;
        }
        public IEvent CloneEvent()
        {
            var cloneevent = new LargeTreasure(this.gold);
            return cloneevent;
        }
    }
}
