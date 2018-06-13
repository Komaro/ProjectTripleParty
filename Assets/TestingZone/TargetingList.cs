using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.TestingZone
{
    public class TargetingList
    {
        public GameObject Object;
        public float Distance;

        public TargetingList(GameObject Object)
        {
            this.Object = Object;
        }
    }
}
