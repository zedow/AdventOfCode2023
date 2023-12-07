using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023Day1;

namespace AdventOfCode2023.Tests
{
    public class Day1Tests
    {
        [Test]
        public void Calibration_should_return_first_and_last_digit_when_input_contains_at_least_two_digits()
        {
            var input = "1abc2";

            var calibration = new Calibration();
            int result = calibration.Calibrate(input);

            Assert.That(result,Is.EqualTo(12));
        }
    }
}
