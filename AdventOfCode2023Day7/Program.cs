using AdventOfCode2023Day7;
using Kernel;

string filePath = "../../../input.txt";
string[] inputContent = new MyFileReader().ReadFile(filePath);
List<Hand> hands = inputContent
    .Select(input => {
        var splitInput = input.Split(' ');
        return new Hand(CamelCards.GetHandStrength(splitInput[0]), MyFileReader.ParseIntegers(splitInput[1]).First());
    })
    .OrderBy(hand => hand.Strength.Item1)
    .ThenBy(hand => hand.Strength.Item2)
    .ToList();

var total = 0;
for(int i = 0; i < hands.Count; i++)
{
    var hand = hands[i];
    total += hand.Bid * (i + 1);
}

Console.WriteLine("First part total score is :" + total);

hands = inputContent
    .Select(input => {
        var splitInput = input.Split(' ');
        return new Hand(CamelCards.GetHandStrength(splitInput[0],true), MyFileReader.ParseIntegers(splitInput[1]).First());
    })
    .OrderBy(hand => hand.Strength.Item1)
    .ThenBy(hand => hand.Strength.Item2)
    .ToList();

total = 0;
for (int i = 0; i < hands.Count; i++)
{
    var hand = hands[i];
    total += hand.Bid * (i + 1);
}

Console.WriteLine("Second part total score is :" + total);