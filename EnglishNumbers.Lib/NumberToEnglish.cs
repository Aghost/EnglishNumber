using System;
using System.Text;

namespace EnglishNumber.Lib
{
    public class ToEnglish
    {
        private static readonly string[] Singles = new string[] { "", "One", "Two", "Three", "Four",
                                                                "Five", "Six", "Seven", "Eight", "Nine" };

        private static readonly string[] Teens = new string[] { "", "Eleven", "Twelve", "Thirteen", "Fourteen",
                                                                "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        private static readonly string[] Tens = new string[] { "", "Ten", "Twenty", "Thirty", "Forty",
                                                                "Fifty", "Sixty", "Seventy", "Eighty", "Ninety", };

        private static readonly string[] UnitNames = new string[] { "", "Thousand", "Million", "Billion", "Trillion",
                                                                    "Quadrillion", "Quintillion" };

        public static string NumberToEnglish(string str) {
            if (ulong.TryParse(str, out ulong ln)) {
                char[] numbers = ln.ToString().ToCharArray();
                Array.Reverse(numbers);
                int counter = (numbers.Length - 1) / 3;

                int[] tmp = new int[] { 0, 0, 0 };
                StringBuilder sb = new();

                for (int i = numbers.Length - 1; i >= 0; i--) {
                    tmp[i % 3] = (int)numbers[i] - 48;

                    if (i % 3 == 0) {
                        sb.Append(process_triplets(tmp[2], tmp[1], tmp[0], counter--));
                    }
                }

                return sb.ToString();
            } else {
                return "Please enter a number...";
            }
        }

        private static string process_triplets(int x, int y, int z, int counter) {
            return x == 0 ?  $"{process_doubles(y, z)} {UnitNames[counter]} " :
                $"{Singles[x]}-Hundred {process_doubles(y, z)} {UnitNames[counter]} ";
        }

        private static string process_doubles(int x, int y) {
            return x == 1 ? Teens[y] :
                $"{Tens[x]}{Singles[y]}";
        }

    }
}
