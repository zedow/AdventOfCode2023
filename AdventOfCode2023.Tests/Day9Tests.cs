using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023Day9;

namespace AdventOfCode2023.Tests
{
    public class Day9Tests
    {
        [TestCase("1   3   6  10  15  21",28)]
        [TestCase("0   3   6   9  12  15", 18)]
        public void Should_return_next_value_based_on_historic(string input, int result)
        {

            var value = Forecast.GetValueFromHistory(input);

            Assert.That(value, Is.EqualTo(result));
        }

        [TestCase("10  13  16  21  30  45", 5)]
        [TestCase("0   3   6   9  12  15", -3)]
        [TestCase("1   3   6  10  15  21", 0)]
        public void Should_return_next_value_based_on_historic_part2(string input, int result)
        {
            int value = Forecast.GetBackwardsValueFromHistory(input);

            Assert.That(value, Is.EqualTo(result));
        }
    }
}
