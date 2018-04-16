using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar
{
    public static class Extensions
    {
        public static HeuristicSearchBase<TResult, TStep> Select<TSource, TResult, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelect<TSource, TResult, TStep>(source, (s, i) => selector(s));
        }

        public static HeuristicSearchBase<TResult, TStep> Select<TSource, TResult, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelect<TSource, TResult, TStep>(source, selector);
        }

        public static HeuristicSearchBase<TResult, TStep> SelectMany<TSource, TResult, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelectMany<TSource, TResult, TStep>(source, (s, i) => selector(s));
        }

        public static HeuristicSearchBase<TResult, TStep> SelectMany<TSource, TResult, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, IEnumerable<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelectMany<TSource, TResult, TStep>(source, selector);
        }

        public static HeuristicSearchBase<TResult, TStep> SelectMany<TSource, TCollection, TResult, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return new HeuristicSearchSelectMany<TSource, TCollection, TResult, TStep>(source, (s, i) => collectionSelector(s), resultSelector);
        }

        public static HeuristicSearchBase<TResult, TStep> SelectMany<TSource, TCollection, TResult, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return new HeuristicSearchSelectMany<TSource, TCollection , TResult, TStep>(source, collectionSelector, resultSelector);
        }

        public static HeuristicSearchBase<TResult, TStep> Where<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return new HeuristicSearchWhere<TResult, TStep>(source, (r, i) => predicate(r));
        }

        public static HeuristicSearchBase<TResult, TStep> Where<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return new HeuristicSearchWhere<TResult, TStep>(source, predicate);
        }

        public static HeuristicSearchBase<TResult, TStep> OrderBy<TResult, TKey, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            
            var comparer = default(ComparerBase<TStep, TResult>);

            switch (Type.GetTypeCode(typeof(TKey)))
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    comparer = new HeuristicComparer<TStep, TResult, TKey>(keySelector, false);
                    break;

                default:
                    comparer = new NormalComparer<TStep, TResult, TKey>(keySelector, null, false);
                    break;
            }
            return new HeuristicSearchOrderBy<TResult, TStep>(source, comparer);
        }

        public static HeuristicSearchBase<TResult, TStep> OrderByDescending<TResult, TKey, TStep>(this HeuristicSearchBase<TResult, TStep> source, Func<TResult, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            
            var comparer = default(ComparerBase<TStep, TResult>);

            switch (Type.GetTypeCode(typeof(TKey)))
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    comparer = new HeuristicComparer<TStep, TResult, TKey>(keySelector, true);
                    break;

                default:
                    comparer = new NormalComparer<TStep, TResult, TKey>(keySelector, null, true);
                    break;
            }
            return new HeuristicSearchOrderBy<TResult, TStep>(source, comparer);
        }

        public static HeuristicSearchBase<TResult, TStep> Except<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, IEnumerable<TResult> collection)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchWhere<TResult, TStep>(source, (r, i) => !collection.Contains(r));
        }

        public static HeuristicSearchBase<TResult, TStep> Except<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, IEnumerable<TResult> collection, IEqualityComparer<TResult> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchWhere<TResult, TStep>(source, (r, i) => !collection.Contains(r, comparer));
        }
    }
}