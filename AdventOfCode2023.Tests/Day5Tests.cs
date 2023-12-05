﻿using AdventOfCode2023Day5;
using Microsoft.VisualStudio.TestPlatform.Utilities;

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

        [Test]
        public void Should_mapper_return_input_number_when_it_is_ouside_of_the_maps_range()
        {
            var input = "seed-to-soil map:\r\n50 98 2\r\n52 50 48";
            var inputNumber = 40;

            List<Map> maps = Map.ParseMaps(input);
            var output = Mapper.MapFromMaps(inputNumber, maps);

            Assert.That(output,Is.EqualTo(inputNumber));
        }

        [TestCase(51,53)]
        [TestCase(99,51)]
        public void Should_mapper_return_input_map_correspondence_when_one_of_input_maps_got_input_number_in_their_range(int inputNumber,int result)
        {
            var input = "seed-to-soil map:\r\n50 98 2\r\n52 50 48";

            List<Map> maps = Map.ParseMaps(input);
            var output = Mapper.MapFromMaps(inputNumber, maps);

            Assert.That(output, Is.EqualTo(result));
        }

        [Test]
        public void Should_mapper_parse_and_store_maps_from_full_input()
        {
            var input =
                @"seeds: 79 14 55 13

                seed-to-soil map:
                50 98 2
                52 50 48

                soil-to-fertilizer map:
                0 15 37
                37 52 2
                39 0 15";

            var mapper = new Mapper();
            mapper.ParseAlmanac(input);
            List<Map> maps = mapper.GetStoredMaps();

            Assert.That(maps.Count, Is.EqualTo(5));
            Assert.That(mapper.GetSeeds().Count, Is.EqualTo(4));
        }

        [TestCase(79,81,"seed","soil")]
        [TestCase(14, 53, "soil", "fertilizer")]
        public void Mapper_must_find_and_use_the_correct_map_when_given_name_of_an_existing_map(int input, int result, string source,string output)
        {
            var inputAlmanac =
                @"seeds: 79 14 55 13

                seed-to-soil map:
                50 98 2
                52 50 48

                soil-to-fertilizer map:
                0 15 37
                37 52 2
                39 0 15";

            var mapper = new Mapper();
            mapper.ParseAlmanac(inputAlmanac);

            Assert.That(mapper.MapInput(input, source, output), Is.EqualTo(result));
        }

        [TestCase(79,82)]
        [TestCase(14, 43)]
        [TestCase(55, 86)]
        [TestCase(13, 35)]
        public void Mapper_should_return_a_locations_for_every_input_seeds(int seed, int location)
        {
            var inputAlmanac =
                @$"seeds: {seed}

                seed-to-soil map:
                50 98 2
                52 50 48

                soil-to-fertilizer map:
                0 15 37
                37 52 2
                39 0 15

                fertilizer-to-water map:
                49 53 8
                0 11 42
                42 0 7
                57 7 4

                water-to-light map:
                88 18 7
                18 25 70

                light-to-temperature map:
                45 77 23
                81 45 19
                68 64 13

                temperature-to-humidity map:
                0 69 1
                1 0 69

                humidity-to-location map:
                60 56 37
                56 93 4";

            var mapper = new Mapper();
            mapper.ParseAlmanac(inputAlmanac);
            List<int> locations = mapper.MapAlmanacSeedsToLocations();

            Assert.That(locations.First(), Is.EqualTo(location));
        }
    }
}
