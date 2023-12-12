using AdventOfCode.Kernel;
using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode._2023.Day12
{
    [Challenge("Hot springs", "2023/Day12/input.txt")]
    public class HotSprings : IChallenge
    {
        public object SolvePartOne(string input)
        {
            var arrayInput = input.Split("\n");
            return 0;
        }

        public object SolvePartTwo(string input)
        {
            throw new NotImplementedException();
        }

        public int FindAnyArrangementsRecursively(char[] row,int[] damaged, int startIndex, int rowIndex, List<int> placed)
        {
            Console.WriteLine(new string(row) + " | [" + string.Join(string.Empty, damaged.Select(d => d.ToString() + ",")) + "] | " + startIndex + " | " + rowIndex);
            var currentRowIndex = rowIndex;
            char[] currentRow = (char[])row.Clone();
            var hasToCheck = true;
            for (int i = 0; i < damaged[startIndex]; i++)
            {
                if (currentRow[rowIndex + i] == '.' || (currentRow[rowIndex + i] == '#' && placed.Contains(rowIndex + i)))
                {
                    hasToCheck = false;
                    break;
                }
                currentRow[rowIndex + i] = '#';
                placed.Add(rowIndex + i);
            }
            if (hasToCheck && IsValid(currentRow,damaged))
            {
                if (startIndex == damaged.Length - 1)
                    return 1;
                else
                    return FindAnyArrangementsRecursively(currentRow, damaged, startIndex + 1, 0, placed);
            }

            if (currentRowIndex + damaged[startIndex] < row.Length)
                return FindAnyArrangementsRecursively(row, damaged, startIndex, currentRowIndex + 1, placed);

            return 0;
        }

        public bool IsValid(char[] rowState, int[] damaged)
        {
            var asString = new string(rowState);
            var regexPattern = "(-?\\#{1,32} ?)";
            var matches = Regex.Matches(asString, regexPattern);
            if (matches.Any(m => damaged.Any(d => d == m.Length) == false) || matches.Count() > damaged.Length)
                return false;
 
            foreach(var damage in damaged)
            {
                if (matches.Count(m => m.Value.Length == damage) > damaged.Count(d => d == damage))
                    return false;
            }

            return true;
        }

    }
}
