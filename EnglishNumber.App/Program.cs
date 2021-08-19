using System;
using static System.Console;
using static EnglishNumber.Lib.NumbersToEnglish;

namespace EnglishNumber.App
{
    class Program
    {
        static void Main(string[] args) {
            /*
                Tests();
            */

            if (args.Length > 0 && int.TryParse(args[0], out int number)) {
                WriteLine(Convert(number));
            } else {
                WriteLine("not a number.");
            }
        }

        static void Tests() {
            int[] values = new int[] { 1, 19, 99, 999, 1999, 19345, 123456, 12345678, 1234567890 };

            foreach (int i in values) {
                WriteLine($"{i} = {Convert(i)}");
            }
        }
    }
}
