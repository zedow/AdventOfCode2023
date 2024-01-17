using AdventOfCode.Kernel;
using Kernel;

namespace AdventOfCode._2022.Day03;

[Challenge("Rucksack Reorganization", "2022/Day03/input.txt")]
public class Rucksack : IChallenge
{
    public string alphabet = "abcdefghijklmnopqrstuvwxyz";
    public object SolvePartOne(string input) 
        => input.Split('\n').Select(ParsePriority).Sum();

    public object SolvePartTwo(string input)
        => input.Split('\n').Chunk(3).Select(ParsePriorityPartTwo).Sum();

    public int ParsePriority(string row)
    {
        string firstPart = row[..(row.Length / 2)];
        string secondPart = row.Substring(row.Length / 2, row.Length / 2);
        string letterSharedInBothparts = firstPart.First(l => secondPart.Contains(l)).ToString();
        int shifter = char.IsUpper(letterSharedInBothparts[0]) ? 27 : 1;
        return alphabet.IndexOf(letterSharedInBothparts, StringComparison.CurrentCultureIgnoreCase) + shifter;
    }

    public int ParsePriorityPartTwo(string[] rows)
    {
        string firstRow = rows.First();
        string[] otherRows = rows.Skip(1).ToArray();     
        string letterSharedInBothparts = firstRow.First(letter => otherRows.All(o => o.Contains(letter))).ToString();
        int shifter = char.IsUpper(letterSharedInBothparts[0]) ? 27 : 1;
        return alphabet.IndexOf(letterSharedInBothparts, StringComparison.CurrentCultureIgnoreCase) + shifter;
    }
}