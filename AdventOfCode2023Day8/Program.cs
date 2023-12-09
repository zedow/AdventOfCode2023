using AdventOfCode2023Day8;
using System.Numerics;

string filePath = "../../../input.txt";
var input = File.ReadAllText(filePath);

var network = new Network(input);

var steps = network.GetPathSteps("AAA");

Console.WriteLine("Path to ZZZ require " + steps + " steps");

// It take one minute to run
Console.WriteLine(network.GetPathStepsPart2() + " is the number of steps required for all A node to reach a Z node");