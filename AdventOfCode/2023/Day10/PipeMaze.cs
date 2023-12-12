using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Kernel;

namespace AdventOfCode._2023.Day10;

using Map = Dictionary<(int, int), char>;

public static class Direction
{
    public static (int, int) Left = (0, -1);
    public static (int, int) Right = (0, 1);
    public static (int, int) Up = (-1, 0);
    public static (int, int) Down = (1, 0);
}

[Challenge("Pipe maze")]
public class PipeMaze
{
    Dictionary<char, (int, int)[]> Pipes = new Dictionary<char, (int, int)[]>
    {
        { '|', new (int, int)[] { Direction.Up, Direction.Down } },
        { '-', new (int, int)[] { Direction.Left, Direction.Right } },
        { 'L', new (int, int)[] { Direction.Right, Direction.Up } },
        { 'J', new (int, int)[] { Direction.Up, Direction.Left } },
        { '7', new (int, int)[] { Direction.Left, Direction.Down } },
        { 'F', new (int, int)[] { Direction.Right, Direction.Down } },
        { '.', new (int, int)[] { } }
    };

    List<(int, int)>? MainLoopPipesPosition;

    public int SolvePartOne(string[] input, (int, int)[] startPointDirections)
    {
        Map map = ParseMap(input);
        return FollowPipes(map, startPointDirections);
    }

    public int SolvePartTwo(string[] input, (int, int)[] startPointDirections)
    {
        Map map = ParseMap(input);
        FollowPipes(map, startPointDirections);
        return CountEnclosedTiles(map);
    }

    public int FollowPipes(Map map, (int, int)[] startPointDirections)
    {
        MainLoopPipesPosition = new List<(int, int)>();      
        KeyValuePair<(int,int), char> sourcePosition = map.First(m => m.Value == 'S');
        Pipes.Add(sourcePosition.Value, startPointDirections);
        var currentPipe = sourcePosition.Key;
        var previousDirection = startPointDirections[0];
        int counter = 0;
        while (currentPipe != sourcePosition.Key || counter == 0)
        {
            if (currentPipe == (0, 0))
                Console.WriteLine("zeobe");
            MainLoopPipesPosition.Add(currentPipe);
            var direction = Pipes[map[currentPipe]].First(direction => direction != (previousDirection.Item1 * -1, previousDirection.Item2 * -1));
            var nextPipe = (currentPipe.Item1 + direction.Item1, currentPipe.Item2 + direction.Item2);
            previousDirection = direction;
            currentPipe = nextPipe;
            counter++;
        }
        return counter / 2;
    }

    public int CountEnclosedTiles(Map map)
    {
        if (MainLoopPipesPosition == null)
            throw new Exception("Please run FollowPipes to find main loop before looking for enclosed tiles");

        var grassTiles = map.Where(p => MainLoopPipesPosition.Contains(p.Key) == false).ToList();
        int enclosedPipes = 0;
        foreach (var grassTile in grassTiles)
        {
            var index = grassTile.Key.Item2;
            bool isEnclosed = false;
            while (map.ContainsKey((grassTile.Key.Item1, index)))
            {
                if (MainLoopPipesPosition.Contains((grassTile.Key.Item1, index)) && Pipes[map[(grassTile.Key.Item1, index)]].Contains(Direction.Up))
                    isEnclosed = !isEnclosed;

                index--;
            }

            if (isEnclosed)
            {
                enclosedPipes++;
            }
        }

        return enclosedPipes;
    }

    public Map ParseMap(string[] input)
    {
        return (
            from irow in Enumerable.Range(0,input.Length)
            from icol in Enumerable.Range(0, input[0].Length)
            let position = (irow,icol)
            let chr = input[irow][icol]
            select new KeyValuePair<(int,int),char>(position,chr)
        ).ToDictionary(t => t.Key,t => t.Value);
    }
}

