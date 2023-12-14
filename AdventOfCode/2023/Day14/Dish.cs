using AdventOfCode.Kernel;
using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2023.Day14;

[Challenge("Parabolic Reflector Dish","2023/Day14/input.txt")]
public class Dish : IChallenge
{
    public object SolvePartOne(string input)
    {
        return LoopMapReturnTotalLoad(ParseMap(input));
    }

    public object SolvePartTwo(string input)
    {
        throw new NotImplementedException();
    }

    public int LoopMapReturnTotalLoad(string[] map)
    {
        var weight = 0;
        for (int i = 0; i < map.Length; i++)
        {
            var accumulator = 0;
            var rocks = 0;
            void incrementLoad() {
                weight += Enumerable.Range(0, rocks).Sum(r => accumulator - r);
                accumulator = 0;
                rocks = 0;
            }
            for (int y = map[i].Length -1; y >= 0; y--)
            {
                var cell = map[i][y];
                if (cell == 'O')
                {
                    rocks++;
                    accumulator = map[i].Length - y;
                    continue;
                }

                if (cell == '.')
                {
                    accumulator = map[i].Length - y;
                    continue;
                }

                incrementLoad();
            }
            accumulator = map[i].Length;
            incrementLoad();
        }
        return weight;
    }
    public string[] ParseMap(string input)
    {
        var inputArray = input.Split("\r\n");
        return (
            from icol in Enumerable.Range(0, inputArray[0].Length)
            let col = (
                from irow in Enumerable.Range(0, inputArray.Length)
                select inputArray[irow][icol]
            )
            select new string(col.ToArray())
        ).ToArray();
    }
}
