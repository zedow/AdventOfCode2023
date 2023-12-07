using Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day1
{
    public class Calibration
    {
        public int Calibrate(string input)
        {
            List<int> digits = MyFileReader.ParseIntegersFromStringInputUsingRegex(input);
            if(digits.Count > 1)
                return int.Parse(digits.First().ToString() + digits.Last().ToString());
            return int.Parse(digits.First().ToString() + digits.First().ToString());
        }
    }
}
