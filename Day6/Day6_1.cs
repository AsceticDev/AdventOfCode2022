using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day6
{
    class Day6_1
    {

        public static void GetNumberOfCharacters()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day6.txt").ToArray();
            char[] line = input[0].ToCharArray();
            var window = new HashSet<char>();


            for(int i = 3; i < line.Length; i++)
            {
                window.Clear();
                bool isValid = true;
                for(int previousChar = 0; previousChar < 4; previousChar++)
                {
                    var character = line[i - previousChar];
                    if (window.Contains(character))
                    {
                        isValid = false;
                        break;
                    }
                    else
                    {
                        window.Add(character);
                    }
                }
                if(isValid)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
 
        }
    }
}
