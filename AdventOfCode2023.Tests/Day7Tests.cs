using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023Day7;

namespace AdventOfCode2023.Tests
{
    public class Day7Tests
    {
        [TestCase("AAAAA", 585000000)]
        [TestCase("KKKKK", 540000000)]
        [TestCase("AA8AA", 45600000)]
        [TestCase("23332", 350000)]
        [TestCase("TTT98", 210000)]
        [TestCase("23432", 2500)]
        [TestCase("A23A4", 1040)]
        [TestCase("23456", 15)]
        [TestCase("13456", 12)]
        public void CamelCards_should_return_hand_strengh(string hand, int strengh)
        {
            var camelCards = new CamelCards();

            var handStrength = camelCards.GetHandStrength(hand);

            Assert.That(handStrength, Is.EqualTo(strengh));
        }
    }
}
