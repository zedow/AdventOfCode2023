using AdventOfCode._2023.Day21;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests._2023.Day21
{
    internal class Day21Tests
    {
        [Test]
        public void FindPaths_should_return_16()
        {
            var input = File.ReadAllText("../../../2023/Day21/input.txt");
            var stepCounter = new StepCounter();
            var map = stepCounter.ParseMap(input);

            var numberOfGardenPlotsReach = stepCounter.FindPaths(map, 6);

            // because Elf can reach 16 distinct garden plots, bearing in mind that he may be backtracking
            Assert.That(numberOfGardenPlotsReach, Is.EqualTo(16));
        }
    }
}
