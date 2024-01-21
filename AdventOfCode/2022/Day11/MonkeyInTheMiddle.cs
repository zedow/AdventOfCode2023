using AdventOfCode.Kernel;

namespace AdventOfCode._2022.Day11;

[Challenge("Monkey In The Middle", "2022/Day11/input.txt")]
public class MonkeyInTheMiddle : IChallenge
{
    public object SolvePartOne(string input)
        => PlayRounds(20,input, (long worry) => worry / 3);

    public object SolvePartTwo(string input) {
        var monkeys = ParseInput(input);
        var mod = monkeys.Aggregate(1L,(acc,monkey) => acc * monkey.Mod);
        return PlayRounds(10_000, input, (long worry) => worry % mod);
    }
    
    public long PlayRounds(int numberOfRounds, string input, Func<long,long> worryOperation)
    {
        List<Monkey> monkeys = ParseInput(input);
        for(int i = 0; i < numberOfRounds; i++)
        {
            foreach(var monkey in monkeys)
            {
                while(monkey.Items.TryDequeue(out var item))
                {
                    monkey.ItemsInsepcted++;
                    item = monkey.Operation(item);
                    item = worryOperation(item);
                    monkeys.ElementAt((int)monkey.Test(item)).Items.Enqueue(item);
                }
            }
        }
        return monkeys.OrderByDescending(m => m.ItemsInsepcted).Take(2).Aggregate(1L, (accumulator, monkey) => accumulator * monkey.ItemsInsepcted);
    }

    public List<Monkey> ParseInput(string input)
    {
        var monkeysToParse = input.Split("\n\n",StringSplitOptions.RemoveEmptyEntries);
        var monkeys = new List<Monkey>(monkeysToParse.Length);
        foreach(var monkey in monkeysToParse)
        {
            var lines = monkey.Split('\n');
            var operationLine = lines[2].Split(' ').TakeLast(2).ToArray();
            monkeys.Add(new Monkey(
                new Queue<long>(MyFileReader.ParseLongsFromStringInputUsingRegex(lines[1])),
                (long old) => operationLine.First() == "*" ? 
                    old * (operationLine.Last() == "old" ? old : int.Parse(operationLine.Last())): 
                    old + (operationLine.Last() == "old" ? old : int.Parse(operationLine.Last())),
                long.Parse(lines[3].Split(' ').Last()),
                (long worry) => worry % int.Parse(lines[3].Split(' ').Last()) == 0 ? int.Parse(lines[4].Split(' ').Last()) : int.Parse(lines[5].Split(' ').Last())
            ));
        }
        return monkeys;
    }

    public class Monkey(Queue<long> items, Func<long,long> operation,long mod,Func<long,long> test)
    {
        public Queue<long> Items = items;
        public Func<long,long> Operation = operation;
        public long Mod = mod;
        public Func<long,long> Test = test;
        public long ItemsInsepcted = 0L;
    }
}

