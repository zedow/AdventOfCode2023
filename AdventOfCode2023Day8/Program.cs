
using AdventOfCode2023Day8;

string filePath = "../../../input.txt";
var input = File.ReadAllText(filePath);

var network = new Network(input);

var steps = network.GetPathSteps("AAA", "ZZZ");

Console.WriteLine("Path to ZZZ require " + steps + " steps");