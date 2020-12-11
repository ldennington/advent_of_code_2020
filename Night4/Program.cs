using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Night4.Test")]
namespace Night4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\repos\advent_of_code_2020\data\night4.txt");
            List <Passport> passports = ParseInput(input);

            Console.WriteLine($"Valid passports: {GetValidPassports(passports)}");
        }

        internal static List<Passport> ParseInput(string[] args)
        {
            List<Passport> passports = new List<Passport>();
            string completedPassport = "";

            foreach(string input in args)
            {
                if (!input.Equals(""))
                {
                    completedPassport += $"{input} ";
                }
                else
                {
                    passports.Add(CreatePassport(completedPassport.Trim()));
                    completedPassport = "";
                }
            }

            return passports;
        }

        internal static Passport CreatePassport(string completedPassport)
        {
            string[] fields = completedPassport.Split(" ");
            Dictionary<string, string> passport = new Dictionary<string, string>();

            foreach(string item in fields)
            {
                string[] field = item.Split(":");
                passport.Add(field[0], field[1]);
            }

            return new Passport(passport);
        }

        internal static int GetValidPassports(List<Passport> passports)
        {
            int validPassports = 0;

            foreach (Passport passport in passports)
            {
                if (passport.IsValid())
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

    }
}
