using AdventOfCode2023Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeDay2;

namespace AdventOfCode2023.Tests
{
    public class Day2Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Should_parse_sets_from_a_game_with_nombers_of_green_blue_and_red_cubes_used_in_each_set()
        {
            Game game = new Game();

            string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            List<GameSet> sets = game.ParseSets(input);

            Assert.That(sets.First().BlueCubes, Is.EqualTo(3));
        }
    }
}
