using System.Collections.Generic;
using System.Drawing;

namespace LinqToAStar
{
    /// <summary>
    /// Defines a set of static methods for <see cref="Point"/> and <see cref="PointF"/> structures.
    /// </summary>
    public static class PointExtensions
    {
        /// <summary>
        /// Gets nearby four <see cref="Point"/> instances.
        /// </summary>
        /// <param name="a">Current instance.</param>
        /// <param name="unit">The distance between current and nearby instances.</param>
        /// <returns>A collection of <see cref="Point"/> instances in four direction respectively.</returns>
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

        /// <summary>
        /// Gets nearby eight <see cref="Point"/> instances.
        /// </summary>
        /// <param name="a">Current instance.</param>
        /// <param name="unit">The distance between current and nearby instances on x or y axis.</param>
        /// <returns>A collection of <see cref="Point"/> instances in eight direction respectively.</returns>
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

        /// <summary>
        /// Gets nearby four <see cref="PointF"/> instances.
        /// </summary>
        /// <param name="a">Current instance.</param>
        /// <param name="unit">The distance between current and nearby instances.</param>
        /// <returns>A collection of <see cref="PointF"/> instances in four direction respectively.</returns>
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

        /// <summary>
        /// Gets nearby eight <see cref="PointF"/> instances.
        /// </summary>
        /// <param name="a">Current instance.</param>
        /// <param name="unit">The distance between current and nearby instances on x or y axis.</param>
        /// <returns>A collection of <see cref="PointF"/> instances in eight direction respectively.</returns>
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

        /// <summary>
        /// Calculate the Manhattan distance between two <see cref="Point"/> instances. 
        /// </summary>
        /// <param name="a">The first instance.</param>
        /// <param name="b">The second instance.</param> 
        /// <returns>The Manhattan Distance between two instances.</returns>
        public static int GetManhattanDistance(this Point a, Point b)
        {
            return DistanceHelper.GetManhattanDistance(a.X, a.Y, b.X, b.Y);
        }

        /// <summary>
        /// Calculate the Chebyshev distance between two <see cref="Point"/> instances. 
        /// </summary>
        /// <param name="a">The first instance.</param>
        /// <param name="b">The second instance.</param> 
        /// <returns>The Manhattan Distance between two instances.</returns>
        public static int GetChebyshevDistance(this Point a, Point b)
        {
            return DistanceHelper.GetChebyshevDistance(a.X, a.Y, b.X, b.Y);
        }

        /// <summary>
        /// Calculate the Euclidean distance between two <see cref="Point"/> instances. 
        /// </summary>
        /// <param name="a">The first instance.</param>
        /// <param name="b">The second instance.</param> 
        /// <returns>The Manhattan Distance between two instances.</returns>
        public static double GetEuclideanDistance(this Point a, Point b)
        {
            return DistanceHelper.GetEuclideanDistance(a.X, a.Y, b.X, b.Y);
        }

        /// <summary>
        /// Calculate the Manhattan distance between two <see cref="PointF"/> instances. 
        /// </summary>
        /// <param name="a">The first instance.</param>
        /// <param name="b">The second instance.</param> 
        /// <returns>The Manhattan Distance between two instances.</returns>
        public static float GetManhattanDistance(this PointF a, PointF b)
        {
            return DistanceHelper.GetManhattanDistance(a.X, a.Y, b.X, b.Y);
        }

        /// <summary>
        /// Calculate the Chebyshev distance between two <see cref="PointF"/> instances. 
        /// </summary>
        /// <param name="a">The first instance.</param>
        /// <param name="b">The second instance.</param> 
        /// <returns>The Manhattan Distance between two instances.</returns>
        public static float GetChebyshevDistance(this PointF a, PointF b)
        {
            return DistanceHelper.GetChebyshevDistance(a.X, a.Y, b.X, b.Y);
        }

        /// <summary>
        /// Calculate the Euclidean distance between two <see cref="PointF"/> instances. 
        /// </summary>
        /// <param name="a">The first instance.</param>
        /// <param name="b">The second instance.</param> 
        /// <returns>The Manhattan Distance between two instances.</returns>
        public static double GetEuclideanDistance(this PointF a, PointF b)
        {
            return DistanceHelper.GetEuclideanDistance(a.X, a.Y, b.X, b.Y);
        }
    }
}