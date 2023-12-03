using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day3
{
    public class Coordinate
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Length { get; set; }

        public Coordinate(int x, int y, int length = 1)
        {
            PositionX = x;
            PositionY = y;
            Length = length;
        }

        public bool IsNeighbor(Coordinate neighbor)
        {
            if(PositionX == neighbor.PositionX || PositionX == neighbor.PositionX + 1 || PositionX == neighbor.PositionX -1)
            {
                for(int i = PositionY; i < (PositionY + Length); i++)
                {
                    // start from position -1 and end to position + length + 1 to take adjacency into account 
                    for (int y = (neighbor.PositionY - 1); y < (neighbor.PositionY + neighbor.Length + 1);y++) {
                        if (i == y)
                        {
                            return true;
                        }
                    }
                }   
            }
            return false;
        }
    }
}
