using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023Day11;

namespace AdventOfCode2023.Tests
{
    public class Day11Tests
    {
        public const string textGalaxy = 
            @"...#......
            .......#..
            #.........
            ..........
            ......#...
            .#........
            .........#
            ..........
            .......#..
            #...#.....";

        [TestCase(1,374)]
        [TestCase(9, 1030)]
        [TestCase(99, 8410)]
        public void Galaxy_Solve_should_return_expected_result_based_on_test_input(int expand, int result)
        {
            BigInteger sumOfTheShortestPathBetweenAllGalaxies = Galaxy.Solve(textGalaxy, expand);

            Assert.That(sumOfTheShortestPathBetweenAllGalaxies, Is.EqualTo((BigInteger)result));
        }
    }
}
