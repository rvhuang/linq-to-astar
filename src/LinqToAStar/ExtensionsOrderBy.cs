using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    public static partial class Extensions
    {
        #region OrderBy

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, float> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, double> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }
        
        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, decimal> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, byte> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, sbyte> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, short> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, ushort> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, int> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, uint> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, long> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, ulong> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TKey, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, TKey> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TKey, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, ComparerExtensions.CreateComparer<TResult, TKey, TStep>(keySelector, comparer, false));
        }

        #endregion

        #region OrderByDescending

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, float> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, double> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, decimal> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, byte> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, sbyte> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, short> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, ushort> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, int> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, uint> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, long> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, ulong> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TKey, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, TKey> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TKey, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, ComparerExtensions.CreateComparer<TResult, TKey, TStep>(keySelector, comparer, true));
        }

        #endregion

        #region ThenBy

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, float> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, double> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, decimal> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, byte> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, sbyte> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, short> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, ushort> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, int> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, uint> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, long> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, ulong> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TKey, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, TKey> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TKey, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        #endregion

        #region ThenByDescending

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, float> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, double> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, decimal> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, byte> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, sbyte> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, short> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, ushort> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, int> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, uint> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, long> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, ulong> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TKey, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, TKey> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TKey, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, comparer, true);
        }

        #endregion
    }
}