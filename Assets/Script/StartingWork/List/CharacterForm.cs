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
        public Sprite Sprite;
        public string Name;
        public int No;
        public string Country;

        public CharacterForm(int ImageNo, string Name, int No, string Country)
        {
            this.Sprite = Resources.Load<Sprite>("Image/test_" + ImageNo);
            this.Name = Name;
            this.No = No;
            this.Country = Country;
        }
    }
}
