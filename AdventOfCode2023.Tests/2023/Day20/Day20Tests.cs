using AdventOfCode._2023.Day20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests._2023.Day20
{
    internal class Day20Tests
    {
        [Test]
        public void PropagatePulse_should_return_one_low_pulse()
        {
            var modules = new Dictionary<string, Module>
            {
                { "broadcaster", new Module("broadcaster", new List<string>()) }
            };
            var pulsePro = new PulsePropagation();

            var pulseCount = pulsePro.PropagatePulse(modules);

            Assert.That(pulseCount[0], Is.EqualTo(1), "because there is only a broadcaster in the module, and broadcaster receive a low pulse to start");
        }

        [Test]
        public void PropagatePulse_should_return_8_low_pulse_and_4_high_pulse()
        {
            var modules = new Dictionary<string, Module>
            {
                { "broadcaster", new Module("broadcaster", new List<string> { "a","b","c" }) },
                { "a", new FlipFlopModule("a",new List<string>() { "b" }, false) },
                { "b", new FlipFlopModule("b",new List<string>() { "c" }, false) },
                { "c", new FlipFlopModule("c",new List<string>() { "inv" }, false) },
                { "inv", new ConjonctionModule("inv",new List<string>() { "a" }, new Dictionary<string, PulseType> { { "c", PulseType.LowPulse } }) }
            };
            var pulsePro = new PulsePropagation();

            var pulseCount = pulsePro.PropagatePulse(modules);

            Assert.That(pulseCount[0], Is.EqualTo(8), "because in this system, modules send 8 low pulses");
            Assert.That(pulseCount[1], Is.EqualTo(4), "because in this system, modules send 4 low pulses");
        }

        [Test]
        public void ParseModules_should_return_a_dictionary_containing_modules()
        {
            var pulsePro = new PulsePropagation();
            var input = File.ReadAllText("../../../2023/Day20/input.txt");

            var modules = pulsePro.ParseModules(input);

            Assert.That(modules.Count, Is.EqualTo(5));
            Assert.That(((ConjonctionModule)modules["inv"]).SubjectsPulseMemory.First().Key, Is.EqualTo("c"));
        }

        [Test]
        public void SolvePartOne_should_return_32000000()
        {
            var pulsePro = new PulsePropagation();
            var input = File.ReadAllText("../../../2023/Day20/input.txt");

            BigInteger pulses = (BigInteger)pulsePro.SolvePartOne(input);

            Assert.That(pulses, Is.EqualTo((BigInteger)32000000));
        }
    }
}
