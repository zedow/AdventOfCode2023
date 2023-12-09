using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day9
{
    public static class Forecast
    {
        public static int GetValueFromHistory(string input)
        {
            var integers = ParseInput(input);
            return PlayForecast(integers);
        }

        private static int[] ParseInput(string input)
        {
            var values = MyFileReader.ParseIntegersFromStringInputUsingRegex(input);
            return values.ToArray();
        }

        private static int PlayForecast(int[] integers)
        {
            if(integers.All(x => x == 0)) {
                return 0;
            }

            var newValues = new int[integers.Length -1];
            for(int i = 0; i < newValues.Length; i++)
            {
                newValues[i] = integers[i + 1] - integers[i];
            }

            return PlayForecast(newValues) + integers[integers.Length - 1];
        }
    }
}
