using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class WeaponGenerate
    {
        private static Random random = new Random();
        public static int GenerateWeapon()
        {
            int weaponChance = random.Next(0, 100);
            int weaponType = -1;

            if (weaponChance <= 50)
            {
                weaponType = 0;
            }
            if (weaponChance > 50 && weaponChance <= 75)
            {
                weaponType = 1;
            }
            if (weaponChance > 75 && weaponChance <= 90)
            {
                weaponType = 2;
            }
            if (weaponChance > 90)
            {
                weaponType = 3;
            }
            return weaponType;
        }

        public static int GenerateSkeletonWeapon()
        {
            int weaponChance = random.Next(0, 100);
            int weaponType = -1;

            if (weaponChance <= 50)
            {
                weaponType = 0;
            }
            if (weaponChance > 94 && weaponChance < 100)
            {
                weaponType = 1;
            }
            return weaponType;
        }

        public static int GenerateOgrWeapon()
        {
            int weaponChance = random.Next(1, 100);
            int weaponType = 0;

            if (weaponChance < 90 && weaponChance > 20)
            {
                weaponType = 1;
            }
            if (weaponChance > 90)
            {
                weaponType = 2;
            }
            return weaponType;
        }

        public static int GenerateBossWeapon()
        {
            int weaponChance = random.Next(0, 100);
            int weaponType = 2;

            if (weaponChance >= 85)
            {
                weaponType = 3;
            }

            return weaponType;
        }
    }
}
