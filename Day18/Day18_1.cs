using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day18
{
    class Day18_1
    {
        static public void GetSurfaceArea()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day18.txt").ToArray();
            var cubes = new List<Point3d>();
            foreach(var line in input)
            {
                var pointCoordinates = line.Split(',');
                cubes.Add(
                    new(
                        int.Parse(pointCoordinates[0]),
                        int.Parse(pointCoordinates[1]),
                        int.Parse(pointCoordinates[2])
                    ));
            }

            var surfaceArea = 0;

            foreach(var cube in cubes)
            {
                var openSides = 6;
                foreach (var otherCube in cubes)
                {
                    if (otherCube == cube)
                    {
                        continue;
                    }

                    if (AreAdjacent(cube, otherCube))
                    {
                        openSides--;
                        if (openSides == 0)
                        {
                            break;
                        }
                    }
                }

                surfaceArea += openSides;
            }

            Console.WriteLine(surfaceArea);
            
        }
        static bool AreAdjacent(Point3d a, Point3d b) =>
            (a.X == b.X && a.Y == b.Y && Math.Abs(a.Z - b.Z) == 1) ||
            (a.X == b.X && a.Z == b.Z && Math.Abs(a.Y - b.Y) == 1) ||
            (a.Y == b.Y && a.Z == b.Z && Math.Abs(a.X - b.X) == 1);
        }
        public record struct Point3d(int X, int Y, int Z)
        {
            public static Point3d operator +(Point3d a, Point3d b) => new Point3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
            
            public static Point3d operator -(Point3d a, Point3d b) => new Point3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

            public Point3d Normalize() => new Point3d(X != 0 ? X / Math.Abs(X) : 0, Y != 0 ? Y / Math.Abs(Y) : 0, Z != 0 ? Z / Math.Abs(Z) : 0);

            public static implicit operator Point3d((int X, int Y, int Z) tuple) => new Point3d(tuple.X, tuple.Y, tuple.Z);

            public int ManhattanDistance(Point3d b) => Math.Abs(X - b.X) + Math.Abs(Y - b.Y) + Math.Abs(Z - b.Z);
        } 
}
