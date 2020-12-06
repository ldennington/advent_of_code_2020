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
            string[] input = File.ReadAllLines(@"C:\repos\advent_of_code_2020\advent_of_code\data\night4_part1.txt");
            List <Dictionary<string, string>> passports = ParseInput(input);

            Console.WriteLine($"Valid passports: {GetValidPassports(passports)}");
        }

        internal static List<Dictionary<string,string>> ParseInput(string[] args)
        {
            List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
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

        internal static Dictionary<string, string> CreatePassport(string completedPassport)
        {
            string[] fields = completedPassport.Split(" ");
            Dictionary<string, string> passport = new Dictionary<string, string>();

            foreach(string item in fields)
            {
                string[] field = item.Split(":");
                passport.Add(field[0], field[1]);
            }

            return passport;
        }

        internal static int GetValidPassports(List<Dictionary<string, string>> passports)
        {
            int validPassports = 0;

            foreach (Dictionary<string, string> passport in passports)
            {
                List<string> fields = passport.Keys.ToList<string>();

                if (fields.Count == 8)
                {
                    validPassports++;
                }
                else if (fields.Count == 7 && !fields.Contains("cid"))
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

    }
}
