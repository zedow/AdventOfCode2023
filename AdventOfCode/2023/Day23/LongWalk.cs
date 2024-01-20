using AdventOfCode.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.IO;

namespace AdventOfCode._2023.Day23;
using Map = Dictionary<Complex, char>;

public record Path(Complex LastPosition,int Steps);
public record Node(Complex Position, Dictionary<Complex,int> Neighbors);
public record Road(Complex Start, Complex End, int Length);

[Challenge("Long Walk", "2023/Day23/input.txt")]
public class LongWalk : IChallenge
{
    public static Complex[] Directions = new Complex[] { -Complex.ImaginaryOne, Complex.ImaginaryOne, -Complex.One, Complex.One };
    public static Complex[] LeftCorner = new Complex[2] { -Complex.ImaginaryOne, -Complex.One };
    public static Complex[] TopRightCorner = new Complex[2] { -Complex.ImaginaryOne, Complex.One };
    public static Complex[] RightCornerDirections = new Complex[2] { Complex.ImaginaryOne, Complex.One };
    public static Complex[] BottomLeftCornerDirections = new Complex[2] { Complex.ImaginaryOne, -Complex.One };

    public static string ChrDirections = "^v<>";
    public object SolvePartOne(string input) => GetPaths(ParseMap(input)).Select(path => path.Count - 1).Max();

    public object SolvePartTwo(string input)
    {
        var map = ParseMap(input);
        var roads = ConvertMapToGraph(map);
        return GetLongestPathFromNodes(roads);
    }

    public long GetLongestPathFromNodes(HashSet<Road> roads)
    {
        var start = roads.First().Start;
        var end = roads.Last().Start;

        var cache = new Dictionary<Complex, long>();
        long GetLongestPath(Complex node, HashSet<Complex> visited)
        {
            if (node == end)
                return 0;

            if (visited.Contains(node))
                return 0;

            return roads
                .Where(r => r.Start == node)
                .Select(neighbor => neighbor.Length + GetLongestPath(neighbor.End, visited.Append(node).ToHashSet()))
                .Max();
        }

        return GetLongestPath(start, new HashSet<Complex>() { });
    }

    // TODO: Use a cache system to optimize part two node finding
    public HashSet<HashSet<Complex>> GetPaths(Map map, bool canClimbSteepSlopes = false)
    {
        var start = new Complex(1, 0);
        var end = new Complex(map.Max(m => m.Key.Real) -1, map.Max(m => m.Key.Imaginary));
        var queue = new Queue<HashSet<Complex>>();
        queue.Enqueue(new HashSet<Complex>() {  start });
        HashSet<HashSet<Complex>> paths = new HashSet<HashSet<Complex>>();
        while(queue.TryDequeue(out var path))
        {
            if (path.Last() == end)
            {
                paths.Add(path);
                continue;
            }      

            if(!canClimbSteepSlopes && ChrDirections.IndexOf(map[path.Last()]) != -1)
            {
                Complex direction = Directions[ChrDirections.IndexOf(map[path.Last()])];
                if (path.Contains(path.Last() + direction))
                    continue;

                queue.Enqueue(path.Append(path.Last() + direction).ToHashSet());
                continue;
            }

            foreach(var direction in Directions.Where(d => path.Contains(path.Last() + d) == false))
            {
                var nextPosition = path.Last() + direction;
                if(map.ContainsKey(nextPosition) && map[nextPosition] != '#')
                {
                    queue.Enqueue(path.Append(nextPosition).ToHashSet());
                }
            }
        }

        return paths;
    }

    public HashSet<Road> ConvertMapToGraph(Map map)
    {
        var corners = new Dictionary<Complex, Complex[]>
        {
            { new Complex(1, 0), new Complex[1] { Complex.ImaginaryOne } }
        };
        var pathTile = map.Where(m => m.Value != '#').Select(tile => tile.Key);
        var roads = new HashSet<Road>();
        foreach (var tile in pathTile)
        {
            if (LeftCorner.All(d => map.ContainsKey(tile + d) && map[tile + d] == '#'))
                corners.Add(tile, RightCornerDirections);
            else if (RightCornerDirections.All(d => map.ContainsKey(tile + d) && map[tile + d] == '#'))
                corners.Add(tile, LeftCorner);
            else if (TopRightCorner.All(d => map.ContainsKey(tile + d) && map[tile + d] == '#'))
                corners.Add(tile, BottomLeftCornerDirections);
            else if (BottomLeftCornerDirections.All(d => map.ContainsKey(tile + d) && map[tile + d] == '#'))
                corners.Add(tile, TopRightCorner);
            else if (Directions.Count(d => map.ContainsKey(tile + d) && map[tile + d] != '#') >= 3)
                corners.Add(tile,Directions.Where(d => map.ContainsKey(tile + d) && map[tile + d] != '#').ToArray());
        }
        corners.Add(new Complex(map.Max(m => m.Key.Real) - 1, map.Max(m => m.Key.Imaginary)), new Complex[1] { -Complex.ImaginaryOne });
        foreach(var corner in corners)
        {
            foreach (var direction in corner.Value)
            {
                var startPosition = corner.Key + direction;
                int distance = 1;
                while(corners.Any(otherCorner => otherCorner.Key == startPosition) == false)
                {
                    startPosition += direction;
                    distance++;
                }

                roads.Add(new Road(corner.Key,startPosition, distance));
            }
        }

        return roads;
    }

    public Map ParseMap(string input)
    {
        var rows = input.Split("\r\n");
        return (
            from irow in Enumerable.Range(0, rows.Length)
            from icol in Enumerable.Range(0, rows[0].Length)
            let pos = new Complex(icol, irow)
            let chr = rows[irow][icol]
            select new KeyValuePair<Complex,char>(pos, chr)
        ).ToDictionary(k => k.Key, k => k.Value);
    }
}

public class PriorityQueueComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x > y)
            return -1;
        if (x == y)
            return 0;
        return 1;
    }
}

