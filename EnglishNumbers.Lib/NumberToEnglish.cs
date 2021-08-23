using System;
using System.Text;

namespace EnglishNumber.Lib
{
    public class ToEnglish
    {
        private static readonly string[] Singles = new string[] { "", "One", "Two", "Three", "Four",
                                                                "Five", "Six", "Seven", "Eight", "Nine" };

        private static readonly string[] Teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
                                                                "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        private static readonly string[] Tens = new string[] { "", "Ten", "Twenty", "Thirty", "Forty",
                                                                "Fifty", "Sixty", "Seventy", "Eighty", "Ninety", };

        private static readonly string[] UnitNames = new string[] { "", "Thousand", "Million", "Billion", "Trillion",
                                                                    "Quadrillion", "Quintillion", "Sextillion", "Septillion", "Octillion",
                                                                    "Nonillion", "Decillion", "Undecillion", "Duodecillion", "Tredecillion",
                                                                    "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septendecillion", "Octodecillion",
                                                                    "Novemdecillion", "Vigintillion" };

        public static string NumberToEnglish(string str) {
            char[] numbers = str.ToCharArray();
            int strlen = numbers.Length - 1;
            int counter = strlen / 3;
            int[] tmp = new int[] { 0, 0, 0 };
            StringBuilder sb = new();

            for (int i = strlen; i >= 0; i--) {
                tmp[i % 3] = (numbers[strlen - i] - 48); // % 10; // To make it input Character safe

                if (i % 3 == 0) {
                    sb.Append(process_triplets(tmp[2], tmp[1], tmp[0], counter--));
                }
            };

            return sb.ToString();;
        }

        private static string process_triplets(int x, int y, int z, int counter) {
            return x == 0 ?  $"{process_doubles(y, z)} {UnitNames[counter]} " :
                $"{Singles[x]} Hundred {process_doubles(y, z)} {UnitNames[counter]} ";
        }

        private static string process_doubles(int x, int y) {
            return x == 1 ? Teens[y] : $"{Tens[x]}{Singles[y]}";
        }

    }
}
