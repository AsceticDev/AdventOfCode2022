using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day2.P2
{
    public class Day2_P2
    {
        public static string GetTotalScore()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day2.txt").ToArray();
            int totalScore = 0;
            foreach (string line in input)
            {
                var parts = line.Split(" ");
                var opponentShape = (Shape)(parts[0][0] - 'A');
                var outcome = (RoundOutcome)(parts[1][0] - 'X');
                totalScore += CalculateRoundScore(opponentShape, outcome);
            }
            return totalScore.ToString(); ;
        }


        static int CalculateRoundScore(Shape opponent, RoundOutcome outcome)
        {
            var roundScore = (int)outcome * 3;
            var shapeScore = 0;
            if (outcome == RoundOutcome.Draw)
            {
                shapeScore = GetShapeScore(opponent);
            }
            else if (outcome == RoundOutcome.Win)
            {
                shapeScore = GetShapeScore((Shape)(((int)opponent + 1) % 3));
            }
            else
            {
                shapeScore = GetShapeScore((Shape)(((int)opponent + 2) % 3));
            }
            return shapeScore + roundScore;
        }

        static int GetShapeScore(Shape shape) => (int)shape + 1;

        enum Shape
        {
            Rock,
            Paper,
            Scissors
        }

        enum RoundOutcome
        {
            Loss,
            Draw,
            Win
        }

        static public int GetTotalScoreSecondMethod()
        {

            string[] input = File.ReadLines(@"..\..\..\Day2\day2_data.txt").ToArray();

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

            int predScore = 0;

          
            foreach (string line in input)
            {

                string[] choices = line.Split(' ');

                if (choices.Length != 2) continue;

                if (choices[1] == "X")
                {
                    predScore += loss;

                    if (shapes[choices[0]] == rock)
                    {
                        predScore += scissors;
                    }
                    if (shapes[choices[0]] == paper)
                    {
                        predScore += rock;
                    }
                    if (shapes[choices[0]] == scissors)
                    {
                        predScore += paper;
                    }
                }

                if (choices[1] == "Y")
                {
                    predScore += draw;
                    predScore += shapes[choices[0]];
                }

                if (choices[1] == "Z")
                {
                    predScore += win;

                    if (shapes[choices[0]] == rock)
                    {
                        predScore += paper;
                    }
                    if (shapes[choices[0]] == paper)
                    {
                        predScore += scissors;
                    }
                    if (shapes[choices[0]] == scissors)
                    {
                        predScore += rock;
                    }
                }
            }

            return predScore;
        }
    }

}
