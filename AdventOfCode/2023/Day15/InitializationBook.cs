using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Kernel;
using Kernel;

namespace AdventOfCode._2023.Day15
{
    [Challenge("Lens Library", "2023/Day15/input.txt")]
    public class InitializationBook : IChallenge
    {
        public object SolvePartOne(string input)
        {
            return input.Split(",").Sum(Hash);
        }

        public object SolvePartTwo(string input)
        {
            throw new NotImplementedException();
        }

        public int Hash(string input)
        {
            return (
                from chr in Enumerable.Range(0, input.Length)
                select (int)input[chr]
            ).Aggregate(0,(hashValue, next) => hashValue = ((hashValue + next) * 17) % 256);
        }
    }
}
