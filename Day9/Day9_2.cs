using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day9
{
    class Day9_2
    {
        public static void GetPositionsAvailable()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day9.txt").ToArray();
            int xHead = 0;
            int yHead = 0;

            var xTails = new int[9];
            var yTails =  new int[9];

            var positions = new HashSet<string>();
            positions.Add(position(xHead,yHead));

            foreach (var line in input){
                var instruction = line.Split(" ");

                for (int i = Convert.ToInt32(instruction[1]); i > 0; i--){
                    int prevX = xHead;
                    int prevY = yHead;

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

                    for (int tail = 0; tail < 9; tail++){
                        int xTail = xTails[tail];
                        int yTail = yTails[tail];

                        int xCompare = tail != 0 ? xTails[tail-1] : xHead;
                        int yCompare = tail != 0 ? yTails[tail-1] : yHead;

                        if (xCompare == xTail && (yCompare == yTail || Math.Abs(yCompare - yTail) == 1) || yCompare == yTail && Math.Abs(xCompare - xTail) == 1) continue;
                        if (Math.Abs(yCompare - yTail) == 1 && Math.Abs(xCompare - xTail) == 1) continue;

                        if (xCompare == xTail){
                            yTails[tail] += yCompare > yTail ? 1 : -1;
                        }
                        else if (yCompare == yTail){
                            xTails[tail] += xCompare > xTail ? 1 : -1;
                        }                
                        else {
                            yTails[tail] += yCompare > yTail ? 1 : -1;
                            xTails[tail] += xCompare > xTail ? 1 : -1;
                        }
                        
                            
                        if (tail == 8){
                            positions.Add(position(xTails[tail],yTails[tail]));
                        }
                    }
                }        
            }

            Console.WriteLine(positions.Count);
        }
        static string position(int x, int y){
            return $"{x.ToString()},{y.ToString()}";
        }
    }
}
