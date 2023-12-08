using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023Day8;

namespace AdventOfCode2023.Tests
{
    public class Day8Tests
    {
        [Test]
        public void Network_should_parse_every_input_nodes()
        {
            var input = @"LLR

                AAA = (BBB, BBB)
                BBB = (AAA, ZZZ)
                ZZZ = (ZZZ, ZZZ)";

            var network = new Network(input);

            Assert.That(network.inputDirectionsList.Count(), Is.EqualTo(3));
            Assert.That(network.inputDirectionsList, Is.EqualTo("LLR"));
        }

        [Test]
        public void Network_shoud_returns_number_of_steps_from_node_A_to_node_B()
        {
            var input = @"LLR

                AAA = (BBB, BBB)
                BBB = (AAA, ZZZ)
                ZZZ = (ZZZ, ZZZ)";

            var network = new Network(input);
            var steps = network.GetPathSteps("AAA","ZZZ");

            Assert.That(steps, Is.EqualTo(6));
        }

        
    }
}
