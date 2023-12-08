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
        [TestCase("AAAAA", 55555)]
        [TestCase("AA8AA", 44441)]
        [TestCase("23332", 33322)]
        [TestCase("TTT98", 33311)]
        [TestCase("23432", 22221)]
        [TestCase("A23A4", 22111)]
        [TestCase("23456", 11111)]
        public void CamelCards_should_return_hand_strengh(string hand, int strengh)
        {
            var handStrength = CamelCards.GetHandStrength(hand);

            Assert.That(handStrength.Item1, Is.EqualTo(strengh));
        }

        [TestCase("AAAAA", 55555,1313131313)]
        [TestCase("AAJAA", 55555, 1313011313)]
        [TestCase("2333J", 44441,203030301)]
        [TestCase("TTTJ8", 44441,1010100108)]
        [TestCase("23J32", 33322,203010302)]
        [TestCase("233J2",33322,203030102)]
        [TestCase("2J332", 33322,201030302)]
        [TestCase("JJJJ8",55555,101010108)]
        [TestCase("JJJJJ", 55555,101010101)]
        public void CamelCards_should_return_hand_strengh_considering_j_as_joker(string hand, int patternStrength, int cardsStrength)
        {
            var handStrength = CamelCards.GetHandStrength(hand,true);

            Assert.That(handStrength.Item1, Is.EqualTo(patternStrength));
            Assert.That(handStrength.Item2, Is.EqualTo(cardsStrength));
        }


    }
}
