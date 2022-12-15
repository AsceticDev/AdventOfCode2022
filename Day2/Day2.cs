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
        string[] input = File.ReadLines(@"..\..\..\Day2\day2_data.txt").ToArray();
        public string GetTotalScore()
        {
            long totalScore = 0;
            foreach(string line in input)
            {
                var parts = line.Split(" ");
                var opponentShape = (Shape)(parts[0][0] - 'A');
                var myShape = (Shape)(parts[1][0] - 'X');
                totalScore += CalculateRoundScore(opponentShape, myShape);
                //Console.WriteLine("score 1: " + totalScore);
            }
            return totalScore.ToString(); ;
        }


        long CalculateRoundScore(Shape opponent, Shape ours)
        {
            var shapeScore = GetShapeScore(ours);
            var roundScore = 3;
            if(opponent != ours)
            {
                int myShapeIndex = (int)ours;
                int opponentShapeIndex = (int)opponent;
                roundScore = myShapeIndex == (opponentShapeIndex + 1) % 3 ? 6 : 0;
            }
            return shapeScore + roundScore;
        }

        long GetShapeScore(Shape shape) => (int)shape + 1;

        enum Shape  
        {
            Rock,
            Paper,
            Scissors
        }


        static public long GetTotalScoreEz()
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
