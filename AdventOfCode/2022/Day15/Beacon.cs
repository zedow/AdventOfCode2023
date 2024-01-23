using AdventOfCode.Kernel;

namespace AdventOfCode._2022.Day15;

using Map = Dictionary<MyVector,MyVector>;

public record Sensor(MyVector SensorPosition, MyVector SensorRange);

[Challenge("Beacon Exclusion Zone", "2022/Day15/input.txt")]
public class Beacon : IChallenge
{
    public object SolvePartOne(string input)
    {
        var sensors = ParseInput(input);
        var targetRow = 2000000;
        return GetSensorsCoveragePositions(targetRow,sensors).Distinct().Count();
    }

    public object SolvePartTwo(string input)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<MyVector> GetSensorsCoveragePositions(int targetRow, HashSet<Sensor> sensors)
    {
        foreach(var sensor in sensors)
        {
            var distanceFromTargetRow = Math.Abs(sensor.SensorPosition.Y - targetRow);
            var sensorRange = sensor.SensorRange.X + sensor.SensorRange.Y;
            if(distanceFromTargetRow > sensorRange)
                continue;
            
            var remainingDistance = (sensorRange - distanceFromTargetRow) * 2;
            for(int x = sensor.SensorPosition.X - (remainingDistance / 2); x < sensor.SensorPosition.X + (remainingDistance / 2); x++)
            {
                yield return new MyVector(x,targetRow);
            }
        }
    }

    public HashSet<Sensor> ParseInput(string input)
    {
        var lines = input.Split('\n');
        return (
            from irow in Enumerable.Range(0,lines.Length)
            let integers = MyFileReader.ParseIntegers(lines[irow])
            let sensorPosition = new MyVector(integers[0],integers[1])
            select new Sensor(
                sensorPosition,
                new(Math.Abs(sensorPosition.X - integers[2]),Math.Abs(sensorPosition.Y - integers[3]))
            )
        ).ToHashSet();
    }
}