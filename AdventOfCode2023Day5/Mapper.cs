using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day5
{
    public class Mapper
    {
        private List<Map> _maps;
        private List<int> _seeds;

        public Mapper()
        {
            _maps = new List<Map>();
            _seeds = new List<int>();
        }

        public List<Map> GetStoredMaps() => _maps;
        public List<int> GetSeeds() => _seeds;

        public static int MapFromMaps(int input, List<Map> maps)
        {
            foreach(var map in maps)
            {
                if(map.From <= input && (map.From + map.Range) >= input)
                {
                    return map.To + (input - map.From);
                }
            }
            return input;
        }

        public int MapInput(int input, string source, string target)
        {
            var maps = _maps.Where(m => m.FromName == source && m.ToName == target).ToList();
            return MapFromMaps(input, maps);
        }

        public List<int> MapAlmanacSeedsToLocations()
        {
            List<int> locations = new List<int>(); 
            foreach(var seed in _seeds)
            {
                var location = seed;
                location = MapInput(location, "seed", "soil");
                location = MapInput(location, "soil", "fertilizer");
                location = MapInput(location, "fertilizer", "water");
                location = MapInput(location, "water", "light");
                location = MapInput(location, "light", "temperature");
                location = MapInput(location, "temperature", "humidity");
                location = MapInput(location, "humidity", "location");
                locations.Add(location);
            }
            return locations;
        }

        public void ParseAlmanac(string input)
        {
            var splitInput = input.Split(new string[] { "\r\n\r\n" },StringSplitOptions.RemoveEmptyEntries);
            string seeds = splitInput[0];
            for(int i = 1; i < splitInput.Length; i++)
            {
                _maps.AddRange(Map.ParseMaps(splitInput[i]));
            }
            _seeds = MyFileReader.ParseIntegersFromStringInputUsingRegex(seeds);
        }
    }
}
