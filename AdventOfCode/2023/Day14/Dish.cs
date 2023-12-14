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
    public object SolvePartOne(string input)
    {
        return MoveRoundedRocks(ParseMap(input), Up);
    }

    public object SolvePartTwo(string input)
    {
        var map = ParseMap(input);
        List<string> history = new List<string>();
        for(int i = 0; i < 1000000000; i++)
        {
            for(int y = 0; y < 4; y++)
            {
                var zebi = MoveRoundedRocks(map, Up);
                var zobi = MoveRoundedRocks(map, Left);
                var ebi = MoveRoundedRocks(map, Down);
                var aa = MoveRoundedRocks(map, Right);
                Console.WriteLine(zebi + " " + zobi + " " + ebi + " " + aa);
            }
            var mapString = new string(((char[])map.Values.ToArray()));
            var idx = history.IndexOf(mapString);
            if (idx < 0)
                history.Add(mapString);
            else
            {
                var loopLength = history.Count - idx;
                var remainder = i % loopLength;
                //return MoveRoundedRocks(ParseMap(history[idx + remainder]),Up);
                return MoveRoundedRocks(map, Up);
            }
        }
        
        return 0;
    }

    public int MoveRoundedRocks(Map map, Complex direction)
    {
        var load = 0;
        var verticalLimit = map.Max(m => m.Key.Imaginary) + 1;
        var horizontalLimit = map.Max(m => m.Key.Real) + 1;
        var rocks = map.Where(m => m.Value != '#' && m.Value != '.').ToList();
        foreach (var roundedRocks in rocks)
        {
            var position = roundedRocks.Key;
            // must be equal 1 so current position is count
            var numberOfTilesAtOppositeDirection = 1;
            for(; ; )
            {
                if (map.ContainsKey(position - direction) == false)
                    break;

                position -= direction;
                numberOfTilesAtOppositeDirection++;
            }
            position = roundedRocks.Key;
            // store the last valid position to prevent other rounded rock overwrite
            var validPosition = position;
            var validNumberOfTilesAtOppositeDirection = numberOfTilesAtOppositeDirection;
            for (; ; )
            {
                if (map.ContainsKey(position + direction) == false)
                {
                    if (map[position - direction] == '.')
                    {
                        position = validPosition;
                        validNumberOfTilesAtOppositeDirection = numberOfTilesAtOppositeDirection;
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
                    validNumberOfTilesAtOppositeDirection = numberOfTilesAtOppositeDirection + 1;
                    validPosition = position + direction;
                }

                position += direction;
                numberOfTilesAtOppositeDirection++;
            }
            int diff = (int)(direction.Real != 0 ? direction.Real == -1 ? horizontalLimit - Math.Abs(validPosition.Real) : validPosition.Real + 1
               : direction.Imaginary == -1 ? verticalLimit - Math.Abs(validPosition.Imaginary) : validPosition.Imaginary + 1);
            if (validPosition != roundedRocks.Key)
            {
                map[validPosition] = diff == 10 ? 'X' : diff.ToString().ToCharArray()[0];
                map[roundedRocks.Key] = '.';
            }
            else
            {
                map[roundedRocks.Key] = diff == 10 ? 'X' : diff.ToString().ToCharArray()[0];
            }
           
            load += diff;
        }
        //DisplayMap(map);
        return load;
    }

    public void DisplayMap(Map map)
    {
        for(int i = 0; i < 10; i ++)
        {
            string str = "";
            for (int y = 0; y < 10; y ++)
            {
                str += map[new Complex(y, i)];
            }
            Console.WriteLine(str);
            
        }
        Console.WriteLine("--------------------------------------------------");
    }

    public Map ParseMap(string input)
    {
        var inputArray = input.Split("\r\n");
        return (
            from irow in Enumerable.Range(0, inputArray.Length)
            from icol in Enumerable.Range(0, inputArray[0].Length)
            let pos = new Complex(icol,irow)
            let cell = inputArray[irow][icol]
            select new KeyValuePair<Complex,char>(pos,cell)
        ).ToDictionary();
    }
}
