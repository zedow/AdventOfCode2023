using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day1
{
    public class Calibration
    {
        private List<string> _digitsInLetter = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        public int Calibrate(string input)
        {
            char first = input.First(ch => int.TryParse(ch.ToString(), out var firstInt) == true);
            char last = input.Last(ch => int.TryParse(ch.ToString(), out var lastInt) == true);
            return int.Parse(first.ToString() + last.ToString());
        }

        public string ReplaceDigitsInletterByDigits(string input)
        {
            var digitsInLetter = MyFileReader.ParseDigitsInletters(input);
            foreach(var digitInletter in digitsInLetter)
            {
                if (input.IndexOf(digitInletter) == -1)
                    continue;

                input = input.Replace(digitInletter, (_digitsInLetter.FindIndex(l => l == digitInletter) + 1).ToString());
            }
            return input;
        }
    }
}
