using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Player
    {
        public int health { get; set; }
        public int maxhealth { get; set; }
        public int gold { get; set; }
        public int strength { get; set; }
        public int agility { get; set; }
        public int weapontype { get; set; }
        
        public Player(int maxhealth, int strength, int weapontype, int agility)
        {
            this.maxhealth = maxhealth;
            this.gold = 0;
            this.health = maxhealth;
            this.strength = strength;
            this.weapontype = weapontype;
            this.agility = agility;
        }
        
    }
}
