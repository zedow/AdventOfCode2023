using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day4
{
    public class CardsWatcher
    {
        private List<Card> _cards;
        public CardsWatcher(string[] input) 
        {
            _cards = new List<Card>();
            foreach (var inputContent in input)
            {
                var card = new Card(inputContent);
                _cards.Add(card);
            }
        }

        public List<Card> GetCards()
        {
            return _cards;
        }

        public void SetCardsCopies()
        {
            foreach(var currentCard in _cards)
            {
                var numberOfMatchingNumbers = currentCard.GetNumberOfMatchningNumbers();
                for(int i = 1; i <= numberOfMatchingNumbers; i++)
                {
                    _cards.Where(card => card.Id == currentCard.Id + i).First().Copies += 1;
                    for (int y = 0; y < currentCard.Copies; y++)
                    {
                        _cards.Where(card => card.Id == currentCard.Id + i).First().Copies += 1;
                    }
                }
                
            }
        }
    }
}
