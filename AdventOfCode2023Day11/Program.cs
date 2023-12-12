using AdventOfCode2023Day11;
using Kernel;

string filePath = "../../../input.txt";
string inputContent = File.ReadAllText(filePath);

//var solutionV1 = Galaxy.SolvePartOne(inputContent);

//Console.WriteLine(solutionV1);

var solutionV2 = Galaxy.SolvePartOne(inputContent);

Console.WriteLine(solutionV2);
