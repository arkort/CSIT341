using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.PickUpEvents;
using System.Windows;

namespace DataLayer.EnemyEvents
{
    public class EnemyBoss : EnemyEvent
    {
        public int weaponType { get; set; }
        public double armour { get; set; }
        public EnemyBoss(int enemyHealth, int weaponType, double armour) : base(enemyHealth)
        {
            this.weaponType = weaponType;
            this.armour = armour;
        }
        
        public override string EventHandle(Player player, Data data)
        {            
            StringBuilder resultMassage = new StringBuilder(70);            

            if (armour > 0.5)
            {
                armour = 0;
            }

            int realDamage = player.strength
                + random.Next(data.weapons[player.weapontype].Item1, data.weapons[player.weapontype].Item1 + 10);
            int resultingDamage = realDamage - (int)(realDamage * armour);
            
            this.hitForce = random.Next(25, 40)
                + random.Next(data.weapons[this.weaponType].Item1, data.weapons[this.weaponType].Item1 + 10);
            
            this.enemyHealth -= resultingDamage;


            if (armour == 0)
            {
                resultMassage.Append("Вы нанесли ").Append(resultingDamage.ToString())
                    .Append(" урона боссу c ").Append(data.weapons[player.weapontype].Item2).Append(". ");
            }
            else
            {
                resultMassage.Append("Вы нанесли ").Append(resultingDamage.ToString()).Append(" урона боссу c ")
                    .Append(data.weapons[player.weapontype].Item2).Append(". Босс блокирует ")
                    .Append(((int)(armour * 100)).ToString()).Append("% урона. ");
            }
            
            if (this.enemyHealth > 0)
            {
                if (!IsMiss(player))
                {
                    player.health -= this.hitForce;
                    resultMassage.Append("Вы получили ").Append(this.hitForce.ToString()).Append(" урона от босса c ")
                        .Append(data.weapons[this.weaponType].Item2.ToString()).Append(".");
                }
                else
                {
                    resultMassage.Append("Вы уклонились от атаки босса.");
                }
            }

            else
            {
                player.gold += random.Next(750, 1000);
                resultMassage.Append("Вы победили босса.");
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
                    LargeMedKit medKit = new LargeMedKit(random.Next(70, 90));
                    data.AddEvent(medKit);
                    resultMassage.Append(" Выпала большая аптечка.");
                }
            }
            return resultMassage.ToString();
        }

        private bool IsMedkit()
        {
            int chance = random.Next(0, 100);
            
            if (chance <= 30)
            {
                return true;
            }
            return false;
        }

        private bool IsWeaponDroped()
        {
            int chance = random.Next(0, 100);
            if (chance <= 50)
            {
                return true;
            }
            return false;
        }
        public override IEvent CloneEvent()
        {
            var cloneevent = new EnemyBoss(this.enemyHealth, this.weaponType, this.armour);
            return cloneevent;
        }
    }
}
