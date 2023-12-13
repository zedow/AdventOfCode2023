using AdventOfCode._2023.Day12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests._2023.Day12
{
    public class Day12Tests
    {
        [TestCase("???.###", new int[] {1, 1,3}, 1)]
        [TestCase("?#?#?#?#?#?#?#?", new int[] { 1,3, 1, 6 }, 1)]
        [TestCase("?###????????", new int[] { 3, 2, 1 }, 10)]
        public void should_return_one_when_an_arrangement_is_possible(string input, int[] rules, int expectedResult)
        {
            var hotSprings = new HotSprings();

            int solutions = hotSprings.RecursivelyFindEveryPossibilities(input.ToCharArray(), rules);

            Assert.That(solutions, Is.EqualTo(expectedResult));
        }

        [Test]
        public void should_return_one_when_an_arrangement_is_possible_zebi()
        {
            var input = "?###????????";
            var hotSprings = new HotSprings();

            int solutions = hotSprings.RecursivelyFindEveryPossibilities(input.ToCharArray(), new int[] { 3, 2, 1 });

            Assert.That(solutions, Is.EqualTo(10));
        }

        [Test]
        public void SolvePartOne()
        {
            var input = @"???.### 1,1,3
.??..??...?##. 1,1,3
?#?#?#?#?#?#?#? 1,3,1,6
????.#...#... 4,1,1
????.######..#####. 1,6,5
?###???????? 3,2,1";
            var hotSprings = new HotSprings();

            int solution = (int)hotSprings.SolvePartOne(input);

            Assert.That(solution, Is.EqualTo(21));
        }
    }
}
