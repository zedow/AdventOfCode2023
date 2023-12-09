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
        private string _digits = "123456789";
        public int Calibrate(string input)
        {
            char first = input.First(ch => int.TryParse(ch.ToString(), out var firstInt) == true);
            char last = input.Last(ch => int.TryParse(ch.ToString(), out var lastInt) == true);
            return int.Parse(first.ToString() + last.ToString());
        }

        public int CalibrateDigitsInLetter(string input)
        {
            var inputArray = input.ToCharArray();
            var inputReverse = input.Reverse().ToArray();
            string? first = null;
            string? last = null;
            int indexer = 1;
            while(first == null || last == null)
            {
                string partOfInputArray = inputArray.Take(indexer).Select(ch => ch.ToString()).Aggregate((prev,next) => prev + next);
                string partOfReverseInput = inputArray.Skip(inputArray.Length - indexer).Select(ch => ch.ToString()).Aggregate((prev, next) => prev + next);
                if (first == null)
                {
                    first = FindAnyDigit(partOfInputArray);
                }
                if (last == null)
                {
                    last = FindAnyDigit(partOfReverseInput);
                }
                indexer++;
            }

            return int.Parse(first + last);
        }

        private string? FindAnyDigit(string partOfInputArray)
        {
            if (_digitsInLetter.Any(d => partOfInputArray.IndexOf(d) != -1))
            {
                return (_digitsInLetter.FindIndex(d => partOfInputArray.IndexOf(d) != -1) +1).ToString();
            }
            if (_digits.Any(d => partOfInputArray.IndexOf(d) != -1))
            {
                return _digits.First(d => partOfInputArray.IndexOf(d) != -1).ToString();
            }
            return null;
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
