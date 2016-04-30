using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PickUpEvents
{
    public class MediumMedKit : IEvent
    {
        public int hpRegen { get; set; }

        public MediumMedKit (int hpRegen)
        {
            this.hpRegen = hpRegen;
        }

        public string EventHandle(Player player, Data data)
        {
            if (player.health + this.hpRegen > player.maxhealth)
            {
                string resultString = "Вы восстановили " + (player.maxhealth - player.health).ToString() + " здоровья аптечкой.";
                player.health += (player.maxhealth - player.health);
                return resultString;
            }
            else
            {
                player.health += this.hpRegen;
                return "Вы восстановили " + this.hpRegen.ToString() + " здоровья аптечкой.";
            }
        }
        public IEvent CloneEvent()
        {
            var cloneevent = new MediumMedKit(this.hpRegen);
            return cloneevent;
        }
    }
}
