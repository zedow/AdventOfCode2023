using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day5
{
    public static class Mapper
    {
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
    }
}
