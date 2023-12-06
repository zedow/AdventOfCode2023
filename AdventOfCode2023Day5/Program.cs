using AdventOfCode2023Day5;
using Kernel;

string filePath = "../../../input.txt";
string inputContent = File.ReadAllText(filePath);

var mapper = new MapperV2();
mapper.ParseMaps(inputContent);

List<AdventOfCode2023Day5.Range> ranges = new List<AdventOfCode2023Day5.Range>();
foreach(var seed in mapper.Seeds.Chunk(2))
{
    ranges.Add(new AdventOfCode2023Day5.Range(seed[0], seed[0] + seed[1]));
}

foreach(var map in mapper.Maps)
{
    ranges = ranges.SelectMany(range => mapper.Explore(range, map)).ToList();
}

Console.WriteLine(ranges.OrderBy(r => r.Start).ToList().First().Start + " is the lowest location");    

Console.ReadLine();