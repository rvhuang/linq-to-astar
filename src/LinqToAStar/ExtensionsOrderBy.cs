using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    public static partial class Extensions
    {
        #region OrderBy

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TKey, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new NormalComparer<TResult, TKey, TStep>(keySelector, null, false));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderBy<TResult, TKey, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new NormalComparer<TResult, TKey, TStep>(keySelector, comparer, false));
        }

        #endregion

        #region OrderByDescending

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new HeuristicComparer<TResult, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TKey, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, TKey> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> OrderByDescending<TResult, TKey, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TResult, TStep>(source, new NormalComparer<TResult,  TKey, TStep>(keySelector, null, true));
        }

        #endregion

        #region ThenBy

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenBy<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
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
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TResult, TStep> ThenByDescending<TResult, TStep>(this HeuristicSearchOrderBy<TResult, TStep> source, Func<TResult, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
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