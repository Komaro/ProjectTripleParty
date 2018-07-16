using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.StartingWork.User
{
    public class UserForm
    {
        public int usercode;
        public int level;
        public int fuel;
        public int material;
        public int ammunition;

        public UserForm(int usercode, int level, int fuel, int material, int ammunition)
        {
            this.usercode = usercode;
            this.level = level;
            this.fuel = fuel;
            this.material = material;
            this.ammunition = ammunition;
        }
    }
}
