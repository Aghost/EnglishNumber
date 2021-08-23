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
                WriteLine("No args... running tests");
                Test();
            }
        }

        static void Test() {
            string[] stray = new string[] {
                "1", "10", "123", "12345", "123456", "1234567", "123456789", "1234567891011121314151617181920"
            };

            foreach (string str in stray)
                WriteLine($"\n{str}\n{NumberToEnglish(str)}");
        }
    }
}
