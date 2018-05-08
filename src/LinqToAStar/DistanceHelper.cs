using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    public static class DistanceHelper
    {
        public static readonly IEqualityComparer<long> Int64EqualityComparer = EqualityComparer<long>.Default;
        public static readonly IEqualityComparer<int> Int32EqualityComparer = EqualityComparer<int>.Default;
        public static readonly IComparer<long> Int64Comparer = Comparer<long>.Default;
        public static readonly IComparer<int> Int32Comparer = Comparer<int>.Default;
        public static readonly IComparer<double> DoubleComparer = Comparer<double>.Default;

        #region Manhattan Distance

        public static float GetManhattanDistance(float x1, float y1, float x2, float y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        public static int GetManhattanDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        #endregion

        #region Chebyshev Distance

        public static float GetChebyshevDistance(float x1, float y1, float x2, float y2)
        {
            return Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
        }

        public static int GetChebyshevDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
        }

        #endregion

        #region Chebyshev Distance

        public static double GetEuclideanDistance(float x1, float y1, float x2, float y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
         
        public static double GetEuclideanDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        #endregion
    }
}