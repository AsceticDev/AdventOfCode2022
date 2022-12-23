using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day10
{
    class Day10_2
    {
        public static void GetSumOfSignals()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day10.txt").ToArray();
            long x = 1;

            StringBuilder outputBuilder = new();

            var tick = 0;
            foreach (var instruction in input)
            {
                ProcessCycle();
                    
                if (instruction != "noop")
                {
                    ProcessCycle();
                    var addSplit = instruction.Split(' ');
                    int value = int.Parse(addSplit[1]);
                    x += value;
                }
            }

            Console.WriteLine(outputBuilder.ToString());

            void ProcessCycle()
            {
                var spritePosition = x;
                if (spritePosition - 1 <= tick && tick <= spritePosition + 1)
                {
                    outputBuilder.Append("#");
                }
                else
                {
                    outputBuilder.Append(".");
                }

                tick++;
                if (tick % 40 == 0)
                {
                    outputBuilder.AppendLine();
                    tick = 0;
                }
            }
                    }
    }
}
