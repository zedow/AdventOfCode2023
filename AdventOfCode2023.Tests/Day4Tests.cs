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

        [Test]

        public void Should_return_number_of_matching_numbers()
        {
            var input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";

            var card = new Card(input);

            Assert.That(card.GetNumberOfMatchningNumbers(), Is.EqualTo(4));
        }

        [Test]
        public void Should_return_a_new_set_of_card_contanaining_copies_when_a_card_has_matching_numbers()
        {
            string[] input = {"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                        "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                        "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                        "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                        "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                        "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11" };

            var cardsWatcher = new CardsWatcher(input);
            cardsWatcher.SetCardsCopies();

            Assert.That(cardsWatcher.GetCards().First(card => card.Id == 2).Copies, Is.EqualTo(1));
            Assert.That(cardsWatcher.GetCards().First(card => card.Id == 3).Copies, Is.EqualTo(3));
            Assert.That(cardsWatcher.GetCards().First(card => card.Id == 4).Copies, Is.EqualTo(7));
            Assert.That(cardsWatcher.GetCards().First(card => card.Id == 5).Copies, Is.EqualTo(13));
        }
    }
}
