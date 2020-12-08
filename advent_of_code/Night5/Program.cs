using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Night5.Test")]
namespace Night5
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\repos\advent_of_code_2020\advent_of_code\data\night5.txt");
            List<int> seats = new List<int>();

            foreach(string item in input)
            {
                Split(item.ToCharArray(), 7, out char[] first, out char[] second);
                int row = GetRowOrColumn(new string(first), 128);
                int column = GetRowOrColumn(new string(second), 8);
                int seat = row * 8 + column;

                seats.Add(seat);
            }

            seats.Sort();
            Console.WriteLine($"My seat number: { FindMissingSeat(seats, 892) }");
        }

        internal static int GetRowOrColumn(string key, int size)
        {
            int[] items = CreateArray(size, 0);
            char[] letters = key.ToCharArray();

            foreach (char character in letters)
            {
                Split(items, items.Length / 2, out int[] first, out int[] second);
                if (character == 'F' || character == 'L')
                {
                    items = first;
                }
                else
                {
                    items = second;
                }
            }

            return items[0];
        }

        internal static int[] CreateArray(int size, int startingPoint)
        {
            List<int> rows = new List<int>();

            for(int i = startingPoint; i < size; i++)
            {
                rows.Add(i);
            }

            return rows.ToArray();
        }

        internal static void Split<T>(T[] array, int index, out T[] first, out T[] second)
        {
            first = array.Take(index).ToArray();
            second = array.Skip(index).ToArray();
        }

        internal static int FindMissingSeat(List<int> seats, int size)
        {
            int[] allSeats = CreateArray(size, seats.FirstOrDefault());
            foreach(int seat in allSeats)
            {
                if (!seats.Contains(seat))
                {
                    return seat;
                }
            }

            return 0;
        }
    }
}
