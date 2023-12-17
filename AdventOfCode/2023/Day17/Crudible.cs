using AdventOfCode.Kernel;
using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2023.Day17;

using Map = Dictionary<Complex, int>;
public record Node(Complex Position, Complex Direction, int StraightMoves);

// Encode the difference between part 1 and 2 in a handy 'rules' object
public record Rules(
    Func<Node, bool> canChangeDir,
    Func<Node, bool> canGoStraight
);

[Challenge("Clumsy Node", "2023/Day17/input.txt")]
public class Crudible : IChallenge
{
    public object SolvePartOne(string input) =>
        GetPath(input,
            new Rules(
                canChangeDir: crucible => true,
                canGoStraight: crucible => crucible.StraightMoves < 3
            ));

    public object SolvePartTwo(string input) =>
         GetPath(input,
            new Rules(
                canChangeDir: crucible => crucible.StraightMoves >= 4,
                canGoStraight: crucible => crucible.StraightMoves < 10
            ));

    // a* implementation but cost is represented by heat loss
    int GetPath(string input, Rules rules)
    {
        var map = ParseMap(input);
        var target = map.Keys.MaxBy(pos => pos.Imaginary + pos.Real);
        var pathsToExplore = new PriorityQueue<Node, int>();
        pathsToExplore.Enqueue(new Node(Position: 0, Direction: 1, StraightMoves: 0), 0);
        pathsToExplore.Enqueue(new Node(Position: 0, Direction: Complex.ImaginaryOne, StraightMoves: 0), 0);

        var seen = new HashSet<Node>();
        while (pathsToExplore.TryDequeue(out var crucible, out var heatloss))
        {
            if (crucible.Position == target && rules.canChangeDir(crucible))
                return heatloss;

            foreach (var next in Moves(crucible, rules))
            {
                if (map.ContainsKey(next.Position) && !seen.Contains(next))
                {
                    seen.Add(next);
                    pathsToExplore.Enqueue(next, heatloss + map[next.Position]);
                }
            }
        }
        throw new Exception("Target not found in the given map");
    }

    public IEnumerable<Node> Moves(Node crucible, Rules rules)
    {
        if (rules.canGoStraight(crucible))
            yield return crucible with { Position = crucible.Position + crucible.Direction, StraightMoves = crucible.StraightMoves + 1};

        if (rules.canChangeDir(crucible))
        {
            var direction = crucible.Direction * Complex.ImaginaryOne;
            yield return new Node(crucible.Position + direction, direction, 1);
            yield return new Node(crucible.Position - direction, -direction, 1);
        }
    }

    Map ParseMap(string input)
    {
        var lines = input.Split("\r\n");
        return (
            from irow in Enumerable.Range(0, lines.Length)
            from icol in Enumerable.Range(0, lines[0].Length)
            let cell = int.Parse(lines[irow].Substring(icol, 1))
            let pos = new Complex(icol, irow)
            select new KeyValuePair<Complex, int>(pos, cell)
        ).ToDictionary();
    }
}

