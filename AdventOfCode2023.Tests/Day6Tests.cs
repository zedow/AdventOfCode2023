using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023Day6;

namespace AdventOfCode2023.Tests
{
    public class Day6Tests
    {
        [Test]
        public void Race_should_return_the_best_possible_hold_time()
        {
            var race = new Race(59);

            (double, double) bestAvailableRange = race.FindIntervalsOfPossibleValuesToBeatGivenDistance(430);

            Assert.That(bestAvailableRange, Is.EqualTo((50, 9)));
        }

        [Test]
        public void Race_should_return_the_correct_number_of_possible_holding_value_to_beat_a_given_score()
        {
            var race = new Race(7);

            (double, double) bestAvailableRange = race.FindIntervalsOfPossibleValuesToBeatGivenDistance(9);
            double numbersOfHoldingValues = (bestAvailableRange.Item2 - bestAvailableRange.Item1) + 1;

            Assert.That(numbersOfHoldingValues,Is.EqualTo(4d));
        }
    }
}
