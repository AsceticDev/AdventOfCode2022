using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    class Day3_2
    {
        public static long GetSum()
        {
            var score = 0L;
            int current = 0;


            var data =
                (from line in File.ReadAllLines(@"..\..\..\Data\day3.txt")
                 where !string.IsNullOrWhiteSpace(line)
                 select (
                    all: line.ToCharArray(),
                    firstHalf: line.Substring(0, line.Length / 2).ToCharArray(),
                    secondHalf: line.Substring(line.Length / 2).ToCharArray()
                 )
             ).ToArray();


            //Console.WriteLine($"how big is data?: [{data.Length}]");
            while (current < data.Length)
            {
                var id = data[current].all.Intersect(data[current + 1].all).Intersect(data[current + 2].all).Single();
                //Console.WriteLine($"current: [{current}] common elements from all 3 lines: [{id}]");
                score += getValue(id);
                current += 3;
            }
            Console.WriteLine($" a + 0 = [{'a' + 0}]");
            Console.WriteLine($" r + 0 = [{'r' + 0}]");
            Console.WriteLine($" r - a = [{'r' - 'a'}]");
            Console.WriteLine($" r - ('a' + 1) = [{'r' - ('a' + 1)}]");


            Console.WriteLine($" A + 0 = [{'A' + 0}]");
            Console.WriteLine($" C + 0 = [{'C' + 0}]");
            Console.WriteLine($" C - A = [{'C' - 'A'}]");
            Console.WriteLine($" C - (A+26) = [{'C' - ('A' + 26)}]");

            return score;
        }

        public static long getValue(char c) =>
            c >= 'a' && c <= 'z'
            ? c - 'a' + 1
            : c - 'A' + 27;
    }
}
