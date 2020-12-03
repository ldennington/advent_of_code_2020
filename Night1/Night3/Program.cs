using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Night3.Test")]
namespace Night3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> input = ParseInput(args[0]);
            string[,] map = ConvertToArray(input);
            Console.WriteLine($"Trees hit: {GetTreesHit(map)}");
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

        internal static int GetTreesHit(string[,] map)
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

                    currentColumn += 3;
                    currentRow += 1;

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
