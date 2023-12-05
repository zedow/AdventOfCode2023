using System.Text.RegularExpressions;

namespace Kernel
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

        public static List<int> ParseIntegersFromStringInputUsingRegex(string input)
        {
            string pattern = @"(\d{1,9} ?)";
            var list = new List<int>();
            foreach(Match match in Regex.Matches(input, pattern))
            {
                list.Add(int.Parse(match.Value));
            }
            return list;
        }
    }
}