using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.PickUpEvents;

namespace DataLayer.EnemyEvents
{
    public class EnemySkeleton : EnemyEvent
    {
        public int weaponType { get; set; }
        public EnemySkeleton(int enemyHealth, int weaponType) : base(enemyHealth)
        {
            this.weaponType = weaponType;
        }
        
        public override string EventHandle(Player player, Data data)
        {
            StringBuilder resultMassage = new StringBuilder(70);
            int resultingDamage = player.strength
                + random.Next(data.weapons[player.weapontype].Item1, data.weapons[player.weapontype].Item1 + 10);
            if (this.weaponType != -1)
            {
                this.hitForce = random.Next(8, 13)
                    + random.Next(data.weapons[this.weaponType].Item1, data.weapons[this.weaponType].Item1 + 10);
            }
            else
            {
                this.hitForce = random.Next(8, 13);
            }
            this.enemyHealth -= resultingDamage;

            resultMassage.Append("Вы нанесли ").Append(resultingDamage.ToString()).Append(" урона скелету c ")
                .Append(data.weapons[player.weapontype].Item2).Append(". ");
            if (this.enemyHealth > 0)
            {
                if (!IsMiss(player))
                {
                    player.health -= this.hitForce;
                    if (this.weaponType == -1)
                    {
                        resultMassage.Append("Вы получили ").Append(this.hitForce.ToString())
                            .Append(" урона от скелета.");
                    }
                    else
                    {
                        resultMassage.Append("Вы получили ").Append(this.hitForce.ToString()).Append(" урона от скелета c ")
                            .Append(data.weapons[this.weaponType].Item2.ToString()).Append(".");
                    }
                }
                else
                {
                    resultMassage.Append("Вы уклонились от атаки скелета.");
                }
            }
            else
            {
                player.gold += random.Next(75, 150);
                resultMassage.Append("Скелет мертв.");
                if (IsWeaponDroped())
                {
                    resultMassage.Append(" Выпало оружие, ");
                    if (this.weaponType > player.weapontype)
                    {
                        player.weapontype = this.weaponType;
                        resultMassage.Append("вы сменили оружие.");
                    }
                    else
                    {
                        resultMassage.Append(" вы не меняете оружие.");
                    }
                }

                if (IsMedkit())
                {
                    data.ForceEvent = true;
                    SmallMedKit medKit = new SmallMedKit(random.Next(20, 30));
                    data.AddEvent(medKit);
                    resultMassage.Append(" Выпал бинт.");
                }
            }
            return resultMassage.ToString();
        }

        private bool IsMedkit()
        {
            int chance = random.Next(0, 100);
            if (chance <= 10)
            {
                return true;
            }
            return false;
        }

        private bool IsWeaponDroped()
        {
            int chance = random.Next(0, 100);
            if (chance <= 20)
            {
                return true;
            }
            return false;
        }
        public override IEvent CloneEvent()
        {
            var cloneevent = new EnemySkeleton(this.enemyHealth, this.weaponType);
            return cloneevent;
        }
    }
}
