using AdventOfCode.Kernel;
using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using AdventOfCode._2023.Day10;
using System.Collections.Immutable;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace AdventOfCode._2023.Day14;

using Map = Dictionary<Complex,char>;

[Challenge("Parabolic Reflector Dish","2023/Day14/input.txt")]
public class Dish : IChallenge
{
    public static Complex Up = -Complex.ImaginaryOne;
    public static Complex Down = Complex.ImaginaryOne;
    public static Complex Left = -Complex.One;
    public static Complex Right = Complex.One;

    public static int MapWidth = 10;
    public static int MapHeight = 10;

    int Measure(char[][] map) =>
       map.Select((row, irow) => (MapWidth - irow) * row.Count(ch => ch == 'O')).Sum();

    public object SolvePartOne(string input)
    {
        var map = MoveRoundedRocks(ParseMap(input), Up);
        return Measure(MapToString(map).Split('\n').Select(line => line.ToCharArray()).ToArray());
    }

    public object SolvePartTwo(string input)
    {
        var map = ParseMap(input);
        List<string> history = new List<string>();
        var count = 1000000000;
        while (count > 0)
        {
            map = MoveRoundedRocks(map, Up);
            map = MoveRoundedRocks(map, Left);
            map = MoveRoundedRocks(map, Down);
            map = MoveRoundedRocks(map, Right);
            count--;
            var mapString = MapToString(map);
            var idx = history.IndexOf(mapString);
            if (idx < 0)
                history.Add(mapString);
            else
            {
                var loopLength = history.Count - idx;
                var remainder = count % loopLength;
                return Measure(history[idx + remainder].Split('\n').Select(line => line.ToCharArray()).ToArray());
            }
        }
        
        return 0;
    }

    public Map MoveRoundedRocks(Map map, Complex direction)
    {
        var rocks = map.Where(m => m.Value != '#' && m.Value != '.').ToList();
        foreach (var roundedRocks in rocks)
        {
            var position = roundedRocks.Key;
            // store the last valid position to prevent other rounded rock overwrite
            var validPosition = position;
            for (; ; )
            {
                if (map.ContainsKey(position + direction) == false)
                {
                    if (map[position - direction] == '.')
                    {
                        position = validPosition;
                    }
                    break;
                }

                if (map[position + direction] == '#')
                {
                    position = validPosition;
                    break;
                }

                if (map[position + direction] == '.')
                {
                    validPosition = position + direction;
                }

                position += direction;
            }
            if (validPosition != roundedRocks.Key)
            {
                map[validPosition] = 'O';
                map[roundedRocks.Key] = '.';
            }
        }
        return map;
    }

    public Map ParseMap(string input)
    {
        var inputArray = input.Split("\r\n");
        MapWidth = inputArray[0].Length;
        MapHeight = inputArray.Length;
        return (
            from irow in Enumerable.Range(0, inputArray.Length)
            from icol in Enumerable.Range(0, inputArray[0].Length)
            let pos = new Complex(icol,irow)
            let cell = inputArray[irow][icol]
            select new KeyValuePair<Complex,char>(pos,cell)
        ).ToDictionary();
    }

    public string MapToString(Map map)
    {
        var stringMap = "";
        for (int i = 0; i < MapHeight; i++)
        {
            string str = "";
            for (int y = 0; y < MapWidth; y++)
            {
                str += map[new Complex(y, i)];
            }
            if (i < (MapHeight - 1))
                str += "\r\n";
            stringMap += str;
        }
        return stringMap;
    }
}
