using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay2
{
    public class Game
    {
        private string[] _colors = { "blue", "red", "green" };
        private char[] _validNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public Game() { }

        public List<GameSet> ParseSets(string input)
        {
            var game = input.Split(":");
            var gameSets = game[1];
            var sets = gameSets.Split(";");
            var parsedSets = new List<GameSet>();
            foreach ( var set in sets)
            {
                var colorsToIdentify = set.Split(",");
                var gameSet = new GameSet();
                foreach(var colorAndNumber in colorsToIdentify)
                {
                    var colorAndNumberAsArray = colorAndNumber.ToArray();
                    var numberAsString = "";
                    bool isANumber = false;
                    for (int i = 0; i < colorAndNumberAsArray.Length; i++)
                    {
                        if (_validNumbers.Contains(colorAndNumberAsArray[i]))
                        {
                            isANumber = true;
                            numberAsString += colorAndNumberAsArray[i];
                        }

                        // break when the number has been fully parsed
                        if (numberAsString != "" && isANumber == false)
                        {
                            break;
                        }

                        isANumber = false;
                    }

                    if (colorAndNumber.IndexOf("blue") != -1)
                    {
                        gameSet.BlueCubes = int.Parse(numberAsString);
                    }
                    if (colorAndNumber.IndexOf("red") != -1)
                    {
                        gameSet.RedCubes = int.Parse(numberAsString);
                    }
                    if (colorAndNumber.IndexOf("green") != -1)
                    {
                        gameSet.GreenCubes = int.Parse(numberAsString);
                    }
                }
                parsedSets.Add(gameSet);
            }
            return parsedSets;
        }
    }
}
