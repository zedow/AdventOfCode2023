using AdventOfCode._2023.Day19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests._2023.Day19
{
    public class Day19Tests
    {
        [Test]
        public void BuildRule_should_return_Operation_when_a_string_is_provided()
        {
            var rule = "a<2006:qkq";

            var aplenty = new AplentyWorkflow();
            var operation = aplenty.BuildRule(rule);

            Assert.IsNotNull(operation);
            Assert.That(operation.Category,Is.EqualTo('a'));
            Assert.That(aplenty.Operate(operation,1), Is.EqualTo("qkq"), "because 1 < 2006");
        }

        [Test]
        public void ParseWorkFlows_should_return_all_workflows()
        {
            var stringWorkflows = "px{a<2006:qkq,m>2090:A,rfg}";

            var aplenty = new AplentyWorkflow();
            var workflows = aplenty.ParseWorkFlows(stringWorkflows);

            Assert.IsNotNull(workflows);
            Assert.That(workflows.First().Key, Is.EqualTo("px"));
            Assert.That(aplenty.Operate(workflows.First().Value.First(),1), Is.EqualTo("qkq"), "because 1 < 2006");
        }

        [Test]
        public void ParseParts_should_return_parts_from_string()
        {
            var stringParts = "{x=787,m=2655,a=1222,s=2876}\r\n{x=1679,m=44,a=2067,s=496}\r\n{x=2036,m=264,a=79,s=2244}\r\n{x=2461,m=1339,a=466,s=291}\r\n{x=2127,m=1623,a=2188,s=1013}";

            var aplenty = new AplentyWorkflow();
            var parts = aplenty.ParseParts(stringParts);

            Assert.That(parts.Count(), Is.EqualTo(5));
            Assert.That(parts.First()[3], Is.EqualTo(2876));
        }

        [Test]
        public void ProcessPartThroughWorkflow()
        {
            var stringWorkflows = "in{a<2006:qkq,m>2090:A,rfg}";
            var aplenty = new AplentyWorkflow();
            var workflow = aplenty.ParseWorkFlows(stringWorkflows);
            var part = new int[4] { 0, 2091, 2007, 0 };

            var result = aplenty.ProcessPartThroughWorkflow(part, workflow);

            Assert.That(result,Is.EqualTo(2091 + 2007));
        }
    }
}
