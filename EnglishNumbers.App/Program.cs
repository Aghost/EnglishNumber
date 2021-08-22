using System;
using System.Text;
using static System.Console;
using static EnglishNumber.Lib.ToEnglish;

namespace EnglishNumber.App
{
    class Program
    {
        static void Main(string[] args) {
            if (args.Length > 0) {
                WriteLine(NumberToEnglish(args[0]));
            } else {
                WriteLine("No args...");
            }
        }
    }
}
