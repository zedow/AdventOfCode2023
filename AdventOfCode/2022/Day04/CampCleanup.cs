using AdventOfCode.Kernel;
using Kernel;

namespace AdventOfCode._2022.Day04;

public record Assignment((int,int) AssignmentA, (int,int) AssignmentB);

[Challenge("Camp Cleanup", "2022/Day04/input.txt")]
public class CampCleanup : IChallenge
{
    public object SolvePartOne(string input)
        => ParseInput(input).Count(IsAssignmentBad);

    public object SolvePartTwo(string input)
        => ParseInput(input).Count(IsAssignmentBadPartTwo);

    public static List<Assignment> ParseInput(string input)
    {
        var rows = input.Split('\n');
        return (
            from irow in Enumerable.Range(0,rows.Length)
            let assignments = rows[irow].Replace('-',' ').Split(',')
            let assignmentA = MyFileReader.ParseIntegers(assignments.First())
            let assignmentB = MyFileReader.ParseIntegers(assignments.Last())
            select new Assignment((assignmentA.First(), assignmentA.Last()), (assignmentB.First(), assignmentB.Last()))
        ).ToList();
    }

    public static bool IsAssignmentBad(Assignment assignment)
    {
        if(assignment.AssignmentA.Item1 <= assignment.AssignmentB.Item1 && assignment.AssignmentA.Item2 >= assignment.AssignmentB.Item2)
            return true;

        if(assignment.AssignmentB.Item1 <= assignment.AssignmentA.Item1 && assignment.AssignmentB.Item2 >= assignment.AssignmentA.Item2)
            return true;

        return false;
    }

    public static bool IsAssignmentBadPartTwo(Assignment assignment)
    {
        if(IsAssignmentBad(assignment))
            return true;
        if(assignment.AssignmentA.Item1 >= assignment.AssignmentB.Item1 && assignment.AssignmentA.Item1 <= assignment.AssignmentB.Item2)
            return true;
        if(assignment.AssignmentA.Item2  >= assignment.AssignmentB.Item1 && assignment.AssignmentA.Item2 <= assignment.AssignmentB.Item2)
            return true;

        return false;
    }
}