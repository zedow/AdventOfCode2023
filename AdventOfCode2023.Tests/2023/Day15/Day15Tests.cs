using AdventOfCode._2023.Day15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests._2023.Day15
{
    public class Day15Tests
    {
        [Test]
        public void Hash_should_return_a_number_below_256()
        {
            string input = "HASH";

            var book = new InitializationBook();

            Assert.That(book.Hash(input), Is.EqualTo(52));
        }

        [Test]
        public void Solve_part_one_should_return_hash_sequence_and_return_total()
        {
            var input = File.ReadAllText("../../../2023/Day15/inputTest.txt");

            var book = new InitializationBook();

            Assert.That((int)book.SolvePartOne(input), Is.EqualTo(1320));
        }
    }
}
