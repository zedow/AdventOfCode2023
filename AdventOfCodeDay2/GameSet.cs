using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay2
{
    public class GameSet
    {
        public GameSet(int blueCubes, int redCubes, int greenCubes)
        {
            BlueCubes = blueCubes;
            RedCubes = redCubes;
            GreenCubes = greenCubes;
        }

        public GameSet() { }

        public int BlueCubes {  get; set; }
        public int RedCubes { get; set; }
        public int GreenCubes { get; set; }
    }
}
