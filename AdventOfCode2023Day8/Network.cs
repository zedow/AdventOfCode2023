using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Numerics;

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

        public int GetPathSteps(string fromNode)
        {
            var steps = 0;
            string[] nextDirections = nodes[fromNode];
            var inputDirectionsIndex = 0;
            var found = false;
            while(found == false)
            {
                var next = DIRECTIONS.IndexOf(inputDirectionsList[inputDirectionsIndex]);
                var nextNode = nodes.First(n => n.Key == nextDirections[next]);
                if (nextNode.Key.Last() == 'Z')
                    found = true;
                nextDirections = nextNode.Value;
                steps++;
                inputDirectionsIndex++;
                if(inputDirectionsIndex >= inputDirectionsList.Length)
                    inputDirectionsIndex= 0;
            }

            return steps;
        }

        public string[] GetAllANodes()
        {
            return nodes.Where(n => n.Key.IndexOf("A") != -1).Select(n => n.Key).ToArray();
        }

        public BigInteger GetPathStepsPart2()
        {
            List<int> stepsList = GetAllANodes().Select(GetPathSteps).OrderDescending().ToList();
            var myNumber = stepsList.First();
            BigInteger finalAnswer = myNumber;
            stepsList = stepsList.Skip(1).ToList();
            while (stepsList.Any(s => finalAnswer % s != 0))
            {
                finalAnswer += myNumber;
            }
            return finalAnswer;
        }
    }
}
