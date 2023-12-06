using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023Day5
{
    public record Range 
    {
        public long Start; public long End;
        public Range(long start, long end)
        {
            this.Start = start;
            this.End = end;
        }
    }
    public record MapEntry 
    { 
        public Range Source; public Range Destination; 
        public MapEntry(Range source, Range destination)
        {
            this.Source = source;
            this.Destination = destination;
        }
    }
    public record MapV2 { 
        public MapEntry[] Entries; 
        public MapV2(MapEntry[] entries) 
        {
            Entries = entries;
        }
    }
    public class MapperV2
    {
        public List<MapV2> Maps { get; set; }
        public List<long> Seeds { get; set; }

        public MapperV2()
        {
            Maps = new List<MapV2>();
            Seeds = new List<long>();
        }

        public void ParseMaps(string input)
        {
            var splitInput = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string seeds = splitInput[0];
            Seeds = MyFileReader.ParseLongsFromStringInputUsingRegex(seeds);
            for (int i = 1; i < splitInput.Length; i++)
            {
                List<long> integers = MyFileReader.ParseLongsFromStringInputUsingRegex(splitInput[i]);
                var mapIntegersChunk = integers.Chunk(3);
                var mapV2 = new MapV2(mapIntegersChunk.Select(chunk => new MapEntry(
                            new Range(chunk[1], chunk[1] + chunk[2]),
                            new Range(chunk[0], chunk[0] + chunk[2])
               )).ToArray());
               Maps.Add(mapV2);  
            }
        }

        public IEnumerable<Range> Explore(Range seedToExplore, MapV2 currentMap)
        {
            Queue<Range> queue = new Queue<Range>();
            queue.Enqueue(seedToExplore);
            while(queue.Any())
            {
                var range = queue.Dequeue();
                var found = false;
                foreach(var entry in currentMap.Entries)
                {
                    // case when range is inside boudaries
                    if(range.Start >= entry.Source.Start && range.End <= entry.Source.End)
                    {
                        // no need to explore anymore, add it to the finals ranges list
                        var shift = entry.Destination.Start - entry.Source.Start;
                        yield return new Range(range.Start + shift, range.End + shift);
                        found = true;
                    }
                    // case when range is on start boundary
                    if(range.Start < entry.Source.Start && range.End <= entry.Source.End && range.End > entry.Source.Start)
                    {
                        // Add to exploration the part of the range that is ouside the boundaries
                        queue.Enqueue(new Range(range.Start, entry.Source.Start - 1));
                        // Add to exploration the part of the range that is inside the boudaries
                        queue.Enqueue(new Range(entry.Source.Start, range.End));
                        found = true;
                    }
                    // case when range is on end boundary
                    if(range.Start >= entry.Source.Start && range.Start < entry.Source.End && range.End > entry.Source.End)
                    {
                        // Add to exploration the part of the range that is inside the boundaries
                        queue.Enqueue(new Range(range.Start, entry.Source.End));
                        // Add to exploration the part of the range that ouside the boundaries
                        queue.Enqueue(new Range(entry.Source.End +1, range.End));
                        found = true;
                    }
                }

                // no need to explore anymore, add it to the finals ranges list because the range is ouside every map entries
                if (found == false)
                {
                    yield return new Range(range.Start, range.End);
                }
            }
        }
    }
}
