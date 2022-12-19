using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3._2
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


            while(current < data.Length)
            {
                var id = data[current].all.Intersect(data[current + 1].all).Intersect(data[current + 2].all).Single();
                score += getValue(id);
                current += 3;
            }

            return score;
        }

        public static long getValue(char c) =>
            c >= 'a' && c <= 'z'
            ? c - 'a' + 1
            : c - 'A' + 27;
    }
}
