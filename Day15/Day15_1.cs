using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day15
{
    class Day15_1
    {
        public static void GetIntervals()
        {
            string[] input = File.ReadLines(@"..\..\..\Data\day15.txt").ToArray();
            const int TargetY = 2000000;

            var readings = new List<BeaconReading>();

            var regex = new Regex("=([-0-9]*)[,:]?");
            foreach (var line in input)
            {
                var values = regex.Matches(line).Select(m => int.Parse(m.Groups[1].Value)).ToArray();
                var sensor = new Point(values[0], values[1]);
                var beacon = new Point(values[2], values[3]);
                readings.Add(new(sensor, beacon));
            }

            var intervals = new List<(int MinX, int MaxX)>();
            var uniqueKnownBeacons = new HashSet<Point>();
            foreach (var reading in readings)
            {
                var beaconDistance = reading.Sensor.ManhattanDistance(reading.Beacon);
                var targetLineYDiff = Math.Abs(reading.Sensor.Y - TargetY);
                var xDiffLimit = beaconDistance - targetLineYDiff;
                if (xDiffLimit >= 0)
                {
                    var firstX = reading.Sensor.X - xDiffLimit;
                    var secondX = reading.Sensor.X + xDiffLimit;
                    var minX = Math.Min(firstX, secondX);
                    var maxX = Math.Max(firstX, secondX);
                    intervals.Add((minX, maxX));
                }
                uniqueKnownBeacons.Add(reading.Beacon);
            }

            intervals.Sort((i1, i2) => i1.MinX - i2.MinX);

            var totalExclusion = 0;

            var modifiedIntervals = new List<(int minX, int maxX)>();
            while (intervals.Count > 0)
            {
                var firstInterval = intervals[0];
                totalExclusion += firstInterval.MaxX - firstInterval.MinX + 1;

                for (int i = 1; i < intervals.Count; i++)
                {
                    var secondInterval = intervals[i];
                    if (secondInterval.MinX <= firstInterval.MaxX)
                    {
                        if (firstInterval.MaxX < secondInterval.MaxX)
                        {
                            modifiedIntervals.Add(new(firstInterval.MaxX + 1, secondInterval.MaxX));
                        }
                    }
                    else
                    {
                        modifiedIntervals.Add(secondInterval);
                    }
                }

                intervals = modifiedIntervals;
                modifiedIntervals = new List<(int minX, int maxX)>();
            }

            foreach (var beacon in uniqueKnownBeacons)
            {
                if (beacon.Y == TargetY)
                {
                    totalExclusion--;
                }
            }

            Console.WriteLine(totalExclusion);

        }
        record BeaconReading(Point Sensor, Point Beacon);

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
