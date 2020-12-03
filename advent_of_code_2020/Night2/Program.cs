using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Night2.Test")]
namespace Night2
{
    public class Program
    {
        static void Main(string[] args)
        {
            args = NormalizeInput(args);
            int validPasswordCount = 0;

            foreach (string item in args)
            {
                int[] positions = GetPositions(item);

                if (CheckPosition(GetItemsToCheck(item), positions[0], positions[1]))
                {
                    validPasswordCount++;
                }
            }

            Console.WriteLine($"Valid passwords: {validPasswordCount}");
        }

        internal static string[] NormalizeInput(string[] args)
        {
            List<string> normalizedInput = new List<string>();
            string fullItem = "";

            foreach (string item in args)
            {
                if (!item.Equals(","))
                {
                    fullItem = string.Join(" ", fullItem, item);
                }
                else
                {
                    normalizedInput.Add(fullItem.Trim());
                    fullItem = "";
                }
            }

            return normalizedInput.ToArray();
        }

        internal static int[] GetPositions(string input)
        {
            string[] splitInput = input.Split(new string[] { "-", " " }, StringSplitOptions.None);

            int position1 = int.Parse(splitInput[0]);
            int position2 = int.Parse(splitInput[1]);

            return new int[] { position1, position2 };
        }

        internal static string[] GetItemsToCheck(string input)
        {
            string[] splitInput = input.Split(new string[] { " ", ":" }, StringSplitOptions.None);
            return new string[] { splitInput[1], splitInput[3] };
        }

        internal static bool CheckPosition(string[] items, int position1, int position2)
        {
            char[] characters = items[1].ToCharArray();

            bool isInPosition1 = DetermineIfInPosition(position1, characters, items[0]);
            bool isInPosition2 = DetermineIfInPosition(position2, characters, items[0]);

            return DetermineValidity(isInPosition1, isInPosition2);
        }

        internal static bool DetermineValidity(bool isInPosition1, bool isInPosition2)
        {
            bool isValid = false;

            if (isInPosition1 || isInPosition2)
            {
                isValid = true;
            }

            if (isInPosition1 && isInPosition2)
            {
                isValid = false;
            }

            return isValid;
        }

        internal static bool DetermineIfInPosition(int position, char[] characters, string item)
        {
            if (position < characters.Length || position == characters.Length)
            {
                position -= 1;

                if (characters[position].ToString().Equals(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
