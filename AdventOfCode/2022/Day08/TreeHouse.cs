using AdventOfCode.Kernel;
using System.Numerics;
using System.Collections.Immutable;

namespace AdventOfCode._2022.Day08;

using Map = Dictionary<Complex,int>;

[Challenge("Treetop Tree House", "2022/Day08/input.txt")]
public class TreeHouse : IChallenge
{
    private readonly ImmutableArray<Complex> Directions = ImmutableArray.Create([-Complex.ImaginaryOne, -1, Complex.ImaginaryOne, 1]);
    public object SolvePartOne(string input)
    {
        var map = Helpers.ParseIntegerMap(input);
        return map.Count(tree => CheckVisibility(map,tree.Key));
    }

    public object SolvePartTwo(string input)
    {
        var map = Helpers.ParseIntegerMap(input);
        return map.Max(tree => GetViewDistanceScore(map,tree));
    }

    public int GetViewDistanceScore(Map map, KeyValuePair<Complex,int> tree)
    {
        Complex posToUpdate;
        int distance, viewScore = 1;
        foreach (var dir in Directions)
        {
            posToUpdate = tree.Key;
            distance = 0;
            for(;;)
            {
                if(map.ContainsKey(posToUpdate + dir) == false)
                {
                    viewScore *= distance;
                    break;
                }
                if(map[posToUpdate + dir] >= tree.Value)
                {
                    viewScore *= distance + 1;
                    break;
                }
                posToUpdate += dir;
                distance++;
            }
        }
        return viewScore;
    }

    public bool CheckVisibility(Map map, Complex pos)
    {
        Complex posToUpdate;
        foreach (var dir in Directions)
        {
            posToUpdate = pos;
            for(;;)
            {
                posToUpdate += dir;
                if(map.ContainsKey(posToUpdate) == false)
                    return true;
                else if(map[posToUpdate] >= map[pos])
                    break;
            }
        }

        return false;
    }
}