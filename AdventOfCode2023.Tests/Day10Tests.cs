using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode._2023.Day10;

namespace AdventOfCode2023.Tests
{
    public class Day10Tests
    {
        public const string squeezeMap =
                @"..........
                .S------7.
                .|F----7|.
                .||....||.
                .||....||.
                .|L-7F-J|.
                .|..||..|.
                .L--JL--J.
                ..........";

        [Test]
        public void Should_return_start_tile_possible_directions()
        {
            string[] mapAsArray = squeezeMap.Split("\r\n").Select(str => str.Trim()).ToArray();
            var pipeMaze = new PipeMaze();

            (int,int)[] startDirections = pipeMaze.GetSDirections(pipeMaze.ParseMap(mapAsArray));

            Assert.That(startDirections, Is.EqualTo(new (int, int)[] { Direction.Right,Direction.Down}));
        }

        [Test]
        public void Should_return_false_if_the_tile_can_squeeze_between_pipes()
        {
            var pipeMaze = new PipeMaze();

            var numberOfTilesEnclosed = pipeMaze.SolvePartTwo(squeezeMap);

            Assert.That(numberOfTilesEnclosed,Is.EqualTo(4));
        }

        [Test]
        public void Should_return_number_of_steps_from_source_to_target_when_map_is_more_complexe()
        {
            var currentMap =
                @"..F7.
                .FJ|.
                SJ.L7
                |F--J
                LJ...";
            var pipeMaze = new PipeMaze();

            var numberOfTilesEnclosed = pipeMaze.SolvePartOne(currentMap);

            Assert.That(numberOfTilesEnclosed, Is.EqualTo(8));
        }

        [Test]
        public void Should_return_number_of_tiles_enclosed_by_the_pipe()
        {
            var currentMap =
                @"..........
                .S------7.
                .|F----7|.
                .||....||.
                .||....||.
                .|L-7F-J|.
                .|..||..|.
                .L--JL--J.
                ..........";
            var pipeMaze = new PipeMaze();

            var numberOfTilesEnclosed = pipeMaze.SolvePartTwo(currentMap);

            Assert.That(numberOfTilesEnclosed, Is.EqualTo(4));
        }

        [Test]
        public void Should_return_number_of_tiles_enclosed_by_the_pipe_on_more_complexe_map()
        {
            var currentMap =
                @".F----7F7F7F7F-7....
                .|F--7||||||||FJ....
                .||.FJ||||||||L7....
                FJL7L7LJLJ||LJ.L-7..
                L--J.L7...LJS7F-7L7.
                ....F-J..F7FJ|L7L7L7
                ....L7.F7||L7|.L7L7|
                .....|FJLJ|FJ|F7|.LJ
                ....FJL-7.||.||||...
                ....L---J.LJ.LJLJ...";
            var pipeMaze = new PipeMaze();

            var numberOfTilesEnclosed = pipeMaze.SolvePartTwo(currentMap);

            Assert.That(numberOfTilesEnclosed, Is.EqualTo(8));
        }

        [Test]
        public void Should_return_number_of_tiles_enclosed_by_the_pipe_on_more_complexe_new_map()
        {
            var currentMap =
                @"FF7FSF7F7F7F7F7F---7
                L|LJ||||||||||||F--J
                FL-7LJLJ||||||LJL-77
                F--JF--7||LJLJ7F7FJ-
                L---JF-JLJ.||-FJLJJ7
                |F|F-JF---7F7-L7L|7|
                |FFJF7L7F-JF7|JL---7
                7-L-JL7||F7|L7F-7F7|
                L.L7LFJ|||||FJL7||LJ
                L7JLJL-JLJLJL--JLJ.L";
            var pipeMaze = new PipeMaze();

            var numberOfTilesEnclosed = pipeMaze.SolvePartTwo(currentMap);

            Assert.That(numberOfTilesEnclosed, Is.EqualTo(10));
        }
    }
}
