using System.Collections.Generic;
using System.Drawing;

namespace LinqToAStar
{
    /// <summary>
    /// Defines a set of static methods for <see cref="Point"/> and <see cref="PointF"/> structures.
    /// </summary>
    public static class PointExtensions
    {
        public static IEnumerable<Point> GetFourDirections(this Point a, int unit)
        {
            return new[]
            {
                new Point(a.X + unit, a.Y), // right 
                new Point(a.X - unit, a.Y), // left 
                new Point(a.X, a.Y - unit), // bottom 
                new Point(a.X, a.Y + unit), // top
            };
        }

        public static IEnumerable<Point> GetEightDirections(this Point a, int unit)
        {
            return new[]
            {
                new Point(a.X + unit, a.Y), // right 
                new Point(a.X + unit, a.Y + unit), // right - top 
                new Point(a.X + unit, a.Y - unit), // right - bottom 
                new Point(a.X - unit, a.Y), // left  
                new Point(a.X - unit, a.Y + unit), // left - top
                new Point(a.X - unit, a.Y - unit), // left - bottom
                new Point(a.X, a.Y - unit), // bottom 
                new Point(a.X, a.Y + unit), // top
            };
        }

        public static IEnumerable<PointF> GetFourDirections(this PointF a, float unit)
        {
            return new[]
            {
                new PointF(a.X + unit, a.Y), // right 
                new PointF(a.X - unit, a.Y), // left 
                new PointF(a.X, a.Y - unit), // bottom 
                new PointF(a.X, a.Y + unit), // top
            };
        }

        public static IEnumerable<PointF> GetEightDirections(this PointF a, float unit)
        {
            return new[]
            {
                new PointF(a.X + unit, a.Y), // right 
                new PointF(a.X + unit, a.Y + unit), // right - top 
                new PointF(a.X + unit, a.Y - unit), // right - bottom 
                new PointF(a.X - unit, a.Y), // left  
                new PointF(a.X - unit, a.Y + unit), // left - top
                new PointF(a.X - unit, a.Y - unit), // left - bottom
                new PointF(a.X, a.Y - unit), // bottom 
                new PointF(a.X, a.Y + unit), // top
            };
        }

        public static int GetManhattanDistance(this Point a, Point b)
        {
            return DistanceHelper.GetManhattanDistance(a.X, a.Y, b.X, b.Y);
        }

        public static int GetChebyshevDistance(this Point a, Point b)
        {
            return DistanceHelper.GetChebyshevDistance(a.X, a.Y, b.X, b.Y);
        }

        public static double GetEuclideanDistance(this Point a, Point b)
        {
            return DistanceHelper.GetEuclideanDistance(a.X, a.Y, b.X, b.Y);
        }

        public static float GetManhattanDistance(this PointF a, PointF b)
        {
            return DistanceHelper.GetManhattanDistance(a.X, a.Y, b.X, b.Y);
        }

        public static float GetChebyshevDistance(this PointF a, PointF b)
        {
            return DistanceHelper.GetChebyshevDistance(a.X, a.Y, b.X, b.Y);
        }

        public static double GetEuclideanDistance(this PointF a, PointF b)
        {
            return DistanceHelper.GetEuclideanDistance(a.X, a.Y, b.X, b.Y);
        }
    }
}