using AdventOfCode.Kernel;
using Kernel;

namespace AdventOfCode._2022.Day01;

[Challenge("Calorie Counting","2022/Day01/input.txt")]
public class CalorieCounting : IChallenge
{
    public object SolvePartOne(string input) => ParseInput(input).Select(calories => calories.Sum()).Max();

    public object SolvePartTwo(string input)
        => ParseInput(input).Select(calories => calories.Sum()).OrderDescending().Take(3).Sum();

    public List<int[]> ParseInput(string input)
    {
        var blocks = input.Split("\r\n\r\n",StringSplitOptions.RemoveEmptyEntries);
        return (
            from iblock in Enumerable.Range(0,blocks.Count())
            select MyFileReader.ParseIntegers(blocks[iblock]).ToArray()
        ).ToList();
    } 
}

