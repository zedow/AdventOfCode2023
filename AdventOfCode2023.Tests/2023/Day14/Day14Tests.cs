using AdventOfCode._2023.Day14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests._2023.Day14
{
    public class Day14Tests
    {
        [Test]
        public void Should_return_test_map_load()
        {
            var input = File.ReadAllText("../../../2023/Day14/testInput.txt");
            var dish = new Dish();

            var totalLoad = dish.SolvePartOne(input);
            Assert.That(totalLoad, Is.EqualTo(136));
        }

        [Test]
        public void Should_return_rounded_rocks_load_part_two()
        {
            var input = File.ReadAllText("../../../2023/Day14/testInput.txt");
            var dish = new Dish();

            var totalLoad = dish.SolvePartTwo(input);
            Assert.That(totalLoad, Is.EqualTo(64));
        }
    }
}
