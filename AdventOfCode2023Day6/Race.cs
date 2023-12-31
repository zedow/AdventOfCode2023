﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Day6
{
    public class Race
    {
        public long Time { get; set; }
        public Race(long time) 
        {
            Time = time;
        }

        public (double, double) FindIntervalsOfPossibleValuesToBeatGivenDistance(long traveledDistance)
        {
            // it's a standard quadratic equation a²+bx+c=0
            // we have to calculate discriminant represented by formula Δ = b2 - 4ac where b = Race time and c = distance traveled
            double discriminant = Time * Time - 4 * 1 * traveledDistance;
            // this is the two solutions given by Quadratic Equation
            double firstBoundary = Math.Ceiling(Time - Math.Sqrt(discriminant)) / 2;
            double secondBoundary = Math.Floor(Time + Math.Sqrt(discriminant)) / 2;

            // Any value >= firstBoundary and any value <= secondBoundary will give a better traveledDistance for the race time
            // Do ceiling and floor again to have integers values
            return (Math.Ceiling(firstBoundary), Math.Floor(secondBoundary));
        }
    }
}
