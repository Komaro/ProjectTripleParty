using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.StartingWork.List
{
    public class CharacterForm
    {
        public Sprite cutSprite;
        public Sprite fullSprite;
        public string Name;
        public int No;
        public string Country;
        public string group;

        // not complete
        public CharacterForm(int ImageNo, string Name, int No, string Country, string group)
        {
            cutSprite = Resources.Load<Sprite>("Character/test_" + ImageNo);
            fullSprite = Resources.Load<Sprite>("Character/full_test_" + ImageNo);
            this.Name = Name;
            this.No = No;
            this.Country = Country;
            this.group = group;
        }
    }
}
