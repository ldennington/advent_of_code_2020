using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Night1.Test")]
namespace Night1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Array.ConvertAll(args, s => int.Parse(s));
            GetProduct(numbers);
        }

        internal static void GetProduct(int[] args)
        {
            foreach (int number in args)
            {
                int result = Compare(number, args);

                if (result != 1)
                {
                    Console.WriteLine(result);
                    return;
                }
            }
        }

        internal static int Compare(int compareNumber, int[] numbers)
        {
            for (int i=0; i < numbers.Length; i++)
            {
                if (numbers[i] == compareNumber) continue;

                if (SumIs2020(compareNumber, numbers[i]))
                {
                    return numbers[i] * compareNumber;
                }
            }

            return 1;
        }

        internal static bool SumIs2020(int num1, int num2)
        {
            return num1 + num2 == 2020;
        }
    }
}
