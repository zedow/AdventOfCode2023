using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Kernel;
using Kernel;
using System.Numerics;

namespace AdventOfCode._2023.Day18;

using Map = Dictionary<Complex, string>;
public record DigPlan(Complex Direction, int Meters, string Color);

[Challenge("Lavaduct Lagoon", "2023/Day18/input.txt")]
public class LavaLagoon : IChallenge
{
    public object SolvePartOne(string input)
    {
        Console.WriteLine(Dig(ParseInput(input)).Count());
        return CountVerticeInPolygon(Dig(ParseInput(input)));
    }

    public object SolvePartTwo(string input)
    {
        var map = Dig(ParseInput(input));
        return CountVerticeInPolygon(map) + map.Count();
    }

    public Map Dig(List<DigPlan> plans)
    {
        var lagoon = new Map();
        Complex position = new Complex(0,0);
        foreach(var plan in plans)
        {
            for(int i = 0; i < plan.Meters; i++)
            {
                if (lagoon.ContainsKey(position))
                    continue;

                lagoon.Add(position, plan.Color);
                position += plan.Direction;
            }  
        }

        return lagoon;
    }

    public double CountVerticeInPolygon(Map map)
    {
        // Shoelace formula to find area of the polygon
        var sum1 = 0;
        var sum2 = 0;
        for(int i = map.Count- 1; i > 0; i--)
        {
            sum1 = sum1 + (int)(map.ElementAt(i).Key.Real * map.ElementAt(i- 1).Key.Imaginary);
            sum2 = sum2 + (int)(map.ElementAt(i).Key.Imaginary * map.ElementAt(i - 1).Key.Real);
        }

        sum1 = sum1 + (int)(map.ElementAt(0).Key.Real * map.ElementAt(map.Count() - 1).Key.Imaginary);
        sum2 = sum2 + (int)(map.ElementAt(map.Count() - 1).Key.Real * map.ElementAt(0).Key.Imaginary);

        var area = Math.Abs(sum1 - sum2) / 2;

        // We want to find i with A = i + b/2  - 1 (Pick's theorem)
        return area - (0.5 * map.Count()) + 1;
    }

    public Complex TransposeDirection(string direction)
        => direction switch
        {
            "R" => Complex.One,
            "L" => -Complex.One,
            "U" => -Complex.ImaginaryOne,
            "D" => Complex.ImaginaryOne,
            _ => throw new Exception("Direction doesn't exist")
        };

    public List<DigPlan> ParseInput(string input)
    {
        var lines = input.Split("\r\n");
        return (
            from irow in Enumerable.Range(0, lines.Length)
            let words = lines[irow].Split(" ")
            select new DigPlan(TransposeDirection(words[0]), int.Parse(words[1]), words[2])
        ).ToList();
    }
}

