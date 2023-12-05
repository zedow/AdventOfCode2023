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
        private List<long> _seeds;

        public Mapper()
        {
            _maps = new List<Map>();
            _seeds = new List<long>();
        }

        public List<Map> GetStoredMaps() => _maps;
        public List<long> GetSeeds() => _seeds;

        public static long MapFromMaps(long input, List<Map> maps)
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

        public long MapInput(long input, string source, string target)
        {
            var maps = _maps.Where(m => m.FromName == source && m.ToName == target).ToList();
            return MapFromMaps(input, maps);
        }

        public List<long> MapAlmanacSeedsToLocations()
        {
            List<long> locations = new List<long>(); 
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
            _seeds = MyFileReader.ParseLongsFromStringInputUsingRegex(seeds);
        }
    }
}
