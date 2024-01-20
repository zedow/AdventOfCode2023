using AdventOfCode.Kernel;

namespace AdventOfCode._2022.Day05;

public record Procedure(int Number, int From, int To);

[Challenge("Supply Stacks", "2022/Day05/input.txt")]
public class SupplyStacks : IChallenge
{
    public object SolvePartOne(string input) => ApplyProceduresGetMessage(input,false);

    public object SolvePartTwo(string input) => ApplyProceduresGetMessage(input, true);

    public static string ApplyProceduresGetMessage(string input, bool keepOrder)
    {
        var stacks = ParseStacksFromInput(input);
        var procedures = ParseProcedures(input);
        foreach(var proc in procedures) {
            var supplies = new List<char>();
            for(int i = 0; i < proc.Number; i++) {
                supplies.Add(stacks[proc.From].Pop());
            }
            if(keepOrder)
                supplies.Reverse();
                
            supplies.ForEach(s => stacks[proc.To].Push(s));
        }
        return string.Join("", stacks.Select(s => s.Peek()));
    }

    public static List<Procedure> ParseProcedures(string input)
    {
        var stacksAndProcedures = input.Split("\n\n",StringSplitOptions.RemoveEmptyEntries);
        var procedures = stacksAndProcedures.Last().Split('\n');
        return (
            from irow in Enumerable.Range(0,procedures.Length)
            let integers = MyFileReader.ParseIntegers(procedures[irow])
            select new Procedure(integers[0],integers[1] - 1,integers[2] - 1)
        ).ToList();
    }

    public static Stack<char>[] ParseStacksFromInput(string input)
    {
        var stacksAndProcedures = input.Split("\n\n",StringSplitOptions.RemoveEmptyEntries);
        var stacks = stacksAndProcedures.First().Split('\n').SkipLast(1).ToArray();
        // -2 to skip last line containing ids
        var charStacks = new HashSet<Stack<char>>();
        return (
            from icol in Enumerable.Range(0, stacks[0].Length)
            where icol % 4 == 1
            select new Stack<char>((
                from irow in Enumerable.Range(1, stacks.Length)
                where char.IsLetter(stacks[^irow][icol])
                select stacks[^irow][icol]
            ))
        ).ToArray();
    }
}