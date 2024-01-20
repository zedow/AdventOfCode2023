using AdventOfCode.Kernel;
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
            var arrayInput = input.Split("\n").Select(i => i.Split(" "));
            long sum = 0;
            foreach(var row in arrayInput)
            {
                var springs = row[0];
                var rules = row[1];
                sum += Convert.ToInt64(GetFiveUnfoldsArrangements(springs,
                    rules.Split(",").Where(i => i != "").Select(int.Parse).ToArray()));
            }

            return sum;
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


        // On utilise ici la progression géométrique avec un calcul de facteur de croissance
        public double GetFiveUnfoldsArrangements(string input, int[] rules)
        {
            var firstRun = RecursivelyFindEveryPossibilities(input.ToArray(), rules);
            var secondRun = RecursivelyFindEveryPossibilities((input + "?").ToArray(), rules);
            // le facteur de croissance est égal au nombre de possibilités après la première croissance divisé par le nombre de possibilité avec 0 croissance
            var growthFactor = secondRun == firstRun ? secondRun * 2 : secondRun;
            // a×r^(n-1) avec = 5 pour ce sujet
            return firstRun * Math.Pow(growthFactor, 4);
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
