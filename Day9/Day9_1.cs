using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day9
{
    class Day9_1
    {
        public static void GetPositionsVisited()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day9.txt").ToArray();

            int xHead = 0;
            int yHead = 0;

            int xTail = 0;
            int yTail = 0;

            var positions = new HashSet<string>();
            positions.Add(position(xTail,yTail));

            foreach (var line in input){
                var instruction = line.Split(" ");

                for (int i = Convert.ToInt32(instruction[1]); i > 0; i--){
                    int prevXHead = xHead;
                    int prevYHead = yHead;

                    if (instruction[0] == "U"){
                        yHead++;
                    }
                    else if (instruction[0] == "D"){
                        yHead--;
                    }
                    else if (instruction[0] == "L"){
                        xHead--;
                    }
                    else if (instruction[0] == "R"){
                        xHead++;
                    }

                    if (xHead == xTail && (yHead == yTail || Math.Abs(yHead - yTail) == 1) || yHead == yTail && Math.Abs(xHead - xTail) == 1) continue;
                    if (Math.Abs(yHead - yTail) == 1 && Math.Abs(xHead - xTail) == 1) continue;

                    xTail = prevXHead;
                    yTail = prevYHead;
                    
                    positions.Add(position(xTail,yTail));
                }        
            }
            Console.WriteLine(positions.Count);
        }

        static string position(int x, int y){
            return $"{x.ToString()},{y.ToString()}";
        }
    }
}
