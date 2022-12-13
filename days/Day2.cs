using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.days
{
    public class Day2
    {
        static public string getTotalScore()
        {
            string[] linesArr = File.ReadLines("E:\\repos\\dotnet\\AdventOfCode2022\\data\\day1_data.txt").ToArray();
            Console.WriteLine($"linesArr len: {linesArr.Length}");
            return linesArr[1];
        }
    }
}
