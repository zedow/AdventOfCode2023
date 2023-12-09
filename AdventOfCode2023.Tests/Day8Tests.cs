using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            var steps = network.GetPathSteps("AAA");

            Assert.That(steps, Is.EqualTo(6));
        }

        [Test]
        public void Network_should_returns_number_of_steps_required_for_all_nodes_A_to_reach_a_Z_node()
        {
            var input =
                @"LR

                11A = (11B, XXX)
                11B = (XXX, 11Z)
                11Z = (11B, XXX)
                22A = (22B, XXX)
                22B = (22C, 22C)
                22C = (22Z, 22Z)
                22Z = (22B, 22B)
                XXX = (XXX, XXX)";

            var network = new Network(input);
            var result = network.GetPathStepsPart2();

            Assert.That(result, Is.EqualTo((BigInteger)6));
        }
    }
}
