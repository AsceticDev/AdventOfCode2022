using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day5
{
    class Day5_1
    {
        public static void GetCrate()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day5.txt").ToArray();
            var dividerLineIndex = Array.IndexOf(input, string.Empty);

            var numberOfStacks = int.Parse(input[dividerLineIndex - 1]
                .Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Last());

            var stacks = new Stack<char>[numberOfStacks];

            for (int lineIndex = dividerLineIndex - 1; lineIndex >= 0; lineIndex--)
            {
                var line = input[lineIndex];
                for (int stackId = 0; stackId < numberOfStacks; stackId++)
                {
                    var crate = line[stackId * 4 + 1];
                    if (char.IsLetter(crate))
                    {
                        stacks[stackId] ??= new Stack<char>();
                        stacks[stackId].Push(crate);
                    }
                }
            }


            for (int instructionId = dividerLineIndex + 1; instructionId < input.Length; instructionId++)
            {
                var instruction = input[instructionId];
                var parts = instruction.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var numberOfCrates = int.Parse(parts[1]);
                var sourceStackId = int.Parse(parts[3]) - 1;
                var targetStackId = int.Parse(parts[5]) - 1;

                for (int i = 0; i < numberOfCrates; i++)
                {
                    var crate = stacks[sourceStackId].Pop();
                    stacks[targetStackId].Push(crate);
                }
            }

            Console.WriteLine(string.Join("", stacks.Select(s => s.Peek())));

        }
    }
}

