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
            Assert.That(sets.First().RedCubes, Is.EqualTo(4));
        }

        [Test]
        public void Should_return_the_highest_number_found_for_each_color_among_the_sets()
        {
            Game game = new Game();

            string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            List<GameSet> sets = game.ParseSets(input);
            game.SethighestNumberFromSets(sets);

            Assert.That(game.HighestBlueCubes, Is.EqualTo(6));
            Assert.That(game.HighestRedCubes, Is.EqualTo(4));
            Assert.That(game.HighestGreenCubes, Is.EqualTo(2));
        }

        [Test]
        public void Should_return_true_when_game_can_be_played_with_a_given_bag()
        {
            Game game = new Game();

            string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            game.GameSets = game.ParseSets(input);

            Assert.That(game.CanGameBePlayedWithTheGivenBag(7, 6, 6),Is.EqualTo(true));
            Assert.That(game.GameId, Is.EqualTo(1));
        }

        [Test]
        public void Should_return_false_when_the_game_cant_be_played_with_the_given_bag()
        {
            Game game = new Game();

            string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            game.ParseSets(input);

            Assert.That(game.CanGameBePlayedWithTheGivenBag(5, 6, 6), Is.EqualTo(false));
            Assert.That(game.GameId, Is.EqualTo(1));
        }

        [Test]
        public void Should_return_the_power_of_the_set_that_should_be_played_to_make_the_game_possible()
        {
            Game game = new Game();

            string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            game.ParseSets(input);
            game.SethighestNumberFromSets(game.GameSets);
            int highestBlueNumberRequiredToPlayTheGame = game.HighestBlueCubes;
            int highestRedNumberRequiredToPlayTheGame = game.HighestRedCubes;
            int highestGreenNumberRequiredToPlayTheGame = game.HighestGreenCubes;
            int totalPower = highestBlueNumberRequiredToPlayTheGame * highestRedNumberRequiredToPlayTheGame * highestGreenNumberRequiredToPlayTheGame;

            Assert.That(totalPower,Is.EqualTo(48));
        }
    }
}
