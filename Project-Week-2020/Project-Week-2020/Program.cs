using System;

namespace Project_Week_2020
{
    class Program
    {
        static string FirstNameGive = ""; //given the first name from the TextDocument
        static string LastNameGive = ""; //given the last name from the TextDocument
        static int NumberDegree = 0;

        public static void RandomNumber() //generates a random number.
        {
            Random gen = new Random();
            NumberDegree = gen.Next(34, 41);
            
        }

        static void FirstNameTXT() //gives the first name of the person
        {
            string[] FirstName = System.IO.File.ReadAllLines(@"FirstName.txt");
            Random generator = new Random();
            int index = generator.Next(FirstName.Length);
            FirstNameGive = FirstName[index].ToUpper();
            
        }

        static void LastNameTXT() // gives the last name of the person
        {
            string[] LastName = System.IO.File.ReadAllLines(@"LastName.txt");
            Random generator = new Random();
            int index = generator.Next(LastName.Length);
            LastNameGive = LastName[index].ToUpper();
            
        }
        
        public static void SHOW() //shows the first name + last name + the temperature of the person.
        {
            Console.WriteLine($"Welcome {FirstNameGive} {LastNameGive}");
            Console.WriteLine("Give us one second were are going to measure your body temperature.");
            Console.WriteLine($"At this moment your body temperature is {NumberDegree}° ");
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
