using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TestingZone
{
    public class EnemyFleetAction : MonoBehaviour
    {

        public float hitPoint = 100f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void hit(float hitDamage)
        {
            hitPoint -= hitDamage;

            if (hitPoint <= 0) Destroy(gameObject);
        }
    }
}