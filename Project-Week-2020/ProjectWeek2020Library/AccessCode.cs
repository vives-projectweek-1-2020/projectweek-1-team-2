using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Week_2020
{
    public class AccessCode
    {
        public bool IsValidAccessCode(int accesscode)
        {
            bool isValid = false;

            if(accesscode > 999999 || accesscode < 100000)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
