using System.Text.Json;
using System.Text.Json.Nodes;
using AdventOfCode.Kernel;

[Challenge("Distress Signal", "2022/Day13/input.txt")]
public class DistressSignal : IChallenge
{
    public object SolvePartOne(string input)
        => ParseInput(input)
        .Chunk(2)
        .Select((chunk,index) => Compare(chunk.First(),chunk.Last()) < 0 ? index + 1 : 0)
        .Sum();

    public object SolvePartTwo(string input)
    {
        var packets = ParseInput(input);
        var dividerPackets = ParseInput("[[2]]\n[[6]]");
        packets.AddRange(dividerPackets);
        packets.Sort(Compare);
        return (packets.IndexOf(dividerPackets[0]) + 1) * (packets.IndexOf(dividerPackets[1]) + 1);
    }

    public List<JsonNode> ParseInput(string input)
    {
        return (
            from line in input.Split('\n')
            where string.IsNullOrEmpty(line) == false
            // JsonNode helps parsing a json without creating a class, which is perfect is that simple case
            select JsonNode.Parse(line)
        ).ToList();
    }

    public int Compare(JsonNode nodeA, JsonNode nodeB)
    {
        if(nodeA is JsonValue && nodeB is JsonValue)
            return (int)nodeA - (int)nodeB;
        else
        {
            JsonArray arrayA = nodeA as JsonArray ?? new JsonArray((int)nodeA);
            JsonArray arrayB = nodeB as JsonArray ?? new JsonArray((int)nodeB);
            
            return
                arrayA.Zip(arrayB)
                .Select(
                    jsonValue => Compare(jsonValue.First!,jsonValue.Second!)
                )
                // comparison ends on first difference between A and B, if there is no difference, then return array length difference
                .FirstOrDefault(e => e != 0, arrayA.Count - arrayB.Count);
        }
    }
}