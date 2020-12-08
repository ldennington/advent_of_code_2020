using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Night6.Test")]
namespace Night6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\repos\advent_of_code_2020\advent_of_code\data\night6.txt");
            Console.WriteLine($"Total of unique answers: { CalculateFinalTotal(ParseInput(input)) }");
        }

        internal static List<string> ParseInput(string[] input)
        {
            List<string> groupedAnswers = new List<string>();
            string answers = "";

            foreach (string item in input)
            {
                if (item != "")
                {
                    answers += item;
                }
                else
                {
                    groupedAnswers.Add(answers);
                    answers = "";
                }
            }

            return groupedAnswers;
        }

        internal static int CalculateFinalTotal(List<string> groupedAnswers)
        {
            int finalTotal = 0;

            foreach (string answer in groupedAnswers)
            {
                finalTotal += CalculateGroupTotal(answer);
            }

            return finalTotal;
        }

        internal static int CalculateGroupTotal(string answer)
        {
            char[] letters = answer.ToCharArray();
            HashSet<char> uniqueLetters = new HashSet<char>();

            foreach(char letter in letters)
            {
                uniqueLetters.Add(letter);
            }

            return uniqueLetters.Count;
        }
    }
}
