using AdventOfCode.Kernel;
using System.Collections.Immutable;
using System.ComponentModel.Design;

namespace AdventOfCode._2022.Day10;

public record Signal(int Cycle, int Value);

[Challenge("Cathode-Ray Tube", "2022/Day10/input.txt")]
public class CathodeRayTube : IChallenge
{
    private readonly ImmutableArray<int> Cycles = ImmutableArray.Create([20,60,100,140,180,220]);

    public object SolvePartOne(string input)
        => GetCyclesValues(input)
            .Where(v => Cycles.Contains(v.Cycle))
            .Select(signal => signal.Cycle * signal.Value)
            .Sum();

    public object SolvePartTwo(string input)
    {
        return GetCyclesValues(input)
        .Select(signal => 
            {
                var signalPosition = (signal.Cycle - 1) % 40;
                var spritePosition = signal.Value;
                return Math.Abs(spritePosition - signalPosition) < 2 ? '#' : '.'; 
            })
        .Chunk(40)
        .Select(pixelLine => new string(pixelLine))
        .Aggregate("",(output, line) => output += line + "\n");
    }

    public static IEnumerable<Signal> GetCyclesValues(string input)
    {
        var xValue = 1;
        var cycle = 1;
        foreach(var line in input.Split('\n'))
        {
            if(line.StartsWith("addx")) {
                var signal = new Signal(cycle,xValue);
                yield return signal;
                cycle++;
                yield return signal with { Cycle = cycle };
                xValue += int.Parse(line.Split(' ')[1]);
                cycle++;
            }
            else {
                yield return new Signal(cycle,xValue);
                cycle++;
            }
        }
    }
}