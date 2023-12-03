using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day3
{
    public class Engine
    {
        private char[] _validNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] _unvalidSymbols = { '.', ' ' };
        public Dictionary<Coordinate,int> FindNumbers(string[] input)
        {
            Dictionary<Coordinate, int> numbers = new Dictionary<Coordinate,int>();
            for(int i = 0; i < input.Length; i++)
            {
                char[] currentRow = input[i].ToArray();
                var numbersAsAString = "";
                for(int y = 0; y < currentRow.Length; y++)
                {
                    var currentValue = currentRow[y];
                    if(_validNumbers.Contains(currentValue))
                    {
                       numbersAsAString += currentValue.ToString();
                        // check if this is the end of the line
                       if(y == (currentRow.Length - 1))
                       {
                            numbers.Add(new Coordinate(i,y - numbersAsAString.Length, numbersAsAString.Length),int.Parse(numbersAsAString));
                            numbersAsAString = "";
                       }
                    }
                    else
                    {
                        if(numbersAsAString != "")
                        {
                            numbers.Add(new Coordinate(i, y - numbersAsAString.Length, numbersAsAString.Length), int.Parse(numbersAsAString));
                            numbersAsAString = "";
                        }
                    }
                }
            }
            return numbers;
        }

        public Dictionary<Coordinate, int> FindSymbols(string[] input)
        {
            Dictionary<Coordinate, int> numbers = new Dictionary<Coordinate, int>();
            for (int i = 0; i < input.Length; i++)
            {
                char[] currentRow = input[i].ToArray();
                var numbersAsAString = "";
                for (int y = 0; y < currentRow.Length; y++)
                {
                    var currentValue = currentRow[y];
                    if (_validNumbers.Contains(currentValue) == false && _unvalidSymbols.Contains(currentValue) == false)
                    {
                        numbersAsAString += currentValue.ToString();
                        // check if this is the end of the line
                        if (y == (currentRow.Length - 1))
                        {
                            numbers.Add(new Coordinate(i,y - 1),0);
                            numbersAsAString = "";
                        }
                    }
                    else
                    {
                        if (numbersAsAString != "")
                        {
                            numbers.Add(new Coordinate(i, y - 1),0);
                            numbersAsAString = "";
                        }
                    }
                }
            }
            return numbers;
        }

        public int CalculateATotalOfAllNumbersAdjacentToASymbol(string[] input)
        {
            var numbers = FindNumbers(input);
            var symbols = FindSymbols(input);
            var total = 0;
            for(int i = 0; i < numbers.Count; i++)
            {
                KeyValuePair<Coordinate,int> currentNumber = numbers.ElementAt(i);
                for(int y = 0; y < symbols.Count; y++)
                {
                    KeyValuePair<Coordinate, int> currentSymbol = symbols.ElementAt(y);
                    if (currentNumber.Key.IsNeighbor(currentSymbol.Key))
                    {
                        total += currentNumber.Value;
                    }
                }
            }

            return total;
        }

        public int CalculateATotalMultiplicationOfAllPairsOfNumbersAdjacentToTheSameSymbol(string[] input)
        {
            var numbers = FindNumbers(input);
            var symbols = FindSymbols(input);
            var total = 0;
            for (int i = 0; i < symbols.Count; i++)
            {
                KeyValuePair<Coordinate, int> currentSymbol = symbols.ElementAt(i);
                int pairOne = 0;
                int pairTwo = 0;
                for (int y = 0; y < numbers.Count; y++)
                {
                    KeyValuePair<Coordinate, int> currentNumber = numbers.ElementAt(y);
                    if (currentNumber.Key.IsNeighbor(currentSymbol.Key))
                    {
                        if(pairOne != 0)
                            pairTwo = currentNumber.Value;
                        else
                            pairOne = currentNumber.Value;
                    }
                }

                if (pairOne != 0 && pairTwo != 0)
                    total += pairOne * pairTwo;
            }

            return total;
        }
    }
}
