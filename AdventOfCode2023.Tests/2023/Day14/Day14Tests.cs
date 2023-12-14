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
        public void ParseMap_should_return_an_string_array_of_input_columns()
        {
            var input = File.ReadAllText("../../../2023/Day14/testInput.txt");

            var dish = new Dish();
            var map = dish.ParseMap(input);

            Assert.That(map[0], Is.EqualTo("OO.O.O..##"));
        }

        [Test]
        public void Should_return_test_map_load()
        {
            var input = File.ReadAllText("../../../2023/Day14/testInput.txt");

            var dish = new Dish();
            var totalLoad = dish.LoopMapReturnTotalLoad(dish.ParseMap(input));

            Assert.That(totalLoad, Is.EqualTo(136));
        }
    }
}
