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
            char[] digits = str.ToCharArray();
            if (digits[0] == '0') return "no fractions!";

            int digits_index = digits.Length - 1;
            int unitscounter = digits_index / 3;

            StringBuilder sb = new();

            int[] tmp = new int[] { 0, 0, 0 };

            for (int i = digits_index; i >= 0; i--) {
                tmp[i % 3] = digits[digits_index - i] - 48; // % 10; // To make it input Character safe

                if (i % 3 == 0) {
                    sb.Append(process_triplet(tmp[2], tmp[1], tmp[0], unitscounter--));
                }
            }

            /*
            for (int i = 0; i < digits.Length; i++) {
                tmp[i % 3] = digits[i] - 48;

                if (i % 3 == 2) {
                    sb.Append(process_triplet(tmp[0], tmp[1], tmp[2], unitscounter--));
                }
            }
            */

            return sb.ToString();
        }

        private static string process_triplet(int x, int y, int z, int uc) {
            return x == 0 ?  $"{process_doubles(y, z)} {UnitNames[uc]} " :
                $"{Singles[x]} Hundred {process_doubles(y, z)} {UnitNames[uc]} ";
        }

        private static string process_doubles(int x, int y) {
            return x == 1 ? Teens[y] : $"{Tens[x]}{Singles[y]}";
        }

    }
}
