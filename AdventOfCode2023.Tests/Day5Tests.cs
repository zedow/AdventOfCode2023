﻿using AdventOfCode2023Day5;

namespace AdventOfCode2023.Tests
{
    public class Day5Tests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Should_parse_valid_input_to_map_object()
        {
            var input = "seed-to-soil map:\r\n50 98 2\r\n52 50 48";

            List<Map> maps = Map.ParseMaps(input);

            Assert.That(maps.Count, Is.EqualTo(2));
            Assert.That(maps.First().From, Is.EqualTo(98));
        }

        [Test]
        public void Should_parse_map_names()
        {
            var input = @"seed-to-soil map: 
                        50 98 2 
                        52 50 48";

            string[] mapNames = Map.ParseMapNames(input);

            Assert.That(mapNames.First(), Is.EqualTo("seed"));
        }
    }
}
