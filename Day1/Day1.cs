using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2022.Day1
{
    public class Day1
    {
        static public int FindMostCalories()
        {
            //lets turn that data from .txt into a string array for each line!
            string[] input = File.ReadLines(@"..\..\..\Data\day1.txt").ToArray();
            //setup for loop
            int calories = 0;
            int mostCalories = 0;

            foreach (string line in input)
            {
                //if there's an empty line, that's it for that one elf's inventory
                if (string.IsNullOrWhiteSpace(line))
                {
                    //if the elve's total calories are bigger than current mostCalories number, set mostCalories to the elve's total calories
                    //if (mostCalories < calories) mostCalories = calories;
                    mostCalories = Math.Max(mostCalories, calories);
                    //lets reset calories since we're about to start a new inventory of an elf!
                    calories = 0;
                }
                //if not, lets part that string into an int and add it to current calories
                else calories += int.Parse(line);
            }

            return mostCalories;
        }

    }

}
