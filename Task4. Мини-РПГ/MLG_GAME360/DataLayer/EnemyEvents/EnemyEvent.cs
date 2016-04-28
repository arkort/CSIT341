using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EnemyEvents
{
    public abstract class EnemyEvent : IEvent
    {
        public int enemyHealth { get; set; }
        public int hitForce { get; set; }
        public Random random = new Random();

        public EnemyEvent(int enemyHealth)
        {
            this.enemyHealth = enemyHealth;
        }
        public abstract IEvent CloneEvent();
        public abstract string EventHandle(Player player, Data data);

        public bool IsMiss(Player player)
        {
            int MissChance = random.Next(0, 100);
            if (MissChance <= player.agility)
            {
                return true;
            }
            return false;
        }
    }
}
