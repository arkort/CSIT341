using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.PickUpEvents;

namespace DataLayer.EnemyEvents
{
    public class EnemyOgr : EnemyEvent
    {
        public int weaponType { get; set; }
        public EnemyOgr(int enemyHealth, int weaponType) : base(enemyHealth)
        {
            this.weaponType = weaponType;
        }
       
        public override string EventHandle(Player player, Data data)
        {
            StringBuilder resultMassage = new StringBuilder(70);
            int resultingDamage = player.strength
                + random.Next(data.weapons[player.weapontype].Item1, data.weapons[player.weapontype].Item1 + 10);

            this.hitForce = random.Next(15, 23)
                + random.Next(data.weapons[this.weaponType].Item1, data.weapons[this.weaponType].Item1 + 10);

            this.enemyHealth -= resultingDamage;
            resultMassage.Append("Вы нанесли ").Append(resultingDamage.ToString()).Append(" урона огру c ")
                .Append(data.weapons[player.weapontype].Item2).Append(". ");
            if (this.enemyHealth > 0)
            {
                if (!IsMiss(player))
                {
                    player.health -= this.hitForce;
                    resultMassage.Append("Вы получили ").Append(this.hitForce.ToString()).Append(" урона от огра c ")
                        .Append(data.weapons[this.weaponType].Item2.ToString()).Append(".");
                }
                else
                {
                    resultMassage.Append("Вы уклонились от атаки огра.");
                }
            }
            else
            {
                player.gold += random.Next(175, 250);
                resultMassage.Append("Огр мертв.");

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
                    MediumMedKit medKit = new MediumMedKit(random.Next(40, 50));
                    data.AddEvent(medKit);
                    resultMassage.Append(" Выпала аптечка.");


                }
            }
            return resultMassage.ToString();
        }

        private bool IsMedkit()
        {
            int chance = random.Next(0, 100);
            if (chance <= 15)
            {
                return true;
            }
            return false;
        }

        private bool IsWeaponDroped()
        {
            int chance = random.Next(0, 100);
            if (chance <= 25)
            {
                return true;
            }
            return false;
        }
        public override IEvent CloneEvent()
        {
            var cloneevent = new EnemyOgr(this.enemyHealth, this.weaponType);
            return cloneevent;
        }
    }
}

