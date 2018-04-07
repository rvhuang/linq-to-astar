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

        #endregion

        #region Chebyshev Distance

        public static float GetChebyshevDistance(float x1, float y1, float x2, float y2)
        {
            return Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
        }

        #endregion
    }
}