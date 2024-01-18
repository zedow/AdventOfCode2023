using AdventOfCode.Kernel;
using Kernel;

namespace AdventOfCode._2022.Day06;

[Challenge("Tuning Trouble", "2022/Day06/input.txt")]
public class TuningTrouble : IChallenge
{
    public object SolvePartOne(string input) => FindMarkerIndex(input, 4);
    public object SolvePartTwo(string input) => FindMarkerIndex(input, 14);

    public int FindMarkerIndex(string input, int markerLength)
    {
        var currentIndex = 0;
        while (input.Substring(currentIndex, markerLength).GroupBy(k => k).Count() != markerLength)
        {
            currentIndex++;
        }
        return currentIndex + markerLength;
    }
}