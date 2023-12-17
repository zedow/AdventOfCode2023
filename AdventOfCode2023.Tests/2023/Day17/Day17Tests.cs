using AdventOfCode._2023.Day17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests._2023.Day17
{
    internal class Day17Tests
    {
        [Test]
        public void SolvePartOne_should_return_102()
        {
            var input = File.ReadAllText("../../../2023/Day17/inputTest.txt");

            var crudible = new Crudible();

            Assert.That((int)crudible.SolvePartOne(input),Is.EqualTo(102));
        }

        [Test]
        public void SolvePartTwo_should_return_94()
        {
            var input = File.ReadAllText("../../../2023/Day17/inputTest.txt");

            var crudible = new Crudible();

            Assert.That((int)crudible.SolvePartTwo(input), Is.EqualTo(94));
        }
    }
}
