using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Week_2020
{
    public class Email
    {
        public bool IsValidEmail(string email)
        {
            bool isValid = false;
            bool firstCondition = email.Contains("@");
            bool secondCondition = false;
            bool thirdCondition = false;
            bool fourthCondition = false;
            int indexofAt = email.IndexOf('@');
            int indexofDot = email.LastIndexOf('.');
            string emailMinusBeforeAt = email.Remove(0, indexofAt + 1);

            if (emailMinusBeforeAt.Contains(".") && indexofDot >= (indexofAt + 2))
            {
                secondCondition = true;
            }
            else
            {
                secondCondition = false;
            }

            if (indexofAt >= 1)
            {
                thirdCondition = true;
            }
            else
            {
                thirdCondition = false;
            }


            if (indexofDot < email.Length - 1)
            {
                fourthCondition = true;
            }
            else
            {
                fourthCondition = false;
            }

            isValid = (firstCondition && secondCondition && thirdCondition && fourthCondition);

            return isValid;
        }
    }
}
    

       





