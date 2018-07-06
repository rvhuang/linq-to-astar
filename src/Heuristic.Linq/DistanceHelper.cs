using System;
using System.Collections.Generic;

namespace Heuristic.Linq
{
    /// <summary>
    /// Provides a set of static methods that calculate the distance between two positions.
    /// </summary>
    public static class DistanceHelper
    {
        internal static readonly IComparer<byte> ByteComparer = Comparer<byte>.Default;
        internal static readonly IComparer<ushort> UInt16Comparer = Comparer<ushort>.Default;
        internal static readonly IComparer<uint> UInt32Comparer = Comparer<uint>.Default;
        internal static readonly IComparer<ulong> UInt64Comparer = Comparer<ulong>.Default;
        internal static readonly IComparer<sbyte> SByteComparer = Comparer<sbyte>.Default;
        internal static readonly IComparer<short> Int16Comparer = Comparer<short>.Default;
        internal static readonly IComparer<int> Int32Comparer = Comparer<int>.Default;
        internal static readonly IComparer<long> Int64Comparer = Comparer<long>.Default;
        internal static readonly IComparer<float> SingleComparer = Comparer<float>.Default;
        internal static readonly IComparer<double> DoubleComparer = Comparer<double>.Default;
        internal static readonly IComparer<decimal> DecimalComparer = Comparer<decimal>.Default;

        #region Manhattan Distance

        /// <summary>
        /// Calculate the Manhattan distance between two positions. 
        /// </summary>
        /// <param name="x1">The x-coordinate of first position.</param>
        /// <param name="y1">The y-coordinate of first position.</param>
        /// <param name="x2">The x-coordinate of second position.</param>
        /// <param name="y2">The y-coordinate of second position.</param>
        /// <returns>The Manhattan Distance between two positions.</returns>
        public static float GetManhattanDistance(float x1, float y1, float x2, float y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        /// <summary>
        /// Calculate the Manhattan distance between two positions. 
        /// </summary>
        /// <param name="x1">The x-coordinate of first position.</param>
        /// <param name="y1">The y-coordinate of first position.</param>
        /// <param name="x2">The x-coordinate of second position.</param>
        /// <param name="y2">The y-coordinate of second position.</param>
        /// <returns>The Manhattan Distance between two positions.</returns>
        public static int GetManhattanDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        #endregion

        #region Chebyshev Distance

        /// <summary>
        /// Calculate the Chebyshev distance between two positions. 
        /// </summary>
        /// <param name="x1">The x-coordinate of first position.</param>
        /// <param name="y1">The y-coordinate of first position.</param>
        /// <param name="x2">The x-coordinate of second position.</param>
        /// <param name="y2">The y-coordinate of second position.</param>
        /// <returns>The Chebyshev Distance between two positions.</returns>
        public static float GetChebyshevDistance(float x1, float y1, float x2, float y2)
        {
            return Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
        }

        /// <summary>
        /// Calculate the Chebyshev distance between two positions. 
        /// </summary>
        /// <param name="x1">The x-coordinate of first position.</param>
        /// <param name="y1">The y-coordinate of first position.</param>
        /// <param name="x2">The x-coordinate of second position.</param>
        /// <param name="y2">The y-coordinate of second position.</param>
        /// <returns>The Chebyshev Distance between two positions.</returns>
        public static int GetChebyshevDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
        }

        #endregion

        #region Euclidean Distance

        /// <summary>
        /// Calculate the Euclidean distance between two positions. 
        /// </summary>
        /// <param name="x1">The x-coordinate of first position.</param>
        /// <param name="y1">The y-coordinate of first position.</param>
        /// <param name="x2">The x-coordinate of second position.</param>
        /// <param name="y2">The y-coordinate of second position.</param>
        /// <returns>The Euclidean Distance between two positions.</returns>
        public static double GetEuclideanDistance(float x1, float y1, float x2, float y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        /// <summary>
        /// Calculate the Euclidean distance between two positions. 
        /// </summary>
        /// <param name="x1">The x-coordinate of first position.</param>
        /// <param name="y1">The y-coordinate of first position.</param>
        /// <param name="x2">The x-coordinate of second position.</param>
        /// <param name="y2">The y-coordinate of second position.</param>
        /// <returns>The Euclidean Distance between two positions.</returns>
        public static double GetEuclideanDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        #endregion
    }
}