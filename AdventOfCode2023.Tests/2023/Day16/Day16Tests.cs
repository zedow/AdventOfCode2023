using AdventOfCode._2023.Day16;
using AdventOfCode2023Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests._2023.Day16
{
    public class Day16Tests
    {
        [Test]
        public void PropagateBeam_should_build_map()
        {
            var input = File.ReadAllText("../../../2023/Day16/inputTest.txt");

            var lava = new Lava();
            var map = lava.ParseMap(input.Split("\r\n"));
            var beamMap = lava.ParseMap(input.Split("\r\n"));
            beamMap[new Complex(0, 0)] = '#';
            lava.SpreadBeamRecursively(map, Lava.Right,new Complex(0,0), new List<Itenerary>());
            lava.Display(beamMap);
            Console.WriteLine("");
            lava.Display(map);
            Assert.That(beamMap.Count(k => k.Value == '#'),Is.EqualTo(46));
        }
    }
}
