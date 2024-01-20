using AdventOfCode.Kernel;
using System.Numerics;

namespace AdventOfCode._2022.Day09;

public record CharMove(char Direction, int Steps);

[Challenge("Rope Bridge", "2022/Day09/input.txt")]
public class RopeBridge : IChallenge
{
    public object SolvePartOne(string input) 
        => MoveRope(input, 2).Distinct().Count();

    public object SolvePartTwo(string input)
        => MoveRope(input, 10).Distinct().Count();


    public static IEnumerable<MyVector> MoveRope(string input, int numberOfNodes)
    {
        var moves = ParseMoves(input);
        MyVector[] rope = Enumerable.Repeat(new MyVector(0,0),numberOfNodes).ToArray();
        yield return rope.Last();
        foreach(var move in moves)
        {
            var dir = GetDirection(move.Direction);
            for(int i = 0; i < move.Steps; i++)
            {
                rope[0] = rope[0] + dir;
                for(int y = 1; y < rope.Length; y++)
                {
                    var tailDirection = rope[y - 1] - rope[y];
                    if(Math.Max(Math.Abs(tailDirection.X), Math.Abs(tailDirection.Y)) > 1)
                        rope[y] = new MyVector(rope[y].X + Math.Sign(tailDirection.X), rope[y].Y + Math.Sign(tailDirection.Y));
                }
                yield return rope.Last();
            }
        }
    }

    public static List<CharMove> ParseMoves(string input)
    {
        var lines = input.Split('\n');
        return (
            from irow in Enumerable.Range(0,lines.Length)
            let split = lines[irow].Split(' ')
            select new CharMove(split[0][0],int.Parse(split[1]))
        ).ToList();
    }

    public static MyVector GetDirection(char move) =>
        move switch {
            'U' => MyVector.Up,
            'D' => MyVector.Down,
            'L' => MyVector.Left,
            _ => MyVector.Right
        };
}