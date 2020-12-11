using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleToAttribute("Night6.Test")]
namespace Night6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\repos\advent_of_code_2020\data\night6.txt");
            Console.WriteLine($"Total of unique answers: { CalculateFinalTotal(ParseInput(input)) }");
        }

        internal static List<List<string>> ParseInput(string[] input)
        {
            List<List<string>> groupedRespondentList = new List<List<string>>();
            List<string> groupedRespondents = new List<string>();

            foreach (string item in input)
            {             
                if (item != "")
                {
                    groupedRespondents.Add(item);
                }
                else
                {
                    groupedRespondentList.Add(groupedRespondents);
                    groupedRespondents = new List<string>();
                }
            }

            return groupedRespondentList;
        }

        internal static int CalculateFinalTotal(List<List<string>> respondentList)
        {
            int finalCount = 0;

            foreach (List<string> groupedResponses in respondentList)
            {
                finalCount += CalculateGroupTotal(groupedResponses);
            }

            return finalCount;
        }

        internal static int CalculateGroupTotal(List<string> groupedResponses)
        {
            HashSet<char> evaluatedLetters = new HashSet<char>();
            Dictionary<char, int> lettersAndCounts = new Dictionary<char, int>();

            foreach(string response in groupedResponses)
            {
                AddOrCountLetters(response, lettersAndCounts);
            }

            return lettersAndCounts.Values.Count(c => c == groupedResponses.Count);
        }

        internal static void AddOrCountLetters(string response, Dictionary<char, int> lettersAndCounts)
        {
            char[] letters = response.ToCharArray();

            foreach (char letter in letters)
            {
                if (lettersAndCounts.ContainsKey(letter))
                {
                    lettersAndCounts[letter]++;
                }
                else
                {
                    lettersAndCounts.Add(letter, 1);
                }
            }
        }
    }
}
