using System;
using System.IO;

namespace Project_Week_2020
{
    class Program
    {
        static string FirstNameGive = ""; //given the first name from the TextDocument
        static string LastNameGive = ""; //given the last name from the TextDocument
        static int NumberDegree = 0;
        static public bool Access = false;

        public static void RandomNumber() //generates a random number.
        {
            Random gen = new Random();
            NumberDegree = gen.Next(34, 41);
            
        }

        static void FirstNameTXT() //gives the first name of the person
        {
            string[] FirstName = File.ReadAllLines(@"FirstName.txt");
            Random generator = new Random();
            int index = generator.Next(FirstName.Length);
            FirstNameGive = FirstName[index].ToUpper();
            
        }

        static void LastNameTXT() // gives the last name of the person
        {
            string[] LastName = File.ReadAllLines(@"LastName.txt");
            Random generator = new Random();
            int index = generator.Next(LastName.Length);
            LastNameGive = LastName[index].ToUpper();
            
        }
        
        public static void SHOW() //shows the first name + last name + the temperature of the person.
        {
            Console.WriteLine($"Welcome {FirstNameGive} {LastNameGive}");
            Console.WriteLine("Give us one second were are going to measure your body temperature.");
            Console.WriteLine($"At this moment your body temperature is {NumberDegree}° \n");
            if(NumberDegree > 38)
            {
                Console.WriteLine("Sorry but your temperature is way to HIGH your access is denied at the Nursing Home");
                Access = default;

            }
            else if (NumberDegree <= 38)
            {
                Console.WriteLine("Welcome to the Nursing Home... but please respect the social distinsing and avoid any unnecessary contact with other people.");
            }
        }







        static void Main(string[] args)
        {
            RandomNumber();
            FirstNameTXT();
            LastNameTXT();
            SHOW();
        }
    }
}
