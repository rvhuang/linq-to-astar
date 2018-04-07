using System.Collections.Generic;
using System.Numerics;

namespace LinqToAStar
{
    public static class VectorExtensions
    {
        public static IEnumerable<Vector2> GetFourDirections(this Vector2 a, float unit)
        {
            return new []
            {
                new Vector2(a.X + unit, a.Y), // right 
                new Vector2(a.X - unit, a.Y), // left 
                new Vector2(a.X, a.Y - unit), // bottom 
                new Vector2(a.X, a.Y + unit), // top
            };
        }

        public static IEnumerable<Vector2> GetEightDirections(this Vector2 a, float unit)
        {
            return new []
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

        public static float GetManhattanDistance(this Vector2 a, Vector2 b)
        {
            return DistanceHelper.GetManhattanDistance(a.X, a.Y, b.X, b.Y);
        }

        public static float GetChebyshevDistance(this Vector2 a, Vector2 b)
        {
            return DistanceHelper.GetChebyshevDistance(a.X, a.Y, b.X, b.Y);
        }

    }
}
