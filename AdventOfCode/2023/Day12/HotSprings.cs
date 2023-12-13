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
            var arrayInput = input.Split("\n").Select(i => i.Split(" "));
            return arrayInput.Select(input => 
                RecursivelyFindEveryPossibilities(
                    input[0].Trim().ToCharArray(), 
                    input[1].Trim().Split(",").Where(i => i != "").Select(i => int.Parse(i)).ToArray()
                )
            ).Sum();
        }

        public object SolvePartTwo(string input)
        {
            throw new NotImplementedException();
        }

        public int RecursivelyFindEveryPossibilities(char[] input, int[] rules)
        {
            var total = 0;
            if (input.Contains('?') == false)
            {
                bool isValid = IsValid(input, rules);
                return isValid  ? 1 : 0;
            }

            var index = 0;
            for(; index < input.Length; index++)
            {
                if (input[index] == '?')
                {
                    input[index] = '#';
                    break;
                }
            }
            total += RecursivelyFindEveryPossibilities((char[])input.Clone(), rules);
            input[index] = '.';
            total += RecursivelyFindEveryPossibilities((char[])input.Clone(), rules);
            return total;
        }

        public bool IsValid(char[] rowState, int[] rulesToPlace)
        {
            var rulesToDecrement = ((int[])rulesToPlace.Clone()).ToList();
            var asString = new string(rowState);
            var regexPattern = "(-?\\#{1,32} ?)";
            var matchs = Regex.Matches(asString, regexPattern);
            if (matchs.Count != rulesToPlace.Length)
                return false;

            for(int i = 0; i < rulesToDecrement.Count(); i++)
            {
                if (rulesToDecrement[i] != matchs.ElementAt(i).Value.Length)
                    return false;
            }

            return true;
        }

    }
}
