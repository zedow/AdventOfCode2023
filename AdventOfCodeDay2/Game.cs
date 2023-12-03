using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel;

namespace AdventOfCodeDay2
{
    public class Game
    {
        private string[] _colors = { "blue", "red", "green" };
        private char[] _validNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public int HighestBlueCubes { get; private set; } = 0;
        public int HighestGreenCubes { get; private set;  } = 0;
        public int HighestRedCubes { get; private set; } = 0;
        public int GameId { get; private set; }
        public List<GameSet> GameSets { get; set; }

        public Game() { }

        public List<GameSet> ParseSets(string input)
        {
            var game = input.Split(":");
            GameId = int.Parse(MyFileReader.FindAnIntegerInAString(game[0]));
            var gameSets = game[1];
            var sets = gameSets.Split(";");
            var parsedSets = new List<GameSet>();
            foreach ( var set in sets)
            {
                var colorsToIdentify = set.Split(",");
                var gameSet = new GameSet();
                foreach(var colorAndNumber in colorsToIdentify)
                {
                    var integerFoundInTheString = MyFileReader.FindAnIntegerInAString(colorAndNumber);

                    if (colorAndNumber.IndexOf("blue") != -1)
                    {
                        gameSet.BlueCubes = int.Parse(integerFoundInTheString);
                    }
                    if (colorAndNumber.IndexOf("red") != -1)
                    {
                        gameSet.RedCubes = int.Parse(integerFoundInTheString);
                    }
                    if (colorAndNumber.IndexOf("green") != -1)
                    {
                        gameSet.GreenCubes = int.Parse(integerFoundInTheString);
                    }
                }
                parsedSets.Add(gameSet);
            }
            GameSets = parsedSets;
            return parsedSets;
        }

        public void SethighestNumberFromSets(List<GameSet> sets)
        {
            var setsOrderedByRedCubes = sets.OrderByDescending(s => s.RedCubes).ToList();
            var setsOrderedGreenCubes = sets.OrderByDescending(s => s.GreenCubes).ToList();
            var setsOrderedByBlueCubes = sets.OrderByDescending(s => s.BlueCubes).ToList();

            HighestBlueCubes = setsOrderedByBlueCubes.First().BlueCubes;
            HighestGreenCubes = setsOrderedGreenCubes.First().GreenCubes;
            HighestRedCubes = setsOrderedByRedCubes.First().RedCubes;
        }

        public bool CanGameBePlayedWithTheGivenBag(int blueCubes,int greenCubes, int redCubes)
        {
            SethighestNumberFromSets(GameSets);
            if(blueCubes > HighestBlueCubes && redCubes > HighestRedCubes && greenCubes > HighestGreenCubes)
            {
                return true;
            }
            return false;
        }
    }
}
