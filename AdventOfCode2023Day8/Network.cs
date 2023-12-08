using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode2023Day8
{
    public class Network
    {
        public Dictionary<string, string[]> nodes { get; private set; }
        public string inputDirectionsList;
        public const string DIRECTIONS = "LR";
        public Network(string input) 
        { 
            var lines = input.Split("\r\n");
            nodes = new Dictionary<string, string[]>();
            inputDirectionsList = lines[0];
            IEnumerable<string> nodesToParse = lines.Skip(2);
            Regex regexPattern = new Regex("[()\t\r]");
            foreach (string node in nodesToParse) {
                var nodeNameAndNodeDirections = node.Split("=").Select(str => regexPattern.Replace(str, "")).ToArray();
                string[] directions = nodeNameAndNodeDirections[1].Split(",");
                nodes.Add(nodeNameAndNodeDirections[0].Trim(), new string [2] { directions[0].Trim(), directions[1].Trim() });
            }
        }

        public int GetPathSteps(string fromNode, string toNode)
        {
            var steps = 0;
            string[] nextDirections = nodes[fromNode];
            var inputDirectionsIndex = 0;
            var found = false;
            while(found == false)
            {
                var next = DIRECTIONS.IndexOf(inputDirectionsList[inputDirectionsIndex]);
                var nextNode = nodes.First(n => n.Key == nextDirections[next]);
                if (nextNode.Key == toNode)
                    found = true;
                nextDirections = nextNode.Value;
                steps++;
                inputDirectionsIndex++;
                if(inputDirectionsIndex >= inputDirectionsList.Length)
                    inputDirectionsIndex= 0;
            }

            return steps;
        }
    }
}
