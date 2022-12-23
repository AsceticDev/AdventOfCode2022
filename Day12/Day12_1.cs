using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day12
{
    class Day12_1
    {
        public static void GetFewestSteps()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day12.txt").ToArray();
            var start = (x: -1, y: -1);
            var end = (x: -1, y: -1);

            var map = new List<List<char>>();

            var distanceCosts = new Dictionary<(int, int), int>();

            void explorePaths(int x, int y){
                int currentCost = distanceCosts[(x,y)];

                void neighbourCost(int newX, int newY)
                {
                    if (newX < 0 || newX >= map[0].Count) return;
                    if (newY < 0 || newY >= map.Count) return;


                    if (map[newY][newX] + 1 >= map[y][x])
                    {
                        if (!distanceCosts.ContainsKey((newX, newY)) || distanceCosts[(newX, newY)] > currentCost + 1)
                        {
                            distanceCosts[(newX, newY)] = currentCost + 1;
                            explorePaths(newX, newY);
                        }
                    }
                }

                neighbourCost(x+1,y);
                neighbourCost(x-1,y);
                neighbourCost(x,y+1);
                neighbourCost(x,y-1);
            }

            foreach (var line in input){
                var charList = new List<char>();
                foreach (char c in line){
                    if (c == 'S'){
                        start = (charList.Count, map.Count);
                        charList.Add('a');
                    }
                    else if (c == 'E'){
                        end = (charList.Count, map.Count);
                        distanceCosts[end] = 0;
                        charList.Add('z');
                    }
                    else charList.Add(c);
                    
                }
                map.Add(charList);
            }
             
            explorePaths(end.x, end.y);

            Console.WriteLine(distanceCosts[(start.x, start.y)]);
        }
    }
}
