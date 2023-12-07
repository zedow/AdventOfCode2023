using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day7
{
    public struct Hand
    {
        public (int, int) Strength { get; set; }
        public int Bid { get; set; }
        public Hand((int, int) strength, int bid)
        {
            Strength = strength;
            Bid = bid;
        }
    }
}
