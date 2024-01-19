using System.Text.RegularExpressions;
using AdventOfCode.Kernel;
using Kernel;

namespace AdventOfCode._2022.Day07;

[Challenge("No Space Left On Device", "2022/Day07/input.txt")]
public partial class SpaceDevice : IChallenge
{
    public object SolvePartOne(string input) => ParseInput(input).Where(size => size < 100000).Sum();
    public object SolvePartTwo(string input)
    {
        var fileSystem = ParseInput(input);
        // fileSystem Max will be root directory
        var leftSpace = 70000000 - fileSystem.Max();
        var requiredSpace = 30000000 - leftSpace;
        return fileSystem.Where(size => size >= requiredSpace).Order().First();
    }

    public List<int> ParseInput(string input)
    {
        var path = new Stack<string>();
        var fileSystem = new Dictionary<string,int>();
        foreach(var line in input.Split('\n'))
        {
            if(line == "$ cd ..") 
            {
                path.Pop();
            }
            else if(line.StartsWith("$ cd"))
            {
                path.Push(string.Join("",path) + line.Split(' ')[2]);
            }
            else if(MyRegex().Match(line).Success)
            {
                foreach(var dir in path) 
                {
                    fileSystem.TryAdd(dir,0);
                    fileSystem[dir] += int.Parse(line.Split(' ')[0]);
                }
            }
        }
        return fileSystem.Values.ToList();
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex MyRegex();
}