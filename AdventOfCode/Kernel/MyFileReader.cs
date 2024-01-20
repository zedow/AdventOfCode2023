using System.Text.RegularExpressions;

namespace AdventOfCode.Kernel
{
    public class MyFileReader
    {
        private static char[] _validNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public static string FindAnIntegerInAString(string str)
        {
            var stringAsArray = str.ToCharArray();
            var numberAsString = "";
            bool isANumber = false;
            for (int i = 0; i < stringAsArray.Length; i++)
            {
                if (_validNumbers.Contains(stringAsArray[i]))
                {
                    isANumber = true;
                    numberAsString += stringAsArray[i];
                }

                // break when the number has been fully parsed
                if (numberAsString != "" && isANumber == false)
                {
                    return numberAsString;
                }

                isANumber = false;
            }
            return numberAsString;
        }

        public static List<string> ParseDigitsFromString(string input)
        {
            string pattern = @"(\d{1,1} ?)";
            return Regex.Matches(input, pattern).Select(match => match.Value).ToList();
        }

        public static List<string> ParseDigitsInletters(string input)
        {
            string pattern = @"(one|two|three|four|five|six|seven|eight|nine)";
            return Regex.Matches(input, pattern).Select(match => match.Value).ToList();
        }

        public static List<int> ParseIntegers(string input)
        {
            string pattern = @"(-?\d{1,32} ?)";
            var list = new List<int>();
            foreach(Match match in Regex.Matches(input, pattern))
            {
                list.Add(int.Parse(match.Value));
            }
            return list;
        }

        public static List<long> ParseLongsFromStringInputUsingRegex(string input)
        {
            string pattern = @"(-?\d{1,32} ?)";
            var list = new List<long>();
            foreach (Match match in Regex.Matches(input, pattern))
            {
                list.Add(long.Parse(match.Value));
            }
            return list;
        }
    }
}