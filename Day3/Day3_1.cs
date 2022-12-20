using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    public class Day3_1
    {

        /*
        vJrwpWtwJgWrhcsFMMfFFhFp
        jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
        PmmdzqPrVvPwwTWBwg
        wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
        ttgJtRGJQctTZtZT
        CrZsJsPPZsGzwwsLwLmpwMDw
        */

        //Lowercase item types a through z have priorities 1 through 26.
        //Uppercase item types A through Z have priorities 27 through 52.

        public static int GetSum()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day3.txt").ToArray();
            int prioritySum = 0;
            foreach (string line in input)
            {
                Console.WriteLine(line);
                prioritySum += line
                    .Take(line.Length / 2)
                    .Intersect(line.TakeLast(line.Length / 2))
                    .Sum(c => c <= 'Z' ? c - 'A' + 27 : c - 'a' + 1);
                //'A' = 65; Z' = 90; 'a' = 97; 'z' = 122
                //a through z have priorities 1 through 26. 
                //A through Z have priorities 27 through 52.
            }

            return prioritySum;
        }

        public static int GetSumMethod2()
        {
            return 2;
        }
    }
}
