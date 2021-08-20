using System;
using System.Text;
using System.Collections.Generic;

namespace Numbers.Lib
{
    public static class ToEnglish
    {
        public static readonly string[] Singles = new string[] {
            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
        };

        public static readonly string[] Teens = new string[] {
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        public static readonly string[] Tens = new string[] {
            "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        public static string ConvertToDigit(long n) {
            if (n <= 0) 
                return "";

            StringBuilder sb = new();

            long left_to_write = n;
            long write_now = 0;

            //QUANTILLIONS
            write_now = left_to_write / 1000000000000000000;
            left_to_write = left_to_write - write_now * 1000000000000000000;

            if (write_now > 0) {
                sb.Append($"{ConvertToDigit(write_now)} Quintillion ");
            }

            //QUADRILLIONS
            write_now = left_to_write / 1000000000000000;
            left_to_write = left_to_write - write_now * 1000000000000000;

            if (write_now > 0) {
                sb.Append($"{ConvertToDigit(write_now)} Quadrillion ");
            }

            //TRILLIONS
            write_now = left_to_write / 1000000000000;
            left_to_write = left_to_write - write_now * 1000000000000;

            if (write_now > 0) {
                sb.Append($"{ConvertToDigit(write_now)} Trillion ");
            }

            //BILLIONS
            write_now = left_to_write / 1000000000;
            left_to_write = left_to_write - write_now * 1000000000;

            if (write_now > 0) {
                sb.Append($"{ConvertToDigit(write_now)} Billion ");
            }

            //MILLIONS
            write_now = left_to_write / 1000000;
            left_to_write = left_to_write - write_now * 1000000;

            if (write_now > 0) {
                sb.Append($"{ConvertToDigit(write_now)} Million ");
            }

            //THOUSANDS
            write_now = left_to_write / 1000;
            left_to_write = left_to_write - write_now * 1000;

            if (write_now > 0) {
                sb.Append($"{ConvertToDigit(write_now)} Thousand ");
            }

            //HUNDREDS
            write_now = left_to_write / 100;
            left_to_write = left_to_write - write_now * 100;

            if (write_now > 0) {
                sb.Append($"{ConvertToDigit(write_now)} Hundred ");
                if (left_to_write > 0) {
                    sb.Append("and ");
                }
            }

            //TENS
            write_now = left_to_write / 10;
            left_to_write = left_to_write - write_now * 10;

            if (write_now > 0) {
                if (write_now == 1 && left_to_write > 0) {
                    sb.Append(Teens[left_to_write -1]);
                    left_to_write = 0;
                } else {
                    sb.Append(Tens[write_now -1]);
                }

                if (left_to_write > 0) {
                    sb.Append("-");
                }
            }

            //ONES
            write_now = left_to_write;
            left_to_write = 0;

            if (write_now > 0) {
                sb.Append(Singles[write_now -1]);
            }

            return sb.ToString();
        }
    }
}
