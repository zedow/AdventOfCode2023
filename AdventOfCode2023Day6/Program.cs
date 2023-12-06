using AdventOfCode2023Day6;
using Kernel;

string filePath = "../../../input.txt";
string[] inputContent = new MyFileReader().ReadFile(filePath);
var times = MyFileReader.ParseIntegersFromStringInputUsingRegex(inputContent[0]);
var distances = MyFileReader.ParseIntegersFromStringInputUsingRegex(inputContent[1]);
double total = 1;

for(int i = 0; i< times.Count; i++)
{
    var race = new Race(times[i]);
    var boundaries = race.FindIntervalsOfPossibleValuesToBeatGivenDistance(distances[i]);
    total *= (boundaries.Item2 - boundaries.Item1) + 1;
}

Console.WriteLine("Total is : " + total);

// part 2

long part2Distance = long.Parse(string.Join("",distances));
long part2Time = long.Parse(string.Join("", times));
var racePart2 = new Race(part2Time);
var boundariesPart2 = racePart2.FindIntervalsOfPossibleValuesToBeatGivenDistance(part2Distance);
var numberOfWaysToBeatRecord = (boundariesPart2.Item2 - boundariesPart2.Item1) + 1;

Console.WriteLine("The number of way to beat the record is : " + numberOfWaysToBeatRecord);