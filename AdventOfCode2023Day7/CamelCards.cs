using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day7
{
    public class CamelCards
    {
        public List<char> CardsOrderedByStrength = new List<char>{ '#','#','2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
        public int GetHandStrength(string input)
        {
            var chars = input.ToCharArray().ToList();
            var group = chars.GroupBy(c => c).OrderByDescending(group => group.Count());
            int value;
            if(group.First().Count() == 5)
            {
                value = 9000000;
            }
            else if(group.First().Count() == 4)
            {
                value = 800000;
            }
            else if(group.First().Count() == 3 && group.Last().Count() == 2)
            {
                value = 70000;
            }
            else if(group.First().Count() == 3 && group.Last().Count() == 1)
            {
                value = 6000;
            }
            else if(group.First().Count() == 2 && group.ElementAt(1).Count() == 2)
            {
                value = 500;
            }
            else if(group.First().Count() == 2)
            {
                value = 40;
            }
            else { value = 3; }

            return value * chars.Select(c => Math.Max(CardsOrderedByStrength.IndexOf(c) - (chars.IndexOf(c) + 1),0)).Sum();
        }
    }
}
