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
        var bricksSupports = SimulateGravity(bricks);
        foreach(var brick in bricksSupports )
        {
            var bricksAbove = bricksSupports.Where(b => b.Value.Contains(brick.Key));
            if (bricksAbove.Any() == false || bricksAbove.All(b => b.Value.Count() > 1))
            {
                yield return 1;
            }
        }
    }

    public BrickSupports SimulateGravity(List<Brick> snapshot, float floor = 1)
    {
        BrickSupports supports = new BrickSupports();
        var queue = new Queue<Brick>();
        snapshot.OrderBy(s => s.Position.Z).ToList().ForEach(queue.Enqueue);
        while(queue.Count > 0)
        {
            var brick = queue.Dequeue();
            var brickPosition = brick.Position;
            while (brickPosition.Z > floor && supports.Any(brickFromSnapShop => brickFromSnapShop.Key.Position.Z == brickPosition.Z) == false)
            {
                brickPosition -= Vector3.UnitZ;
            }

            var mergeBricks = supports.Where(brickFromSnapShot => brickFromSnapShot.Key.Position.Z == brickPosition.Z 
            && DoesBricksMerge(brickFromSnapShot.Key, brick)).Select(b => b.Key).ToList();
            if (mergeBricks.Any())
            {
                brickPosition += Vector3.UnitZ;
                supports.Add(new Brick(brickPosition, brick.Depth with { Z = brickPosition.Z }), mergeBricks);
            }
            else
            {
                supports.Add(new Brick(brickPosition, brick.Depth with { Z = brickPosition.Z }), new List<Brick>());
            }
        }

        return supports;
    }

    public bool DoesBricksMerge(Brick brickA, Brick brickB)
    {
        bool doesItMergeOnAxis(float a, float b, float ax, float bx) => (a <= b && ax >= bx) || (b <= a && bx >= ax);

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

