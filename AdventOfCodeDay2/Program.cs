using AdventOfCodeDay2;
using Kernel;

string filePath = "../../../input.txt";
string[] inputContent = new MyFileReader().ReadFile(filePath);
var numberOfGameThatCanBePlayed = 0;

foreach(string input in inputContent)
{
    var game = new Game();
    game.ParseSets(input);
    if(game.CanGameBePlayedWithTheGivenBag(14, 13, 12))
    {
        Console.WriteLine(game.GameId + " can be played");
        numberOfGameThatCanBePlayed+= game.GameId;
    }
}

Console.WriteLine(numberOfGameThatCanBePlayed.ToString());