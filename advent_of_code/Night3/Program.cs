using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

[assembly: InternalsVisibleToAttribute("Night3.Test")]
namespace Night3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> slopes = new List<List<int>>
            { 
                new List<int>(){ 1, 1 }, 
                new List<int>(){ 3, 1 }, 
                new List<int>{ 5, 1 }, 
                new List<int>{ 7, 1 }, 
                new List<int>{ 1, 2 } 
            };

            int product = 1;

            foreach (List<int> slope in slopes)
            {
                List<List<string>> input = ParseInput(args[0]);
                string[,] map = ConvertToArray(input);

                int treesHit = GetTreesHit(map, slope);
                Console.WriteLine($"Trees hit: {GetTreesHit(map, slope)}");
                product *= treesHit;
            }

            Console.WriteLine($"Total product: {product}");
        }

        internal static List<List<string>> ParseInput(string input)
        {
            List<List<string>> formattedInput = new List<List<string>>();
            char[] inputCharacters = input.ToCharArray();

            List<string> currentLine = new List<string>();
            foreach(char character in inputCharacters)
            {
                if (!character.Equals(','))
                {
                    currentLine.Add(character.ToString());
                }
                else
                {
                    formattedInput.Add(currentLine);
                    currentLine = new List<string>();
                }
            }

            return formattedInput;
        }

        internal static string[,] ConvertToArray(List<List<string>> input)
        {
            int rows = input.Count();
            int columns = input[0].Count();

            string[,] map = new string[ rows, columns ];

            int currentRow = 0;
            int currentColumn = 0;

            for (int i = 0; i < input.Count; i++)
            {
                foreach (string item in input[i])
                {
                    map[currentRow, currentColumn] = item;
                    currentColumn++;
                }

                currentColumn = 0;
                currentRow++;
            }

            return map;
        }

        internal static List<List<string>> ConvertToList(string [,] input)
        {
            int currentRow = 0;
            int currentColumn = 0;
            List<List<string>> map = new List<List<string>>();

            for (int i = 0; i < input.GetLength(0); i++)
            {
                List<string> row = new List<string>();
                while(currentColumn < input.GetLength(1))
                {
                    row.Add(input[currentRow, currentColumn]);
                    currentColumn++;
                }

                map.Add(row);
                currentColumn = 0;
                currentRow++;
            }

            return map;
        }

        internal static int GetTreesHit(string[,] map, List<int> slope)
        {
            int currentRow = 0;
            int currentColumn = 0;
            int treeCount = 0;

            while (currentRow < map.GetLength(0))
            {
                while (currentColumn < map.GetLength(1))
                {
                    string currentItem = map[currentRow, currentColumn];
                    if (currentItem.Equals("#"))
                    {
                        treeCount++;
                    }

                    currentColumn += slope[0] ;
                    currentRow += slope[1];

                    if (currentRow >= map.GetLength(0))
                    {
                        break;
                    }
                }

                map = ExtendRows(map);
            }

            return treeCount;
        }

        internal static string[,] ExtendRows(string[,] map)
        {
            List<List<string>> extendedMap = new List<List<string>>();
            List<List<string>> convertedMap = ConvertToList(map);

            foreach(List<string> row in convertedMap)
            {
                extendedMap.Add(ExtendRow(row));
            }

            return ConvertToArray(extendedMap);
        }

        internal static List<string> ExtendRow(List<string> line)
        {
            List<string> extendedLine = new List<string>();

            for (int i = 0; i < 2; i++)
            {
                foreach (string item in line)
                {
                    extendedLine.Add(item);
                }
            }

            return extendedLine;
        }
    }
}
