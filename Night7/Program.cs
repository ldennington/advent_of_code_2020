using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Night7.Test")]
namespace Night7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\repos\advent_of_code_2020\data\night7.txt");
            List<Bag> bags = ParseInput(input);
            int bagCount = 0;
            
            foreach(Bag bag in bags)
            {
                if (RecurseThroughBag(bag))
                {
                    bagCount++;
                }
            }

            Console.WriteLine($"Bags containing shiny gold bags: {bagCount}");
        }

        internal static List<Bag> ParseInput(string[] input)
        {
            List<Bag> bags = new List<Bag>();

            foreach (string entry in input)
            {
                List<string> words = entry.Split(" ").ToList();
                words = words.Where(str => !str.Contains("bag") &&
                    !str.Contains("contain") &&
                    !str.Equals("other") &&
                    !str.Equals("no")).ToList();

                bags.Add(BuildBag(words, bags, input));
            }

            return bags;
        }

        internal static Bag BuildBag(List<string> words, List<Bag> bags, string[] input)
        {
            Bag bag = new Bag();

            for (int i = 0; i < words.Count; i++)
            {
                if (i == 0)
                {
                    bag.Color += $"{words[i]} {words[++i]}";
                }

                if (int.TryParse(words[i], out int bagCount))
                {
                    string color = $"{words[++i]} {words[++i]}";
                    AddToBagList(color, bags, input);
                }
            }

            return bag;
        }

        internal static void AddToBagList(string color, List<Bag> existingBags, Bag bag)
        {

            if (existingBag != null)
            {
                bag.Contents.Add(existingBag);
            }
            else
            {
                bag.Contents.Add
                (
                    new Bag()
                    {
                        Color = color
                    }
                );
            }
        }

        internal static bool RecurseThroughBag(Bag bag, int countedBags = 0)
        {
            if (bag.Color == "shiny gold" && countedBags > 0)
            {
                return true;
            }

            foreach (Bag containedBag in bag.Contents)
            {
                countedBags++;
                if (RecurseThroughBag(containedBag, countedBags))
                {
                    return true;
                }
            }

            return false;
        }

        internal static void CreateBagStore(List<string> words, string[] input, List<Bag> existingBags)
        {
            foreach (string item in words)
            {
                if (!existingBags)
            }
        }
    }
}
