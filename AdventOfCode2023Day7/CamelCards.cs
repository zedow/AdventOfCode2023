using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day7
{
    public class CamelCards
    {
        public static string CardsOrderedByStrength = "##23456789TJQKA";
        public static string CardsOrderedByStrengthPart2 = "#J23456789TQKA";
        public static (int, int) GetHandStrength(string input, bool part2 = false)
        {
            var chars = input.ToCharArray().ToList();
            // Replace J as Joker by the most frequent character that is not a J to upgrade global card strength
            var arrangedInput = input != "JJJJJ" ? input.Replace('J', chars
                .Select(ch => (ch, chars.Count(counter => counter == ch)))
                .Where(c => c.ch != 'J')
                .OrderByDescending(order => order.Item2)
                .First().ch
            ) : input;
            var arrangedChars = (part2 ? arrangedInput : input).ToCharArray().ToList();
        
            // concat ordered number of each caracters, QQQJA gives 33311, and QQQQA give 44441
            string value = arrangedChars.
                Select(ch => arrangedChars.Count(c => c == ch).ToString())
                .OrderDescending()
                .Aggregate((prev,next) => prev + next);

            return (int.Parse(value), GetCardStrength(part2 ? arrangedInput : input,part2));
        }

        private static int GetCardStrength(string input, bool part2 = false)
        {
            // Replace cards by their index value, add a zero on numbers < 10 to avoids global lower number due to string length
            var cardsStrength = part2 ? CardsOrderedByStrengthPart2 : CardsOrderedByStrength;
            return int.Parse(
                input.Select(i => cardsStrength.IndexOf(i).ToString())
                .Aggregate((prev, next) => next.Length == 1 ? prev + "0" + next : prev + next));
        }
    }
}
