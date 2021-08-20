using System;
using static System.Console;
using static Numbers.Lib.ToEnglish;

namespace EnglishNumber.App
{
    class Program
    {
        static void Main(string[] args) {
            /* Tests(); */

            if (args.Length > 0 && int.TryParse(args[0], out int number)) {
                WriteLine(Convert(number));
            } else {
                WriteLine("not a number or number too large.");
            }
        }

        static void Tests() {
            int[] values = new int[] {
                1, 11, 111, 1111, 11111, 111111, 1111111, 11111111
            };

            foreach (int i in values) {
                WriteLine($"{i} = {Convert(i)}");
            }
        }
    }
}
