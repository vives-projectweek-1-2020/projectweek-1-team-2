using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Week_2020
{
    public class FullName
    {
        public bool IsValidName(string firstname, string lastname)
        {
            bool isValid = false;

            if((firstname != "" && firstname.Length >= 2) && (lastname != "" && lastname.Length >= 4))
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
