using AdventOfCode2023Day11;

string filePath = "../../../input.txt";
string inputContent = File.ReadAllText(filePath);

var solutionV1 = Galaxy.SolvePartOne(inputContent);

Console.WriteLine(solutionV1);

var solutionV2 = Galaxy.SolvePartTwo(inputContent);

Console.WriteLine(solutionV2);
