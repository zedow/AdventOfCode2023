using AdventOfCode.Kernel;
using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode._2023.Day20;

using Modules = Dictionary<string, Module>;
public record Module(string Name, List<string> Observers);
public record FlipFlopModule(string Name, List<string> Observers, bool State) : Module(Name,Observers);
public record ConjonctionModule(string Name, List<string> Observers, Dictionary<string,PulseType> SubjectsPulseMemory, Dictionary<string, PulseType> SubjectsPulseMemoryOriginal) 
    : Module(Name, Observers);
public record Pulse(PulseType PulseType, string Source,string Target);

[Challenge("Pulse Propagation", "2023/Day20/input.txt")]
public class PulsePropagation : IChallenge
{
    public object SolvePartOne(string input)
    {
        var counter = 1000;
        Modules modules = ParseModules(input);
        Modules originalState = ParseModules(input);
        List<Complex> pulses = new List<Complex>();
        while (counter > 0)
        {
            var currentRunPulses = PropagatePulse(modules);
            counter--;
            pulses.Add(new Complex(currentRunPulses[0], currentRunPulses[1]));
            if (AreModulesInTheirOriginalState(modules))
                break;
        }
        int ratio = (counter / pulses.Count()) + 1;
        int remainder = counter % pulses.Count();
        BigInteger total = (BigInteger)((pulses.Sum(p => p.Real) * ratio) * (pulses.Sum(p => p.Imaginary) * ratio));
        for(int i = 0; i < remainder; i++)
        {
            total += (BigInteger)(pulses.ElementAt(i).Real * pulses.ElementAt(i).Imaginary);
        }
        return total;
    }

    public object SolvePartTwo(string input)
    {
        throw new NotImplementedException();
    }

    public bool AreModulesInTheirOriginalState(Modules moduleA)
    {
        bool equal = true;
        if (moduleA.Where(m => m.Value is ConjonctionModule)
            .All(m => ((ConjonctionModule)m.Value).SubjectsPulseMemory.SequenceEqual(((ConjonctionModule)m.Value).SubjectsPulseMemory)) == false
        )
            return false;
        if (moduleA.Where(m => m.Value is FlipFlopModule).All(m => ((FlipFlopModule)m.Value).State == false) == false)
            return false;

        return equal;
    }

    public int[] PropagatePulse(Modules modules)
    {
        var pulseQueue = new Queue<Pulse>();
        pulseQueue.Enqueue(new Pulse(PulseType.LowPulse,"button","broadcaster"));
        var counter = new int[2] { 0, 0 };
        while(pulseQueue.Count() > 0) {
            var pulse = pulseQueue.Dequeue();
            counter[(int)pulse.PulseType] += 1;
            if (modules.ContainsKey(pulse.Target) == false)
                continue;

            Module module = modules[pulse.Target];
            if (module is FlipFlopModule)
            {
                if (pulse.PulseType == PulseType.HighPulse)
                    continue;

                if (((FlipFlopModule)module).State)
                    pulse = pulse with { PulseType = PulseType.LowPulse };
                else
                    pulse = pulse with { PulseType = PulseType.HighPulse };

                modules[pulse.Target] = ((FlipFlopModule)module) with { State = !((FlipFlopModule)module).State };
            }

            if (module is ConjonctionModule)
            {
                ConjonctionModule conjonctionModule = (ConjonctionModule)module;
                conjonctionModule.SubjectsPulseMemory[pulse.Source] = pulse.PulseType;
                if (conjonctionModule.SubjectsPulseMemory.All(s => s.Value == PulseType.HighPulse))
                    pulse = pulse with { PulseType = PulseType.LowPulse };
                else
                    pulse = pulse with { PulseType = PulseType.HighPulse };
            }

            foreach (var observer in module.Observers)
            {
                pulseQueue.Enqueue(new Pulse(pulse.PulseType, module.Name, observer));
            }
        }
        return counter;
    }

    public Modules ParseModules(string input)
    {
        var modules = new Modules();
        var rows = input.Split("\r\n");
        foreach(var row in rows)
        {
            char chr = row[0];
            var regexPattern = "([a-z]{1,50})";
            List<string> words = Regex.Matches(row, regexPattern).Select(match => match.Value).ToList();
            if (chr == '%')
                modules.Add(words[0], new FlipFlopModule(words[0], words.Skip(1).ToList(), false));
            else if(chr == '&')
                modules.Add(words[0], new ConjonctionModule(words[0], words.Skip(1).ToList(),new Dictionary<string, PulseType>(), new Dictionary<string, PulseType>()));
            else
                modules.Add(words[0], new Module(words[0], words.Skip(1).ToList()));
        }

        return SetupConjonctionModulesSubjects(modules);
    }

    public Modules SetupConjonctionModulesSubjects(Modules modules)
    {
        var conjonctionModules = modules.Where(m => m.Value is ConjonctionModule).ToList();
        foreach(var module in conjonctionModules)
        {
            var modulesSubject = modules.Values.Where(m => m.Observers.Contains(module.Key)).ToList();
            modulesSubject.ForEach(moduleSubject =>
            {
                ((ConjonctionModule)modules[module.Key]).SubjectsPulseMemory.Add(moduleSubject.Name,PulseType.LowPulse);
                ((ConjonctionModule)modules[module.Key]).SubjectsPulseMemoryOriginal.Add(moduleSubject.Name, PulseType.LowPulse);
            });
        }
        return modules;
    }
}

public enum PulseType
{
    LowPulse = 0,
    HighPulse = 1
}

