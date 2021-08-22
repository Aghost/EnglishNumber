using System;
using System.Text;
using static System.Console;

namespace EnglishNumber.App
{
    class Program
    {
        public static long[] UnitsArray = new long[] {
            1000000000000000, 1000000000000, 1000000000, 1000000, 1000, 100, 1
        };

        public static readonly string[] Singles = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        public static readonly string[] Teens = new string[] { "", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        public static readonly string[] Tens = new string[] { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety", };
        public static readonly string[] UnitNames = new string[] {"", "Thousand", "Million", "Billion", "Trillion", "Quadrillion" };

        static void Main(string[] args)
        {
            if (args.Length > 0 && long.TryParse(args[0], out long ln)) {
                char[] numbers = ln.ToString().ToCharArray();
                int counter = (numbers.Length - 1)/ 3;
                Array.Reverse(numbers);

                int[] tmp = new int[] { 0, 0, 0 };
                StringBuilder sb = new();

                for (int i = numbers.Length - 1; i >= 0; i--) {
                    tmp[i % 3] = (int)numbers[i] - 48;

                    if (i % 3 == 0) {
                        sb.Append(process_triplets(tmp[2], tmp[1], tmp[0], counter--));
                    }
                }

                WriteLine(sb);
            } else {
                WriteLine("Please enter a number...");
            }
        }

        private static string process_triplets(int x, int y, int z, int counter) {
            string unitname = UnitNames[counter];

            if (counter < 2) {
                return x == 0 ? $"{process_doubles(y, z)} {unitname} " : $"{Singles[x]}-Hundred {process_doubles(y, z)} {unitname} ";
            }

            return x == 0 ? $"{process_doubles(y, z)}{unitname} " : $"{Singles[x]}-Hundred {process_doubles(y, z)} {unitname} ";
        }

        private static string process_doubles(int x, int y) {
            return x == 1 ? Teens[y] : $"{Tens[x]}{Singles[y]}";
        }

    }
}
