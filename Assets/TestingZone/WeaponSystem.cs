using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.TestingZone
{
    public class WeaponSystem
    {
        // Status
        public string weaponName;
        public float damage;
        public float range;
        public float coolTime;
        
        // Info
        public bool readyToFire;
        public float currentCoolTime;

        public WeaponSystem(string weaponName, float damage, float range, float coolTime)
        {
            this.weaponName = weaponName;
            this.damage = damage;
            this.range = range;
            this.coolTime = coolTime;

            readyToFire = true;
            currentCoolTime = coolTime;
        }
    }
}
