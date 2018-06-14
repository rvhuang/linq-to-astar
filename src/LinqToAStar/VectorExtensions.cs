using System.Collections.Generic;
using System.Numerics;

namespace LinqToAStar
{
    /// <summary>
    /// Defines a set of static methods for <see cref="Vector2"/> structure.
    /// </summary>
    public static class VectorExtensions
    {
        /// <summary>
        /// Gets nearby four <see cref="Vector2"/> instances.
        /// </summary>
        /// <param name="a">Current instance.</param>
        /// <param name="unit">The distance between current and nearby instances.</param>
        /// <returns>A collection of <see cref="Vector2"/> instances in four direction respectively.</returns>
        public static IEnumerable<Vector2> GetFourDirections(this Vector2 a, float unit)
        {
            return new[]
            {
                new Vector2(a.X + unit, a.Y), // right 
                new Vector2(a.X - unit, a.Y), // left 
                new Vector2(a.X, a.Y - unit), // bottom 
                new Vector2(a.X, a.Y + unit), // top
            };
        }

        /// <summary>
        /// Gets nearby eight <see cref="Vector2"/> instances.
        /// </summary>
        /// <param name="a">Current instance.</param>
        /// <param name="unit">The distance between current and nearby instances on x or y axis.</param>
        /// <returns>A collection of <see cref="Vector2"/> instances in eight direction respectively.</returns>
        public static IEnumerable<Vector2> GetEightDirections(this Vector2 a, float unit)
        {
            return new[]
            {
                new Vector2(a.X + unit, a.Y), // right 
                new Vector2(a.X + unit, a.Y + unit), // right - top 
                new Vector2(a.X + unit, a.Y - unit), // right - bottom 
                new Vector2(a.X - unit, a.Y), // left  
                new Vector2(a.X - unit, a.Y + unit), // left - top
                new Vector2(a.X - unit, a.Y - unit), // left - bottom
                new Vector2(a.X, a.Y - unit), // bottom 
                new Vector2(a.X, a.Y + unit), // top
            };
        }

        /// <summary>
        /// Calculate the Manhattan distance between two <see cref="Vector2"/> instances. 
        /// </summary>
        /// <param name="a">The first instance.</param>
        /// <param name="b">The second instance.</param> 
        /// <returns>The Manhattan Distance between two instances.</returns>
        public static float GetManhattanDistance(this Vector2 a, Vector2 b)
        {
            return DistanceHelper.GetManhattanDistance(a.X, a.Y, b.X, b.Y);
        }

        /// <summary>
        /// Calculate the Chebyshev distance between two <see cref="Vector2"/> instances. 
        /// </summary>
        /// <param name="a">The first instance.</param>
        /// <param name="b">The second instance.</param> 
        /// <returns>The Manhattan Distance between two instances.</returns>
        public static float GetChebyshevDistance(this Vector2 a, Vector2 b)
        {
            return DistanceHelper.GetChebyshevDistance(a.X, a.Y, b.X, b.Y);
        }
    }
}