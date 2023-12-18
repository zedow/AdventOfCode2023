using AdventOfCode._2023.Day18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests._2023.Day18
{
    public class Day18Tests
    {
        [Test]
        public void ParseInput_should_return_all_dig_plans()
        {
            var input = File.ReadAllText("../../../2023/Day18/input.txt");

            var lagoon = new LavaLagoon();
            var firstPlan = lagoon.ParseInput(input).ElementAt(0);

            Assert.That(firstPlan.Direction, Is.EqualTo(Complex.One));
            Assert.That(firstPlan.Meters, Is.EqualTo(6));
            Assert.That(firstPlan.Color, Is.EqualTo(("(#70c710)")));
        }

        [Test]
        public void Dig_should_return_a_map_38_length()
        {
            var input = File.ReadAllText("../../../2023/Day18/input.txt");

            var lagoon = new LavaLagoon();
            var map = lagoon.Dig(lagoon.ParseInput(input));

            Assert.That(map.Count(), Is.EqualTo(38));
        }

        [Test]
        public void DigOutInterior_should_return_a_map_62_length()
        {
            var input = File.ReadAllText("../../../2023/Day18/input.txt");

            var lagoon = new LavaLagoon();
            var map = lagoon.Dig(lagoon.ParseInput(input));
            var digMap = lagoon.DigOutInterior(map);

            Assert.That(digMap.Count(), Is.EqualTo(62));
        }
    }
}
