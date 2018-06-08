using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.TestingZone
{
    class EnemyInformation
    {
        public static EnemyInformation Instance;

        private GameObject[] enemyList;

        EnemyInformation()
        {
            enemyList = GameObject.FindGameObjectsWithTag("EnemyFleet");
        }
        
        public static EnemyInformation getInstance()
        {
            if(Instance == null)
            {
                Instance = new EnemyInformation();
            }

            return Instance;
        }

        
        
        public GameObject[] getEnemyList()
        {
            return enemyList;
        }
    }
}
