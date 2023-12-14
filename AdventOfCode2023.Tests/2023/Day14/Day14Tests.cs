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
        public void Should_return_rounded_rocks_load_tilting_dish_left()
        {
            var input = File.ReadAllText("../../../2023/Day14/testInput.txt");
            var dish = new Dish();

            var totalLoad = dish.MoveRoundedRocks(dish.ParseMap(input), Dish.Up);
            var LeftLoad = dish.MoveRoundedRocks(dish.ParseMap(input), Dish.Left);
            var downLoad = dish.MoveRoundedRocks(dish.ParseMap(input), Dish.Down);
            var rightLoad = dish.MoveRoundedRocks(dish.ParseMap(input), Dish.Right);
            Assert.That(totalLoad, Is.EqualTo(136));
            Assert.That(LeftLoad, Is.EqualTo(132));
            Assert.That(downLoad, Is.EqualTo(103));
            Assert.That(rightLoad, Is.EqualTo(106));
        }

        [Test]
        public void Should_return_rounded_rocks_load_tilting_dish_leftee()
        {
            var input = File.ReadAllText("../../../2023/Day14/testInput.txt");
            var dish = new Dish();

            var totalLoad = dish.MoveRoundedRocks(dish.ParseMap(input), Dish.Up);
            var LeftLoad = dish.MoveRoundedRocks(dish.ParseMap(input), Dish.Left);
            var downLoad = dish.MoveRoundedRocks(dish.ParseMap(input), Dish.Down);
            var rightLoad = dish.MoveRoundedRocks(dish.ParseMap(input), Dish.Right);
            Assert.That(totalLoad, Is.EqualTo(19));
            Assert.That(LeftLoad, Is.EqualTo(14));
            Assert.That(downLoad, Is.EqualTo(17));
            Assert.That(rightLoad, Is.EqualTo(18));
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
