using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.days
{
    public class Day1
    {

        static public int findMostCalories()
        {
            //lets turn that data from .txt into a string array for each line!
            string[] linesArr = File.ReadLines("E:\\repos\\dotnet\\AdventOfCode2022\\data\\day1_data.txt").ToArray();
            //setup for loop
            int calories = 0;
            int mostCalories = 0;

            foreach (string line in linesArr)
            {
                //if there's an empty line, that's it for that one elf's inventory
                if (line == "")
                {
                    //if the elve's total calories are bigger than current mostCalories number, set mostCalories to the elve's total calories
                    if (mostCalories < calories) mostCalories = calories;
                    //lets reset calories since we're about to start a new inventory of an elf!
                    calories = 0;
                }
                else
                {
                    try
                    {
                        //can this line be parsed into an int? Lets try
                        calories += int.Parse(line);
                    }
                    catch (FormatException)
                    {
                        //uh oh, error handling since cannot parse
                        Console.WriteLine($"Unable to parse ' {line}'");
                    }
                }
            }

            //Console.WriteLine($"The most calories would be: {mostCalories}");
            return mostCalories;
        }
    }
}
