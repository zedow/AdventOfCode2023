using AdventOfCode.Kernel;
using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections.Immutable;

namespace AdventOfCode._2023.Day21;

using Map = Dictionary<Complex, char>;

[Challenge("Step Counter", "2023/Day21/input.txt")]
public class StepCounter : IChallenge
{
    public static ImmutableHashSet<Complex> Directions = ImmutableHashSet.Create(
        -Complex.ImaginaryOne,
        Complex.ImaginaryOne,
        -Complex.One,
        Complex.One
    );

    public object SolvePartOne(string input) => FindPaths(ParseMap(input), 64);

    public object SolvePartTwo(string input)
    {
        throw new NotImplementedException();
    }

    public int FindPaths(Map map, int maximumSteps)
    {
        var paths = new List<List<Complex>>();
        var queue = new Queue<List<Complex>>();
        queue.Enqueue(new List<Complex> { map.First(m => m.Value == 'S').Key });
        while(queue.Count > 0)
        {
            List<Complex> pathToExplore = queue.Dequeue();
            if (pathToExplore.Count > maximumSteps)
            {
                paths.Add(pathToExplore);
                continue;
            }
            foreach (Complex direction in Directions)
            {
                var next = pathToExplore.Last() + direction;
                // check next direction exists, if it's garden plots and if queue doesn't already contains a similar path 
                if (map.ContainsKey(next) && map[next] != '#' && queue.Any(path => path.Count == pathToExplore.Count + 1 && path.Last() == next) == false)
                    queue.Enqueue(pathToExplore.Append(next).ToList());
            }
        }

        var distinctsPath = paths.DistinctBy(path => path.Last()).ToList();
        return distinctsPath.Count();
    }

    public Map ParseMap(string input)
    {
        var lines = input.Split("\r\n");
        return (
            from irow in Enumerable.Range(0, lines.Length)
            from icol in Enumerable.Range(0, lines[0].Length)
            let pos = new Complex(icol, irow)
            let chr = lines[irow][icol]
            select new KeyValuePair<Complex, char>(pos, chr)
        ).ToDictionary();
    }
}

