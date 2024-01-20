using AdventOfCode.Kernel;

namespace AdventOfCode._2022.Day02;

[Challenge("Rock Papers Scissors", "2022/Day02/input.txt")]
public class RockPaperScissors : IChallenge
{
    public const string OpponentShapes = "ABC";
    public const string PlayerShapes = "XYZ";

    public object SolvePartOne(string input) => ParseInput(input)
        .Sum();

    public object SolvePartTwo(string input) => ParseInputPartTwo(input).Sum();

    public static List<int> ParseInput(string input)
    {
        var lines = input.Split('\n');
        var list = (
            from irow in Enumerable.Range(0, lines.Length)
            let winPoints = (OpponentShapes.IndexOf(lines[irow][0]) + 1) % 3 == PlayerShapes.IndexOf(lines[irow][2]) 
                ? 6
                : PlayerShapes.IndexOf(lines[irow][2]) == OpponentShapes.IndexOf(lines[irow][0]) ? 3 : 0
            select PlayerShapes.IndexOf(lines[irow][2]) + 1 + winPoints
        ).ToList();
        return list;
    }

    public static List<int> ParseInputPartTwo(string input)
    {
        var lines = input.Split('\n');
        return (
            from irow in Enumerable.Range(0,lines.Length)
            select GetPlayerPoints(lines[irow][0],lines[irow][2])
        ).ToList();
    }

    public static int GetPlayerPoints(char opponentShape, char playerShape)
    {
        var playerWinpoints = 3 * PlayerShapes.IndexOf(playerShape);
        var playerShapeShifter = PlayerShapes.IndexOf(playerShape) switch {
            1 => 0,
            2 => 1,
            _ => 2
        };
        return ((OpponentShapes.IndexOf(opponentShape) + playerShapeShifter) % 3) + 1 + playerWinpoints;
    }
}

