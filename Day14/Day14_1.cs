using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day14
{
    class Day14_1
    {
        public static void GetUnitsOfSand()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day14.txt").ToArray();
            const int MaxSize = 1000;
            var cave = new char[MaxSize, MaxSize];

            foreach (var line in input)
            {
                var parts = line.Split(" -> ");

                static Point ParsePoint(string pointString)
                {
                    var pointParts = pointString.Split(',');
                    return new Point(int.Parse(pointParts[0]), int.Parse(pointParts[1]));
                }

                Point previousPoint = ParsePoint(parts[0]);
                for (int i = 1; i < parts.Length; i++)
                {
                    var targetPoint = ParsePoint(parts[i]);
                    var direction = (targetPoint - previousPoint).Normalize();

                    cave[previousPoint.X, previousPoint.Y] = '#';
                    while (previousPoint != targetPoint)
                    {
                        previousPoint += direction;
                        cave[previousPoint.X, previousPoint.Y] = '#';
                    }
                }
            }

            var sandCount = 0;
            while (DropSand())
            {
                sandCount++;
            }

            OutputCave(490, 0, 504, 10);
            Console.Clear();

            Console.WriteLine(sandCount);

            bool DropSand()
            {
                var currentPosition = new Point(500, 0);
                while (true)
                {
                    if (currentPosition.Y == MaxSize - 1)
                    {
                        return false;
                    }

                    if (cave[currentPosition.X, currentPosition.Y + 1] == 0)
                    {
                        currentPosition = new Point(currentPosition.X, currentPosition.Y + 1);
                    }
                    else if (cave[currentPosition.X - 1, currentPosition.Y + 1] == 0)
                    {
                        currentPosition = new Point(currentPosition.X - 1, currentPosition.Y + 1);
                    }
                    else if (cave[currentPosition.X + 1, currentPosition.Y + 1] == 0)
                    {
                        currentPosition = new Point(currentPosition.X + 1, currentPosition.Y + 1);
                    }
                    else
                    {
                        // Rest
                        cave[currentPosition.X, currentPosition.Y] = 'o';
                        return true;
                    }
                }
            }

            void OutputCave(int fromX, int fromY, int toX, int toY)
            {
                for (int y = fromY; y < toY; y++)
                {
                    for (int x = fromX; x < toX; x++)
                    {
                        Console.Write(cave![x, y] != 0 ? cave[x, y] : '.');
                    }
                    Console.WriteLine();
                }
            }
        }
        public record struct Point(int X, int Y)
        {
            public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
            
            public static Point operator -(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y);

            public Point Normalize() => new Point(X != 0 ? X / Math.Abs(X) : 0, Y != 0 ? Y / Math.Abs(Y) : 0);

            public static implicit operator Point((int X, int Y) tuple) => new Point(tuple.X, tuple.Y);

            public int ManhattanDistance(Point b) => Math.Abs(X - b.X) + Math.Abs(Y - b.Y);
        }
    }
}
