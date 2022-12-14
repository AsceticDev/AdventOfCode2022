using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    class Day7_1
    {
        public static void GetSum()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day7.txt").ToArray();

            var currentDirectory = new List<string>();

            string createCurrentDirectory()
            {
                string dir = string.Join("/",currentDirectory);
                dir = dir.Replace("//", "/");
                return dir;
            }

            var directorySize = new Dictionary<string,int>();

            foreach (var line in input)
            {
                if (line.Substring(0,1) == "$"){
                    var command = line.Split(" ");

                    if (command[1] == "cd"){
                        if (command[2] == "..")
                        {
                            currentDirectory.RemoveAt(currentDirectory.Count-1);
                        }
                        else {
                            currentDirectory.Add(command[2]);
                        }
                    }
                }
                else if (line.Substring(0,3) != "dir"){
                    var file = line.Split(" ");
                    if (!directorySize.ContainsKey(createCurrentDirectory()))
                    {
                        directorySize[createCurrentDirectory()] = 0;
                    }
                    string dir = createCurrentDirectory();
                    while (dir.Contains("/")){
                        if (!directorySize.ContainsKey(dir))
                        {
                            directorySize[dir] = 0;
                        }
                        directorySize[dir] += Convert.ToInt32(file[0]);

                        if (dir == "/") break;

                        var dirSplit = dir.Split("/").ToList();
                        dirSplit.RemoveAt(dirSplit.Count-1);
                        dir = string.Join("/",dirSplit);
                    }
                }
            }

            int output = 0;

            foreach(var item in directorySize)
            {
                if (item.Value <= 100000)
                {
                    output += item.Value;
                }
            }

            Console.WriteLine(output.ToString());
        }

    }
}
