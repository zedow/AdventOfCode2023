using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023Day4;

namespace AdventOfCode2023.Tests
{
    public class Day4Tests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Should_return_a_card_containing_winning_numbers_and_numbers_to_play_from_string_input()
        {
            var input = "Card 1: 41 | 83";

            var card = new Card(input);

            Assert.That(card.WinningNumbers.First(), Is.EqualTo(41));
            Assert.That(card.Numbers.First(), Is.EqualTo(83));
            Assert.That(card.Id, Is.EqualTo(1));
        }

        [Test]
        public void Should_return_card_worth_from_parsed_winning_numbers_and_numbers()
        {
            var input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";

            var card = new Card(input);

            Assert.That(card.GetCardWorth(), Is.EqualTo(8));
        }
    }
}
