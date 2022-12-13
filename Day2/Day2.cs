using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day2
{
    public class Day2
    {
        enum Shape  
        {
            Rock,
            Paper,
            Scissors
        }

        long CalculateRoundScore(Shape opponent, Shape player)
        {
            var shapeScore = GetShapeScore(player);
            var roundScore = 3;

            if(opponent != player)
            {
                int ourShapeIndex = (int)player;
                int opponentShapeIndex = (int)opponent;
                roundScore = ourShapeIndex == (opponentShapeIndex + 1) % 3 ? 6 : 0;
            }

            return shapeScore + roundScore;
        }

        long GetShapeScore(Shape shape) => (int)shape + 1;

        async public void GetTotalScore()
        {
            long totalScore = 0;
            while (await Console.In.ReadLineAsync() is string line)
            {
                Console.WriteLine("lol");
                var parts = line.Split(" ");
                foreach(string part in parts) Console.WriteLine(part);
                var opponentShape = (Shape)(parts[0][0] - 'A');
                var ourShape = (Shape)(parts[1][0] - 'X');
                totalScore += CalculateRoundScore(opponentShape, ourShape);
            }

            await Console.Out.WriteLineAsync(totalScore.ToString());
        }

        static public long getTotalScore()
        {

            string[] linesArr = File.ReadLines("E:\\repos\\dotnet\\AdventOfCode2022\\data\\day2_data.txt").ToArray();

            int rock = 1;
            int paper = 2;
            int scissors = 3;

            int loss = 0;
            int draw = 3;
            int win = 6;

            //  a/x=rock , b/y=paper, c/z=scissors

            Dictionary<string, int> shapes = new Dictionary<string, int>();
            shapes.Add("A", rock);
            shapes.Add("B", paper);
            shapes.Add("C", scissors);
            shapes.Add("X", rock);
            shapes.Add("Y", paper);
            shapes.Add("Z", scissors);

            int score = 0;

            foreach (KeyValuePair<string, int> pair in shapes)
            {
                Console.WriteLine("KEY: " + pair.Key);
                Console.WriteLine("VALUE: " + pair.Value);
            }


            foreach (string line in linesArr)
            {
                Console.WriteLine($"line here: {line}");

                string[] choices = line.Split(' ');

                if (choices.Length != 2) continue;

                if (shapes.GetValueOrDefault(choices[0]) == shapes.GetValueOrDefault(choices[1]))
                {

                }
                else if (false)
                {

                }
            }

            //Console.WriteLine($"linesArr len: {linesArr.Length}");
            return 1;
        }
    }
}
