using System;
using System.IO;

namespace Project_Week_2020
{
    class Program
    {
        static string FirstNameVisitorGive = ""; //given the first name from the TextDocument
        static string LastNameVisitorGive = ""; //given the last name from the TextDocument
        static string FirstNameResidentGive = ""; //given the first name from the TextDocument
        static string LastNameResidentGive = ""; //given the last name from the TextDocument
        static int NumberDegreeVisitor = 0;
        static int NumberDegreeResident = 0;
        static public bool AccessVisitor = false;
        static public bool AccessResident = false;

        public static void RandomNumberVisitor() //generates a random number.
        {
            Random gen = new Random();
            NumberDegreeVisitor = gen.Next(34, 41);
            
        }

        static void FirstNameCostumerTXT() //gives the first name of the person
        {
            string[] FirstName = File.ReadAllLines(@"FirstName.txt");
            Random generator = new Random();
            int index = generator.Next(FirstName.Length);
            FirstNameVisitorGive = FirstName[index].ToUpper();
            
        }

        static void LastNameCostumerTXT() // gives the last name of the person
        {
            string[] LastName = File.ReadAllLines(@"LastName.txt");
            Random generator = new Random();
            int index = generator.Next(LastName.Length);
            LastNameVisitorGive = LastName[index].ToUpper();
            
        }
        
        

        public static void FirstnameResident()
        {
            string[] FirstName = File.ReadAllLines(@"FirstName.txt");
            Random generator = new Random();
            int index = generator.Next(FirstName.Length);
            FirstNameResidentGive = FirstName[index].ToUpper();

        }

        public static void LastnameResident()
        {
            string[] FirstName = File.ReadAllLines(@"FirstName.txt");
            Random generator = new Random();
            int index = generator.Next(FirstName.Length);
            LastNameResidentGive = FirstName[index].ToUpper();

        }
        public static void RandomNumberResident() //generates a random number.
        {
            Random gen = new Random();
            NumberDegreeResident = gen.Next(34, 41);

        }


        public static void SHOWVisitor() //shows the first name + last name + the temperature of the person.
        {
            Console.WriteLine($"Welcome Visitor {FirstNameVisitorGive} {LastNameVisitorGive}");
            Console.WriteLine("Give us one second. We're going to measure your body temperature.");
            Console.WriteLine($"At this moment your body temperature is {NumberDegreeVisitor}° ");

            if (NumberDegreeVisitor > 38)
            {
                Console.WriteLine("Sorry but your temperature is way to HIGH your access is denied at the Nursing Home.\n");
                AccessVisitor = default;

            }
            else if (NumberDegreeVisitor <= 38)
            {
                Console.WriteLine("Welcome to the Nursing Home... but please respect the social distinsing and avoid any unnecessary contact with other people.\n");
                AccessVisitor = true;
            }
        }
        public static void SHOWResident() //shows the first name + last name + the temperature of the person.
        {
            Console.WriteLine($"Welcome {FirstNameResidentGive} {LastNameResidentGive}");
            Console.WriteLine("Give us one second. We're going to measure your body temperature.");
            Console.WriteLine($"At this moment your body temperature is {NumberDegreeResident}° ");

            if (NumberDegreeResident > 38)
            {
                Console.WriteLine("Sorry but your temperature is way to HIGH your access is denied at the Nursing Home.\n");
                AccessResident = default;

            }
            else if (NumberDegreeResident <= 38)
            {
                Console.WriteLine("Welcome to the Nursing Home... but please respect the social distinsing and avoid any unnecessary contact with other people.\n");
                AccessResident = true;
            }
        }





        static void Main(string[] args)
        {
            RandomNumberVisitor();
            RandomNumberResident();
            FirstNameCostumerTXT();
            LastNameCostumerTXT();
            FirstnameResident();
            LastnameResident();
            SHOWVisitor();
            SHOWResident();
        }
    }
}
