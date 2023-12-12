using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Kernel
{
    public interface IChallenge
    {
        public object SolvePartOne(string input);
        public object SolvePartTwo(string input);
    }
}
