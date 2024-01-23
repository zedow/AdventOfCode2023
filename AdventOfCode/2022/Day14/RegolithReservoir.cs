using AdventOfCode.Kernel;

namespace AdventOfCode._2022.Day14;

using Map = Dictionary<MyVector,char>;

[Challenge("Regolith Reservoir", "2022/Day14/input.txt")]
public class RegolithReservoir : IChallenge
{
    public object SolvePartOne(string input)
    {
        var map = ParseInput(input);
        FillWithSand(map);
        return map.Count(m => m.Value == '°');
    }

    public object SolvePartTwo(string input)
    {
        var map = ParseInput(input);
        FillWithSand(map, true);
        return map.Count(m => m.Value == '°');
    }

    public void FillWithSand(Map map, bool setFloor = false)
    {
        var gate = new MyVector(500,0);
        var direction = MyVector.Down;
        MyVector position = gate;
        var lowestPoint = map.MaxBy(m => m.Key.Y).Key.Y;
        // break when sand start falling into the endless void
        while(setFloor || position.Y <= lowestPoint)
        {
            bool checkDirection(MyVector direction)
            {
                if((position + direction).Y == (lowestPoint + 2) == false && map.ContainsKey(position + direction) == false)
                {
                    position += direction;
                    return true;
                }
                return false;
            }
            
            if(checkDirection(direction))
                continue;
            if(checkDirection(direction + MyVector.Left))
                continue;
            if(checkDirection(direction + MyVector.Right))
                continue;
            
            map[position] = '°';
            if(position == gate)
                break;

            position = gate;
        }
    }

    public Map ParseInput(string input)
    {
        var lines = input.Split('\n');
        var map = new Map();
        foreach(var line in lines)
        {
            var steps = (
                from step in line.Split(" -> ")
                let stepVector = step.Split(',')
                select new MyVector(int.Parse(stepVector[0]),int.Parse(stepVector[1]))
            ).ToArray();

            for(int i = 1; i < steps.Length; i++)
            {
                var direction = new MyVector(
                    Math.Sign(steps[i - 1].X - steps[i].X),
                    Math.Sign(steps[i - 1].Y - steps[i].Y)
                );

                for(MyVector start = steps[i]; start != (steps[i - 1] + direction); start += direction)
                {
                    map[start] = '#';
                }
            }
        }

        return map;
    }
}