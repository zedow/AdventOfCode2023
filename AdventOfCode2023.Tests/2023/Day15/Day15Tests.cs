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
        [TestCase("rn", 0)]
        [TestCase("cm", 0)]
        [TestCase("qp", 1)]
        [TestCase("pc", 3)]
        [TestCase("HASH", 52)]
        [TestCase("hll", 0)]
        public void Hash_should_return_a_number_below_256(string input, int result)
        {
            var book = new InitializationBook();

            Assert.That(book.Hash(input), Is.EqualTo(result));
        }

        [Test]
        public void Solve_part_one_should_hash_sequence_and_return_total()
        {
            var input = File.ReadAllText("../../../2023/Day15/inputTest.txt");

            var book = new InitializationBook();

            Assert.That((int)book.SolvePartOne(input), Is.EqualTo(1320));
        }

        [Test]
        public void Solve_part_two_should_return_sum_of_lens_focusing_power()
        {
            var input = File.ReadAllText("../../../2023/Day15/inputTest.txt");

            var book = new InitializationBook();

            Assert.That((int)book.SolvePartTwo(input), Is.EqualTo(145));
        }

        [Test]
        public void Operate_should_replace_lens_value_when_it_is_already_in_the_box()
        {
            Dictionary<int, List<Lens>> hashMap = new Dictionary<int, List<Lens>>
            {
                { 0, new List<Lens>() }
            };
            hashMap[0].Add(new Lens(1,"rn"));
            var book = new InitializationBook();

            book.Operate(hashMap, "rn=2");

            Assert.That(hashMap[0][0].Length, Is.EqualTo(2));
        }

        [Test]
        public void Operate_should_add_lens_to_box_when_box_doesnt_contain_it()
        {
            Dictionary<int, List<Lens>> hashMap = new Dictionary<int, List<Lens>>();
            var book = new InitializationBook();

            book.BuildBoxes(hashMap, 256);
            book.Operate(hashMap, "jqfl=7");

            Assert.That(hashMap[book.Hash("jqfl")][0].Length, Is.EqualTo(7));
        }

        [Test]
        public void Operate_should_remove_lens_if_it_is_in_the_box()
        {
            Dictionary<int, List<Lens>> hashMap = new Dictionary<int, List<Lens>>();
            var book = new InitializationBook();
            book.BuildBoxes(hashMap, 256);
            book.Operate(hashMap, "jqfl=7");

            book.Operate(hashMap, "jqfl-");

            Assert.That(hashMap[book.Hash("jqfl")].FindIndex(l => l.Name == "jqfl"), Is.EqualTo(-1));
        }
    }
}
