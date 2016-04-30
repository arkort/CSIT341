using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EnemyEvents
{
    public class EnemyRat : EnemyEvent
    {
        public EnemyRat(int enemyHealth) : base(enemyHealth)
        { }
        public override IEvent CloneEvent()
        {
            var cloneevent = new EnemyRat(this.enemyHealth);
            return cloneevent;
        }
        public override string EventHandle(Player player, Data data)
        {

            StringBuilder resultMassage = new StringBuilder(50);
            int resultingDamage = player.strength
                + random.Next(data.weapons[player.weapontype].Item1, data.weapons[player.weapontype].Item1 + 10);
            this.hitForce = random.Next(4, 10);
            this.enemyHealth -= resultingDamage;
            resultMassage.Append("Вы нанесли ").Append(resultingDamage.ToString()).Append(" урона крысе c ")
                .Append(data.weapons[player.weapontype].Item2).Append(". ");
            if (this.enemyHealth > 0)
            {
                if (!IsMiss(player))
                {
                    player.health -= this.hitForce;
                    resultMassage.Append("Вы получили ").Append(this.hitForce.ToString()).Append(" урона от крысы.");
                }
                else
                {
                    resultMassage.Append("Вы уклонились от атаки крысы.");
                }

            }
            else
            {
                player.gold += random.Next(20, 100);
                resultMassage.Append("Крыса мертва.");

             //   data.ForceEvent = true;
            //    data.AddEvent(new SmallMedKit(random.Next(20, 50)));

            }
            return resultMassage.ToString();
        }
    }
}
