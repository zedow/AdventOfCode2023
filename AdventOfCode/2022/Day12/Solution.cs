using AdventOfCode.Kernel;
using System.Collections;

namespace AdventOfCode._2022.Day12;

using Map = Dictionary<MyVector,char>;
public record Node(MyVector Pos, int Steps,int Elevation);
[Challenge("Hill Climbing Algorithm","2022/Day12/input.txt")]
public class Solution : IChallenge
{
    public object SolvePartOne(string input)
    {
        var map = ParseMap(input);
        var nodes = HillClimb(map);
        return nodes.Single(n => n.Value.Elevation == 0).Value.Steps;
    }

    public object SolvePartTwo(string input)
    {
        var map = ParseMap(input);
        var nodes = HillClimb(map);
        return nodes.Where(n => n.Value.Elevation == 1).Select(n => n.Value.Steps).Min();
    }

    // Breadth-first search algorithm implementation, optimal for unweighted graphs
    public Dictionary<MyVector,Node> HillClimb(Map map)
    {
        MyVector start = map.First(m => m.Value == 'E').Key;
        var queue = new Queue<Node>();
        var startNode = new Node(start,0,27);
        queue.Enqueue(startNode);
        Dictionary<MyVector,Node> visitedNodes = [];
        visitedNodes.Add(start,startNode);
        while(queue.TryDequeue(out Node? node))
        {
            foreach(var dir in MyVector.Directions)
            {
                var next = node.Pos + dir;
                if(visitedNodes.ContainsKey(next))
                    continue;

                if(map.TryGetValue(next, out char value))
                {
                    if(node.Elevation - GetElevation(value) <= 1)
                    {
                        var nextNode = new Node(next,node.Steps + 1,GetElevation(value));
                        visitedNodes.Add(next,nextNode);
                        queue.Enqueue(nextNode);
                    }
                }
            }
        }
        return visitedNodes;
    }

    public int GetElevation(char pos)
    {
        if(pos == 'E') {
            return 27;
        }
        if(pos == 'S') {
            return 0;
        }
        return pos % 32;
    }

    public Map ParseMap(string input)
    {
        var lines = input.Split('\n');
        return (
            from irow in Enumerable.Range(0,lines.Length)
            from icol in Enumerable.Range(0,lines[0].Length)
            let pos = new MyVector(icol,irow)
            let elevation = lines[irow][icol]
            select new KeyValuePair<MyVector,char>(pos,elevation)
        ).ToDictionary(keySelector => keySelector.Key, keySelector => keySelector.Value);
    }


    class PriorityQueueComparer : IComparer<int>
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
}