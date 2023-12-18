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
        return DigOutInterior(Dig(ParseInput(input))).Count();
    }

    public object SolvePartTwo(string input)
    {
        return DigOutInterior(Dig(ParseInput(input))).Count();
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

    // Pick's theorem & Shoelace formula to apply for this
    public Map DigOutInterior(Map map)
    {
        Console.WriteLine(map.MinBy(m => m.Key.Imaginary).Key.Imaginary);
        Console.WriteLine(map.MinBy(m => m.Key.Real).Key.Real);
        var text = "";
        for (double i = map.MinBy(m => m.Key.Imaginary).Key.Imaginary; i <= map.MaxBy(m => m.Key.Imaginary).Key.Imaginary; i++)
        {
            Complex? lastEdgePosition = null;
            int numberOfEdgeMet = 0;
            string color = "";
            string line = "";
            for(double y = map.MinBy(m => m.Key.Real).Key.Real; y <= map.MaxBy(m => m.Key.Real).Key.Real; y++)
            {
                var position = new Complex(y, i);
                if (map.ContainsKey(position))
                {
                    if (lastEdgePosition == null || (position - lastEdgePosition) != Complex.One)
                    {
                        numberOfEdgeMet++;
                    }

                    lastEdgePosition = position;
                    line += "#";
                    color = map[position];
                }
                else if (numberOfEdgeMet != 4 && numberOfEdgeMet % 2 != 0)
                {
                    map.Add(position, color);
                    line += "@";
                }
                else
                    line += ".";
            }
            text += line += "\r\n";
        }


        File.AppendAllLines("..\\..\\..\\2023\\Day18\\output.txt", text.Split("\r\n"));
        return map;
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

