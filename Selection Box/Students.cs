using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8
{
    public class Students
    {
        //name and grades
        public string FName;
        public string LName;
        public int egrade;
        public int othergrade;

        public Students(string firstName, string lastName, int cSIgrade, int genEdgrade)
        {//add all together
            FName = firstName;
            LName = lastName;
            egrade = cSIgrade;
            othergrade = genEdgrade;
        }
    }
}
