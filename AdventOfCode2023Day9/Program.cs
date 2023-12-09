using AdventOfCode2023Day9;
using Kernel;

string filePath = "../../../input.txt";
string[] inputContent = new MyFileReader().ReadFile(filePath);

long total = 0;
foreach(var input in inputContent)
{
    total += Forecast.GetValueFromHistory(input);
}

Console.WriteLine(total);