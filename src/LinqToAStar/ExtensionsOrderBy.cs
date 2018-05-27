using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    public static partial class Extensions
    {
        #region OrderBy

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TKey, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new NormalComparer<TFactor, TKey, TStep>(keySelector, null, false));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TKey, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new NormalComparer<TFactor, TKey, TStep>(keySelector, comparer, false));
        }

        #endregion

        #region OrderByDescending

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TKey, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, TKey> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TKey, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new NormalComparer<TFactor,  TKey, TStep>(keySelector, null, true));
        }

        #endregion

        #region ThenBy

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TKey, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, TKey> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TKey, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        #endregion

        #region ThenByDescending

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TKey, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, TKey> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TKey, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, comparer, true);
        }

        #endregion
    }
}