using AdventOfCode._2023.Day13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests._2023.Day13
{
    public class Day13Tests
    {
        [Test]
        public void Should_return_number_of_reflected_columns_and_number_of_columnes_on_the_left_of_mirror()
        {
            var input = @"#.##..##.
                        ..#.##.#.
                        ##......#
                        ##......#
                        ..#.##.#.
                        ..##..##.
                        #.#.##.#."
            .Split("\n").Select(str => str.Trim()).ToArray();
            var mirrors = new Mirros();
            var inputColumns = mirrors.ParseColumns(input);

            var result = mirrors.CountReflectionRecursively(inputColumns,0);
            var resultRows = mirrors.CountReflectionRecursively(input,0);

            Assert.That((result / 2) + result  % 2 , Is.EqualTo(5));
        }

        [Test]
        public void Should_return_zero_when_there_is_no_mirror()
        {
            var input = @"#.##..##.
                        ..#.##.#.
                        ##......#
                        ##......#
                        ..#.##.#.
                        ..##..##.
                        #.#.##.#."
            .Split("\n").Select(str => str.Trim()).ToArray();
            var mirrors = new Mirros();

            var result = mirrors.CountReflectionRecursively(input, 0);

            Assert.That((result / 2) + result % 2, Is.EqualTo(0));
        }

        [Test]
        public void Should_return_number_of_reflected_rows_and_number_of_rows_above_mirror()
        {
            var input = @"#...##..#
                        #....#..#
                        ..##..###
                        #####.##.
                        #####.##.
                        ..##..###
                        #....#..#"
            .Split("\n").Select(str => str.Trim()).ToArray();
            var mirrors = new Mirros();

            var resultRows = mirrors.CountReflectionRecursively(input, 0);

            Assert.That((resultRows / 2) + resultRows % 2, Is.EqualTo(4));
        }

        [Test]
        public void Should_return_number_of_reflected_columns_even_when_columns_is_on_the_right_border()
        {
            var input = @"##...##
                        ..#.#..
                        #...#..
                        .###.##
                        ##.#.##
                        ##..###
                        ##.....
                        .#.##..
                        .#..#.."
            .Split("\n").Select(str => str.Trim()).ToArray();
            var mirrors = new Mirros();
            var inputColumns = mirrors.ParseColumns(input);

            var resultRows = mirrors.CountReflectionRecursively(inputColumns, 0);

            Assert.That((resultRows / 2) + resultRows % 2, Is.EqualTo(6));
        }

        [Test]
        public void Should_return_zero_when_there_is_no_mirror_second_input()
        {
            var input = @"##..
                        ##.."
            .Split("\n").Select(str => str.Trim()).ToArray();
            var mirrors = new Mirros();
            var inputColumns = mirrors.ParseColumns(input);

            var resultColumn = mirrors.CountReflectionRecursively(inputColumns, 0);
            var resultRows = mirrors.CountReflectionRecursively(input, 0);

            Assert.That((resultColumn / 2) + resultColumn % 2, Is.EqualTo(1));
            Assert.That((resultRows / 2) + resultRows % 2, Is.EqualTo(1));
        }

        [Test]
        public void Should_solve_part_one()
        {
            var input = @"#.##..##.
                        ..#.##.#.
                        ##......#
                        ##......#
                        ..#.##.#.
                        ..##..##.
                        #.#.##.#.

                        #...##..#
                        #....#..#
                        ..##..###
                        #####.##.
                        #####.##.
                        ..##..###
                        #....#..#";
            var mirrors = new Mirros();

            int resultRows = (int)mirrors.SolvePartOne(input);

            Assert.That(resultRows, Is.EqualTo(405));
        }
    }
}
