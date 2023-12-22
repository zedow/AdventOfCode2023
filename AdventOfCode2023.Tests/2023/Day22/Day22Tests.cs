using AdventOfCode._2023.Day22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AdventOfCode2023.Tests._2023.Day22;
using BrickSupports = Dictionary<Brick,List<Brick>>;
internal class Day22Tests
{
    [Test]
    public void SimulateGravity_should_update_bricks_position()
    {
        List<Brick> bricks = new List<Brick>
        {
            new Brick(new Vector3(1,0,1),new Vector3(1,2,1)),
            new Brick(new Vector3(0,0,2),new Vector3(2,0,2)),
            new Brick(new Vector3(0,2,3), new Vector3(2,2,3))
        };
        var sandSlabs = new SandSlabs();
        var expectedSequence = new BrickSupports
        {
            { new Brick(new Vector3(1,0,1),new Vector3(1,2,1)), new List<Brick>() },
            { new Brick(new Vector3(0,0,2),new Vector3(2,0,2)), new List<Brick>() {new Brick(new Vector3(1,0,1),new Vector3(1,2,1)) } },
            { new Brick(new Vector3(0, 2, 2), new Vector3(2, 2, 2)), new List<Brick>() { new Brick(new Vector3(1, 0, 1), new Vector3(1, 2, 1)) } },
        };

        var brickSupports = sandSlabs.SimulateGravity(bricks).Select(b => b.Key).ToList();

        Assert.That(brickSupports.SequenceEqual(expectedSequence.Select(b => b.Key).ToList()), Is.True);
    }

    [Test]
    public void SolvePartOne_should_return_5()
    {
        var input = File.ReadAllText("../../../2023/Day22/input.txt");
        var sandSlabs = new SandSlabs();

        var countBricksThatCanBeDisintegrated = sandSlabs.SolvePartOne(input);

        Assert.That(countBricksThatCanBeDisintegrated, Is.EqualTo(5));
    }
}

