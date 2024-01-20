using AdventOfCode.Kernel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2023.Day19;


using Rules = List<Operation>;
using WorkFlow = Dictionary<string, List<Operation>>;
public record Operation(char Category, string Destination, int Value, char Operator);

[Challenge("Aplenty", "2023/Day19/input.txt")]
public class AplentyWorkflow : IChallenge
{
    public static string PartDefinition = "xmas";
    public object SolvePartOne(string input)
    {
        var rulesAndParts = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
        WorkFlow workflow = ParseWorkFlows(rulesAndParts[0]);
        List<int[]> parts = ParseParts(rulesAndParts[1]);
        return parts.Select(part => ProcessPartThroughWorkflow(part, workflow)).Sum();
    }

    public object SolvePartTwo(string input)
    {
        return 0;
    }

    public int ProcessPartThroughWorkflow(int[] part, WorkFlow workFlow)
    {
        var nextRule = "in";
        while(nextRule != "A" && nextRule != "R")
        {
            for(int i = 0; i < workFlow[nextRule].Count; i++)
            {
                var category = workFlow[nextRule].ElementAt(i).Category;
                Operation operation = workFlow[nextRule].ElementAt(i);
                var valueToMatch = category == 'r' ? 0 : part[PartDefinition.IndexOf(category)];
                var nextDestination = Operate(operation, valueToMatch);
                if (nextDestination != string.Empty)
                {
                    nextRule = nextDestination;
                    break;
                }
            }
        }

        return nextRule == "A" ? part.Sum() : 0;
    }

    public string Operate(Operation operation, int Value)
    {
        if (operation.Operator == '>')
            return Value > operation.Value ? operation.Destination : string.Empty;
        else if (operation.Operator == '<')
            return Value < operation.Value ? operation.Destination : string.Empty;
        else
            return operation.Destination;
    }

    public List<int[]> ParseParts(string input)
    {
        var lines = input.Split("\r\n");
        return (
            from irow in Enumerable.Range(0, lines.Length)
            let numbers = MyFileReader.ParseIntegers(lines[irow])
            select new int[4] { numbers[0], numbers[1], numbers[2], numbers[3] }
        ).ToList();
    }

    public WorkFlow ParseWorkFlows(string input)
    {
        var lines = input.Split("\r\n");
        var workFlows = new WorkFlow();
        foreach(var line in lines)
        {
            var workflowName = line.Substring(0, line.IndexOf('{'));
            var stringRules = line.Substring(line.IndexOf('{') + 1, line.Length - (line.IndexOf('{') + 2)).Split(",");
            var rules = new Rules();
            foreach(var rule in stringRules)
            {
                var operation = BuildRule(rule);
                rules.Add(operation);
            }
            workFlows.Add(workflowName,rules);
        }
        return workFlows;
    }

    // r doesn't exist, it's a random char because this rule doesn't fit any part category
    public Operation BuildRule(string rule)
    {
        var operationAndDestination = rule.Split(":");
        int valueComparison = MyFileReader.ParseIntegers(operationAndDestination[0]).FirstOrDefault();
        if (operationAndDestination.Length == 1)
            return new Operation('r', operationAndDestination[0], 0,'@');

        string destination = operationAndDestination[1];
        char category = operationAndDestination[0][0];
        char operationSymbol = operationAndDestination[0][1];
        return new Operation(category, destination, valueComparison, operationSymbol);
    }
}

