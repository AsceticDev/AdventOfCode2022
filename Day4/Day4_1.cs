using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day4
{
    class Day4_1
    {

        public static int GetPairs()
        {
            int result = 0;
            string[] input = File.ReadLines(@"..\..\..\Data\day4.txt").ToArray();

            foreach(string line in input)
            {
                var assignments = line.Split(',');
                var interval1 = ReadInterval(assignments[0]);
                var interval2 = ReadInterval(assignments[1]);
                if((interval1.start <= interval2.start && interval2.end <= interval1.end) ||
                    (interval2.start <= interval1.start && interval1.end <= interval2.end))
                {
                    result++;
                }
            }
            return result;
        }

        static (int start, int end) ReadInterval(string assignment)
        {
            var intervalParts = assignment.Split('-');
            return (int.Parse(intervalParts[0]), int.Parse(intervalParts[1]));
        }
    }
}
