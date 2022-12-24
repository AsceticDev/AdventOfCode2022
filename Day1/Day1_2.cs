using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day1
{
    class Day1_2
    {
        static public void GetResult()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day1.txt").ToArray();
            List<long> elves = new();
            long current = 0;
            foreach (string line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elves.Add(current);
                    current = 0;
                }
                else
                {
                    var calories = long.Parse(line);
                    current += calories;
                }
            }
            elves.Add(current);

            var result = elves.OrderByDescending(i => i).Take(3).Sum();

            Console.WriteLine(result);
        }
    }
}
