using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Globalization;
using System.Xml.Serialization;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            string socialSecurityNumber;
            string generation = "";
            
            if (args.Length > 0)
            {
                firstName = args[0];
                lastName = args[1];
                socialSecurityNumber = args[2];
            }
            else
            {
                Console.Write("Please enter your first name: ");
                firstName = Console.ReadLine();

                Console.Write("Please enter your last name: ");
                lastName = Console.ReadLine();

                Console.Write("Please enter your social security number (YYYYMMDD-XXXX): ");
                socialSecurityNumber = Console.ReadLine();

                Console.Clear();  
            }

            string gender = "Female";

            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            if (genderNumber % 2 != 0)
            {
                gender = "Male";
            }

            DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if ((birthDate.Month > DateTime.Now.Month) || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age--;
            }

            if (birthDate.Year >= 1901 && birthDate.Year <= 1927)
            {
                generation = "The G.I. Generation";
            }
            else if (birthDate.Year >= 1928 && birthDate.Year <= 1945)
            {
                generation = "The Silent Generation";
            }
            else if (birthDate.Year >= 1946 && birthDate.Year <= 1964)
            {
                generation = "The Baby Boomers";
            }
            else if (birthDate.Year >= 1965 && birthDate.Year <= 1980)
            {
                generation = "Generation X";
            }
            else if (birthDate.Year >= 1981 && birthDate.Year <= 1996)
            {
                generation = "Millenials";
            }
            else if (birthDate.Year >= 1997 && birthDate.Year <= 2012)
            {
                generation = "Generation Z";
            }
            else if (birthDate.Year >= 2013 && birthDate.Year <= 2025)
            {
                generation = "Generation Alpha";
            }

            Console.WriteLine($"{"First Name: ",-15}{firstName}");
            Console.WriteLine($"{"Last Name: ",-15}{lastName}");
            Console.WriteLine($"{"SSN: ",-15}{socialSecurityNumber}");
            Console.WriteLine($"{"Gender: ",-15}{gender}");
            Console.WriteLine($"{"Age: ", -15}{age}");
            Console.WriteLine($"{"Generation: ", -15}{generation}");
        }
    }
}
