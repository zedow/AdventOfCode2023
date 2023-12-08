using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day8
{
    public struct Node
    {
        public string Left { get; set; }
        public string Right { get; set; }

        public Node(string left, string right)
        {
            Left = left;
            Right = right;
        }
    }
}
