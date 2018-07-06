using System.Collections.Generic;

namespace Heuristic.Linq
{
    static class ComparerExtensions
    {
        public static T Min<T>(this IComparer<T> comparer, T a, T b)
        {
            if (a == null) return b;
            if (b == null) return a;

            return (comparer ?? Comparer<T>.Default).Compare(a, b) < 0 ? a : b;
        }

        public static T Max<T>(this IComparer<T> comparer, T a, T b)
        {
            if (a == null) return b;
            if (b == null) return a;

            return (comparer ?? Comparer<T>.Default).Compare(a, b) > 0 ? a : b;
        }
    }
}
