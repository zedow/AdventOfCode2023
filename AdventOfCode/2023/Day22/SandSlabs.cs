using AdventOfCode.Kernel;
using Kernel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace AdventOfCode._2023.Day22;

using BrickSupports = Dictionary<Brick, List<Brick>>;
public record Brick(Vector3 Position, Vector3 Depth);

[Challenge("Sand Slabs", "2023/Day22/input.txt")]
public class SandSlabs : IChallenge
{
    public object SolvePartOne(string input) => DisintegrateBricks(input).Sum();

    public object SolvePartTwo(string input)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<int> DisintegrateBricks(string input)
    {
        var bricks = ParseInput(input);
        var fallenBricks = SimulateGravity(bricks);
        BrickSupports bricksSupports = GetBricksSupports(fallenBricks);
        foreach (var brick in bricksSupports )
        {
            var bricksAbove = bricksSupports.Where(b => b.Value.Contains(brick.Key));
            if (bricksAbove.Any() == false || bricksAbove.All(b => b.Value.Count() > 1))
            {
                yield return 1;
            }
        }
    }

    public List<Brick> SimulateGravity(List<Brick> snapshot, float floor = 1)
    {
        snapshot = snapshot.OrderBy(s => s.Position.Z).ToList();
        for(int i =0; i < snapshot.Count(); i ++)
        {
            float newZ = 1;
            for(int y = 0; y < i; y++)
            {
                if (DoesBricksMerge(snapshot[i], snapshot[y]))
                {
                    newZ = Math.Max(newZ, snapshot[y].Depth.Z + 1);
                }
            }
            var gravitySteps = snapshot[i].Position.Z - newZ;
            var newPosition = snapshot[i].Position with { Z = snapshot[i].Position.Z - gravitySteps };
            var newDepth = snapshot[i].Depth with { Z = snapshot[i].Depth.Z - gravitySteps };
            snapshot[i] = snapshot[i] with { Position = newPosition, Depth = newDepth };
        }
        return snapshot;
    }

    public BrickSupports GetBricksSupports(List<Brick> snapshot)
    {
        var supports = new BrickSupports();
        foreach (var brick in snapshot)
        {
            supports.Add(brick,
                snapshot.Where(otherBrick => 
                    otherBrick != brick && 
                    otherBrick.Depth.Z == brick.Position.Z - 1 && 
                    DoesBricksMerge(brick,otherBrick)
                ).ToList());
        }
        return supports;
    }

    public bool DoesBricksMerge(Brick brickA, Brick brickB)
    {
        bool doesItMergeOnAxis(float a, float b, float ax, float bx) => (a <= bx && b <= ax);

        return doesItMergeOnAxis(brickA.Position.X, brickB.Position.X, brickA.Depth.X, brickB.Depth.X)
                && doesItMergeOnAxis(brickA.Position.Y, brickB.Position.Y, brickA.Depth.Y, brickB.Depth.Y);
    }

    public List<Brick> ParseInput(string input)
    {
        var rows = input.Split("\r\n");
        return (
            from irow in Enumerable.Range(0,rows.Length)
            let positionAndDepth = rows[irow].Split("~")
            let position = MyFileReader.ParseIntegers(positionAndDepth[0])
            let depth = MyFileReader.ParseIntegers(positionAndDepth[1])
            select new Brick(new Vector3(position[0], position[1], position[2]),new Vector3(depth[0], depth[1], depth[2]))
        ).ToList();
    }
}

