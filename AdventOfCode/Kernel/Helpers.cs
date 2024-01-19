using System.Numerics;

namespace AdventOfCode.Kernel;
public static class Helpers
{
    public static Dictionary<Complex,int> ParseIntegerMap(string input)
    {
        var lines = input.Split('\n');
        return (
            from irow in Enumerable.Range(0, lines.Length)
            from icol in Enumerable.Range(0, lines[irow].Length)
            let pos = new Complex(icol,irow)
            let val = int.Parse(lines[irow].Substring(icol, 1))
            select new KeyValuePair<Complex,int>(pos,val)
        ).ToDictionary(k => k.Key, v => v.Value);
    }
}