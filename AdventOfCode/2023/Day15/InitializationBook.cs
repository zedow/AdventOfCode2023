using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Kernel;

namespace AdventOfCode._2023.Day15;

using Hashmap = Dictionary<int, List<Lens>>;
public record Lens(int Length, string Name);

[Challenge("Lens Library", "2023/Day15/input.txt")]
public class InitializationBook : IChallenge
{
    public static char[] Operations = new char[] { '=', '-' };
    public object SolvePartOne(string input)
    {
        return input.Split(",").Sum(Hash);
    }

    public object SolvePartTwo(string input)
    {
        Hashmap boxes = new Hashmap();
        var words = input.Split(",").ToList();
        BuildBoxes(boxes, 256);
        words.ForEach(w => Operate(boxes, w));
        return boxes.OrderBy(b => b.Key).Sum(b => b.Value
            .Select((l, index) => (b.Key + 1) * (index + 1) * (l.Length))
            .Sum()
        );
    }

    public void BuildBoxes(Hashmap hashmap, int length) =>
        Enumerable.Range(0, length).ToList().ForEach(index => hashmap.Add(index, new List<Lens>()));

    public void Operate(Hashmap hashmap, string word)
    {
        char operation = Operations.First(op => word.IndexOf(op) != -1);
        string[] stringLensArray = word.Split(operation);
        var boole = int.TryParse(stringLensArray[1], out var length);
        Lens lens = new Lens(boole ? length : 0, stringLensArray[0]);
        int boxKey = Hash(stringLensArray[0]);
        var hashMapIndex = hashmap[boxKey].FindIndex(ll => ll.Name == lens.Name);
        if (operation == '-')
        {
            if (hashMapIndex != -1)
                hashmap[boxKey].RemoveAt(hashMapIndex);
        }

        if(operation == '=')
        {
            if (hashMapIndex != -1)
                hashmap[boxKey][hashMapIndex] = lens;
            else
                hashmap[boxKey].Add(lens);
        }
    }

    public int Hash(string input)
    {
        return (
            from chr in Enumerable.Range(0, input.Length)
            select (int)input[chr]
        ).Aggregate(0,(hashValue, next) => hashValue = ((hashValue + next) * 17) % 256);
    }
}

