using Kernel;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023Day5
{
    public class Map
    {
        public int From { get; private set; }
        public int To { get; private set; }
        public int Range { get; private set; }
        public string FromName { get; private set; }
        public string ToName { get; private set; }

        public Map(int from, int to, int range,string fromName, string toName)
        {
            From = from;
            To = to;
            Range = range;
            FromName = fromName;
            ToName = toName;
        }

        // Maps are always composed of three integers, TO, FROM, and RANGE
        private const int MAP_COMPOSITION = 3;

        public static List<Map> ParseMaps(string str)
        {
            List<int> integers = MyFileReader.ParseIntegersFromStringInputUsingRegex(str);
            string[] names = ParseMapNames(str);
            List<Map> maps = new List<Map>();
            foreach (var mapIntegers in integers.Chunk(MAP_COMPOSITION))
            {
                maps.Add(new Map(mapIntegers[1], mapIntegers[0], mapIntegers[2], names[0], names[1]));
            }

            return maps;
        }

        public static string[] ParseMapNames(string input)
        {
            string pattern = @"(\w*)-to-(\w*) map:";
            var matches = Regex.Matches(input, pattern);
            var array = new string[2];
            array[0] = matches[0].Groups[1].Value;
            array[1] = matches[0].Groups[2].Value;
            return array;
        }
    }
}