using AdventOfCode.Kernel;
using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections.Immutable;
using AdventOfCode._2023.Day10;

namespace AdventOfCode._2023.Day16;

using Map = Dictionary<Complex, char>;

public record Reflection(char mirror, Complex FromDirection);
public record Itenerary(Complex position, Complex direction);

[Challenge("The Floor Will Be Lava", "2023/day16/input.txt")]
public class Lava : IChallenge
{
    public static Complex Up = -Complex.ImaginaryOne;
    public static Complex Down = Complex.ImaginaryOne;
    public static Complex Left = -Complex.One;
    public static Complex Right = Complex.One;

    public static Dictionary<char, Complex[]> Splitters = new Dictionary<char, Complex[]>(2)
    {
        { '|', new Complex[] { Up, Down } },
        { '-', new Complex[] { Left, Right } },
    };

    public static Dictionary<Reflection, Complex> Mirrors = new Dictionary<Reflection, Complex>(4)
    {
        { new Reflection('/',Right), Up },
        { new Reflection('/',Up), Right },
        { new Reflection('/',Down), Left },
        { new Reflection('/',Left), Down },
        { new Reflection('\\',Right), Down },
        { new Reflection('\\',Left), Up },
        { new Reflection('\\',Up), Left },
        { new Reflection('\\',Down), Right },
    };

    public object SolvePartOne(string input)
    {
        var map = ParseMap(input.Split("\r\n"));
        var iteneraries = new List<Itenerary>();
        SpreadBeamRecursively(map,Right,new Complex(0,0), iteneraries);
        return iteneraries.Select(i => i.position).Distinct().Count();
    }

    public object SolvePartTwo(string input)
    {
        throw new NotImplementedException();
    }

    public List<Itenerary> SpreadBeamRecursively(Map map,Complex direction, Complex currentPosition, List<Itenerary> iteneraries)
    {
        var itenerary = new Itenerary(currentPosition, direction);
        if (map.ContainsKey(currentPosition) == false || iteneraries.Contains(itenerary)) {
            return iteneraries;        
        }
        iteneraries.Add(itenerary);
        if (map[currentPosition] == '/' || map[currentPosition] == '\\')
            direction = Mirrors[new Reflection(map[currentPosition], direction)];
        else if (map[currentPosition] == '-' && (direction != Left && direction != Right))
        {
            direction = Left;
            SpreadBeamRecursively(map, Right, currentPosition + Right, iteneraries);
        }
        else if(map[currentPosition] == '|' && (direction != Up && direction != Down))
        {
            direction = Up;
            SpreadBeamRecursively(map, Down, currentPosition + Down, iteneraries);
        }

        SpreadBeamRecursively(map, direction, currentPosition + direction, iteneraries);
        return iteneraries;
    }

    public void Display(Map map)
    {
        var row = 0;
        for(int i = 0; i <= map.Keys.Max(m => m.Real); i++)
        {
            var str = "";
            for(int y = 0; y <= map.Keys.Max(k => k.Imaginary); y++)
            {
                str += map[new Complex(y, i)];
            }
            Console.WriteLine(str);
        }
    }

    public Map ParseMap(string[] input)
    {
        return (
            from irow in Enumerable.Range(0, input.Length)
            from icol in Enumerable.Range(0, input[0].Length)
            let pos = new Complex(icol, irow)
            let chr = input[irow][icol]
            select new KeyValuePair<Complex, char>(pos, chr)
        ).ToDictionary();
    }
}

