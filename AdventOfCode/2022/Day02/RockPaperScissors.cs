using AdventOfCode.Kernel;
using Kernel;

namespace AdventOfCode._2022.Day02;

[Challenge("Rock Papers Scissors", "2022/Day02/input.txt")]
public class RockPaperScissors : IChallenge
{
    public const string OpponentShapes = "ABC";
    public const string PlayerShapes = "XYZ";
    public object SolvePartOne(string input) => ParseInput(input)
        .Sum();

    public object SolvePartTwo(string input)
    {
        throw new NotImplementedException();
    }

    public List<int> ParseInput(string input)
    {
        var lines = input.Split("\r\n");
        var list = (
            from irow in Enumerable.Range(0, lines.Length)
            let winPoints = (OpponentShapes.IndexOf(lines[irow][0]) + 1) % 3 == PlayerShapes.IndexOf(lines[irow][2]) 
                ? 6
                : PlayerShapes.IndexOf(lines[irow][2]) == OpponentShapes.IndexOf(lines[irow][0]) ? 3 : 0
            select PlayerShapes.IndexOf(lines[irow][2]) + 1 + winPoints
        ).ToList();
        return list;
    }
}

