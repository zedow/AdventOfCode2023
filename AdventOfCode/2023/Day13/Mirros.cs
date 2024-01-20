using AdventOfCode.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2023.Day13
{
    [Challenge("Point of Incidence", "2023/Day13/input.txt")]
    public class Mirros : IChallenge
    {
        public object SolvePartOne(string input)
        {
            var inputArray = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
            return inputArray
            .Select(x =>
            {
                var pattern = x.Split("\n");
                var columns = ParseColumns(pattern.Select(i => i.Trim()).ToArray());
                var rows = pattern.Select(i => i.Trim()).ToArray();
                var columnsReflections = CountReflectionRecursively(columns, 0);
                var rowsReflections = CountReflectionRecursively(rows, 0);
                return ((rowsReflections / 2) + rowsReflections % 2) * 100 + ((columnsReflections / 2) + columnsReflections % 2);
            }).Sum();
        }

        public object SolvePartTwo(string input)
        {
            throw new NotImplementedException();
        }


        /// <returns>
        /// Item1 is the number of columns/rows reflected, that means Item1 / 2 = number of reflections
        /// Item2 is the number of columns/rows count from the mirror to the index 0
        /// </returns>
        public int CountReflectionRecursively(string[] input, int index)
        {
            int counter = 0;
            if (index + 1 >= input.Length)
                return 0;

            if (input[index].ToList().SequenceEqual(input[index + 1]))
            {
                return 1;
            }
            counter += CountReflectionRecursively(input, index + 1);
            if ((index + counter + 2 >= input.Length || input[index] == input[index + counter + 2]) && counter > 0)
            {
                return counter + 2;
            }
            else
                return 0;
        }

        public string[] ParseColumns(string[] input)
        {
            string[] toReturn = new string[input[0].Length];
            for(int icol = 0; icol < input[0].Length; icol++)
            {
                toReturn[icol] = "";
                for (int irow = 0; irow < input.Length; irow++)
                {
                    toReturn[icol] += input[irow][icol];
                }
            }

            return toReturn;
        }
    }
}
