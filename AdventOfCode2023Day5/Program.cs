using AdventOfCode2023Day5;
using Kernel;

string filePath = "../../../input.txt";
string inputContent = File.ReadAllText(filePath);

var mapper = new Mapper();
mapper.ParseAlmanac(inputContent);

var locations = mapper.MapAlmanacSeedsToLocations();

Console.WriteLine("Locations are:");
foreach(var location in locations)
{
    Console.WriteLine("- " + location);
}

Console.WriteLine("The lowest location is: " + locations.OrderBy(l => l).First());
Console.ReadLine();

