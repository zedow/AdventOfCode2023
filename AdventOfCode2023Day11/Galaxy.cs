using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day11;

public class Galaxy
{
    public static string[] ParseMap(string input)
    {
        string[] rows = input.Split("\r\n").Select(str => str.Trim()).ToArray();
        return rows;
    }

    public static BigInteger SolvePartOne(string input) => Solve(input, 1);
    public static BigInteger SolvePartTwo(string input) => Solve(input, 999999);
    public static BigInteger Solve(string input,int expandValue)
    {
        var map = ParseMap(input);

        var emptyRows = EmptyRows(map).ToHashSet();
        var emptyColumns = EmptyColumns(map).ToHashSet();
        Func<int,bool> isRowExpanded = emptyRows.Contains;
        Func<int, bool> isColumnExpanded = emptyColumns.Contains;

        List<Vector2> galaxies = (
            from irow in Enumerable.Range(0, map.Length)
            from icol in Enumerable.Range(0, map[0].Length)
            where map[irow][icol] == '#'
            select new Vector2(irow, icol)
        ).ToList();

        var galaxyQueue = new Queue<Vector2>();
        galaxies.ForEach(galaxyQueue.Enqueue);
        BigInteger totalPath = 0;
        while(galaxyQueue.Count > 0)
        {
            var galaxy = galaxyQueue.Dequeue();
            totalPath += FindPath(galaxy, galaxyQueue, isRowExpanded, isColumnExpanded, expandValue);
        }

        return totalPath;
    }

    public static IEnumerable<int> EmptyRows(string[] map) => (
        from irow in Enumerable.Range(0, map.Length)
        where map[irow].All(m => m == '.')
        select irow
    );

    public static IEnumerable<int> EmptyColumns(string[] map) => (
        from icol in Enumerable.Range(0, map[0].Length)
        where map.All(m => m[icol] == '.')
        select icol
    );

    public static BigInteger FindPath(Vector2 galaxy, IEnumerable<Vector2> galaxies, Func<int, bool> isRowExpanded, Func<int, bool> isColumnExpanded, int expandValue)
    {
        BigInteger pathCount = 0;
        foreach(var otherGalaxy in galaxies)
        {
            var distanceX = Math.Abs(otherGalaxy.X - galaxy.X);
            var distanceY = Math.Abs(otherGalaxy.Y - galaxy.Y);
            pathCount += distanceX + distanceY;
            pathCount += expandValue * Enumerable.Range(Math.Min(otherGalaxy.X, galaxy.X),distanceX).Count(isRowExpanded);
            pathCount += expandValue * Enumerable.Range(Math.Min(otherGalaxy.Y, galaxy.Y), distanceY).Count(isColumnExpanded);
        }
        return pathCount;
    }
}
