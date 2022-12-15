﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day2
{
    public class Day2
    {
        public static string GetTotalScore()
        {
            string[] input = File.ReadLines(@"..\..\..\Day2\day2_data.txt").ToArray();
            long totalScore = 0;
            foreach(string line in input)
            {
                var parts = line.Split(" ");
                var opponentShape = (Shape)(parts[0][0] - 'A');
                var myShape = (Shape)(parts[1][0] - 'X');
                totalScore += CalculateRoundScore(opponentShape, myShape);
            }
            return totalScore.ToString(); ;
        }


        static long CalculateRoundScore(Shape opponent, Shape ours)
        {
            var shapeScore = GetShapeScore(ours);
            var roundScore = 3;
            if(opponent != ours)
            {
                int myShapeIndex = (int)ours;
                int opponentShapeIndex = (int)opponent;
                /*if (myShapeIndex == (opponentShapeIndex + 1) % 3)
                {
                    roundScore = 6;
                }
                else
                {
                    roundScore = 0;
                }*/
                roundScore = myShapeIndex == (opponentShapeIndex + 1) % 3 ? 6 : 0;
            }
            return shapeScore + roundScore;
        }

        static long GetShapeScore(Shape shape) => (int)shape + 1;

        enum Shape  
        {
            Rock,
            Paper,
            Scissors
        }


        static public long GetTotalScoreSecondMethod()
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

            int score = 0;
            int predScore = 0;

            Console.WriteLine($"KEY - VAL");
            foreach (KeyValuePair<string, int> pair in shapes)
            {
                Console.WriteLine($"\t{pair.Key} - {pair.Value}");
            }

            foreach (string line in input)
            {

                string[] choices = line.Split(' ');

                if (choices.Length != 2) continue;

                if (shapes[choices[0]] == shapes[choices[1]])
                {
                    score += draw;
                }
                else if (shapes[choices[0]] == rock && shapes[choices[1]] == paper)
                {
                    score += win;
                }
                else if (shapes[choices[0]] == paper && shapes[choices[1]] == scissors)
                {
                    score += win;
                }
                else if (shapes[choices[0]] == scissors && shapes[choices[1]] == rock)
                {
                    score += win;
                }
                else
                {
                    score += loss;
                } 

                score += shapes[choices[1]];


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

            //Console.WriteLine($"linesArr len: {linesArr.Length}");
            return score;
        }
    }
}
