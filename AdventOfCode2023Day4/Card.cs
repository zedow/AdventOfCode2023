using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day4
{
    public class Card
    {
        public int Id { get; private set; }
        public List<int> WinningNumbers { get; private set; }
        public List<int> Numbers { get; private set; }
        public Card(string input) 
        { 
            WinningNumbers = new List<int>();
            Numbers = new List<int>();
            ParseInput(input);
        }

        private void ParseInput(string input)
        {
            var cardArray = input.Split(':');
            Id = int.Parse(MyFileReader.FindAnIntegerInAString(cardArray[0]));
            var numbersArray = cardArray[1].Split("|");
            var winningNumbers = numbersArray[0].Split(" ").Where(str => !string.IsNullOrWhiteSpace(str)).ToArray();
            for(int i = 0; i < winningNumbers.Length; i++)
            {
                var winningNumber = winningNumbers[i];
                WinningNumbers.Add(int.Parse(MyFileReader.FindAnIntegerInAString(winningNumber)));
            }

            var playableNumbers = numbersArray[1].Split(" ").Where(str => !string.IsNullOrWhiteSpace(str)).ToArray();
            for (int i = 0; i < playableNumbers.Length; i++)
            {
                var playableNumber = playableNumbers[i];
                Numbers.Add(int.Parse(MyFileReader.FindAnIntegerInAString(playableNumber)));
            }
        }

        public int GetCardWorth()
        {
            var total = 0;
            foreach(var number in Numbers)
            {
                foreach (var winningNumber in WinningNumbers)
                {
                    if(number == winningNumber)
                    {
                        if(total == 0)
                        {
                            total += 1;
                        }
                        else
                        {
                            total = total * 2;
                        }
                    }
                }
            }

            return total;
        }
    }
}
