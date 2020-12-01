using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

[assembly: InternalsVisibleToAttribute("Night1.Test")]
namespace Night1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Array.ConvertAll(args, s => int.Parse(s));
            Console.WriteLine(GetProduct(numbers));
        }

        internal static int GetProduct(int[] args)
        {
            foreach (int number in args)
            {
                int result = CheckCase(number, args);

                if (result != 1)
                {
                    return result;
                }
            }

            return 1;
        }

        internal static int CheckCase(int startingNumber, int[] args)
        {
            foreach (int nextNumber in args)
            {
                int comparisonSum = startingNumber + nextNumber;
                bool result = Compare(comparisonSum, args, out int finalNumber);

                if (result)
                {
                    return startingNumber * nextNumber * finalNumber;
                }
            }

            return 1;
        }

        internal static bool Compare(int comparisonSum, int[] args, out int finalNumber)
        {
            for (int i=0; i < args.Length; i++)
            {
                int comparisonNumber = args[i];

                if (SumIs2020(new int[] { comparisonSum, comparisonNumber }))
                {
                    finalNumber = comparisonNumber;
                    return true;
                }
            }

            finalNumber = 0;
            return false;
        }

        internal static bool SumIs2020(int[] numbers)
        {
            return numbers.Sum() == 2020;
        }
    }
}
