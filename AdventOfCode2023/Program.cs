using AdventOfCode2023Day3;
using Kernel;

string filePath = "../../../input.txt";
string[] inputContent = new MyFileReader().ReadFile(filePath);

Engine engine = new Engine();

int total = engine.CalculateATotalOfAllNumbersAdjacentToASymbol(inputContent);
int totalPart2 = engine.CalculateATotalMultiplicationOfAllPairsOfNumbersAdjacentToTheSameSymbol(inputContent);

Console.WriteLine(total);
Console.WriteLine("Total part 2: " + totalPart2);