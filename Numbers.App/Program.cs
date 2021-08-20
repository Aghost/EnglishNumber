using System;
using static System.Console;
using static Numbers.Lib.ToEnglish;

namespace Numbers.App
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0) {
                foreach (string str in args) {
                    if (long.TryParse(str, out long l)) {
                        WriteLine(ConvertToDigit(l));
                    }
                }
            } else {
                WriteLine("pls provide args...");
            }
        }
    }
}
