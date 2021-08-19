using System;
using System.Collections.Generic;

namespace EnglishNumber.Lib
{
    public static class NumbersToEnglish
    {
        public static string[] EnglishDigits = new string[] {
            "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ", "Ten ",
            "Eleven ", "Twelve ", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        public static string[] EnglishTens = new string[] {
            "", "", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety "
        };

        public static Dictionary<int, string> NumbersToPlace = new Dictionary<int, string> {
            {100, "Hundred "}, {1000, "Thousand, "}, {1000000, "Million, "}, {1000000000, "Billion, "}
        };


        public static string ConvertToDigit(int n, string _suffix) {
            if (n == 0) {
                return "";
            }

            return n > 19 ? EnglishTens[n / 10] + EnglishDigits[n % 10] + _suffix : EnglishDigits[n] + _suffix;
        }

        public static string Convert(int n) {
            string res;

            res = ConvertToDigit(n % 100, "");

            if (n > 100 && n % 100 >= 1) {
                res = "and " + res;
            }

            foreach (var kvp in NumbersToPlace) {
                res = ConvertToDigit((n / kvp.Key % 100), kvp.Value) + res;
            }

            return res;
        }
    }
}
