using AdventOfCodeDay2;
using Kernel;

string filePath = "../../../input.txt";
string[] inputContent = new MyFileReader().ReadFile(filePath);
var numberOfGameThatCanBePlayed = 0;
var sumOfPowers = 0;

foreach(string input in inputContent)
{
    var game = new Game();
    game.ParseSets(input);
    if(game.CanGameBePlayedWithTheGivenBag(14, 13, 12))
    {
        Console.WriteLine(game.GameId + " can be played");
        numberOfGameThatCanBePlayed+= game.GameId;
    }

    int highestBlueNumberRequiredToPlayTheGame = game.HighestBlueCubes;
    int highestRedNumberRequiredToPlayTheGame = game.HighestRedCubes;
    int highestGreenNumberRequiredToPlayTheGame = game.HighestGreenCubes;
    int totalPower = highestBlueNumberRequiredToPlayTheGame * highestRedNumberRequiredToPlayTheGame * highestGreenNumberRequiredToPlayTheGame;
    sumOfPowers += totalPower;
}

Console.WriteLine(numberOfGameThatCanBePlayed.ToString());
Console.WriteLine(sumOfPowers + " is the sum of powers of games");