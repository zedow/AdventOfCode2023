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
        [TestCase("tsgbzmgb13drqzbhxjkvcnm3", 13)]
        [TestCase("9qrtrsfsr832rvrphxptlrbczx61", 91)]
        [TestCase("9h69", 99)]
        [TestCase("r2ne881998", 28)]
        public void Calibration_should_return_first_and_last_digit_when_input_contains_at_least_two_digits(string input, int result)
        {
            var calibration = new Calibration();
            int value = calibration.Calibrate(input);

            Assert.That(value, Is.EqualTo(result));
        }

        [Test]
        public void Calibration_should_concat_the_same_digit_twice_when_input_contains_only_one_digit()
        {
            var input = "treb7uchet";

            var calibration = new Calibration();
            int result = calibration.Calibrate(input);

            Assert.That(result, Is.EqualTo(77));
        }

        [TestCase("tsgbzmgbonethreedrqzbhxjkvcnm3", "tsgbzmgb13drqzbhxjkvcnm3")]
        [TestCase("nineqrtrsfsreightthreetworvrphxptlrbczxsix1", "9qrtrsfsr832rvrphxptlrbczx61")]
        [TestCase("v4", "v4")]
        [TestCase("9h6nine","9h69")]
        [TestCase("rtwone881998", "r2ne881998")]
        public void Calibration_should_replace_digits_in_letters_by_digits(string input, string result)
        {
            input = new Calibration().ReplaceDigitsInletterByDigits(input);

            Assert.That(input, Is.EqualTo(result));
        }
    }
}
