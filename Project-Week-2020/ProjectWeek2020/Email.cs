using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeek2020
{
    class Email
    {
            public bool IsValidEmail(string email)
            {
                bool isValid = false;

                // TODO Controleer of email een @ bevat

                bool firstCondition = email.Contains('@');

                // TODO Controleer of email een . bevat na de @ met minstens 1 letter tussen
                bool secondCondition = false;

                int indexofAt = email.IndexOf('@');
                int indexofDot = email.LastIndexOf('.');
                string emailMinusBeforeAt = email.Remove(0, indexofAt + 1);


                if (emailMinusBeforeAt.Contains('.') && indexofDot >= (indexofAt + 2))
                {
                    secondCondition = true;
                }
                else
                {
                    secondCondition = false;
                }

                // TODO Controleer of er minstens 1 letter voor de @ staat
                bool thirdCondition = false;
                if (indexofAt >= 1)
                {
                    thirdCondition = true;
                }
                else
                {
                    thirdCondition = false;
                }

                // TODO Controleer of er na het laatste punt nog minstens 1 letter komt
                bool fourthCondition = false;

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
    

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to email validator ...");

                Email validator = new Email();
                string email = "";
                do
                {
                    Console.Write("Please enter email to check. Leave empty to stop.: ");
                    email = Console.ReadLine();
                    if (email != "")
                    {
                        if (validator.IsValidEmail(email))
                        {
                            Console.WriteLine("This is a valid email address");
                        }
                        else
                        {
                            Console.WriteLine("This email address is NOT valid");
                        }
                    }
                } while (email != "");

                Console.WriteLine("Thanks for using our validation app.");
            }
        }
    }





