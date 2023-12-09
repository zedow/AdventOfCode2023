using AdventOfCode2023Day1;
using Kernel;

string filePath = "../../../input.txt";
string[] inputContent = new MyFileReader().ReadFile(filePath);
var calibration = new Calibration();


var total = inputContent.Select(calibration.Calibrate).Sum();

Console.WriteLine(total);

total = inputContent.Select(calibration.CalibrateDigitsInLetter).Sum();

Console.WriteLine(total);

