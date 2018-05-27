using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    public static partial class Extensions
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

            return new HeuristicSearchSelectMany<TSource, TCollection, TResult, TStep>(source, collectionSelector, resultSelector);
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

        public static HeuristicSearchBase<TResult, TStep> Except<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, IEnumerable<TResult> collection)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchExcept<TResult, TStep>(source, collection, null);
        }

        public static HeuristicSearchBase<TResult, TStep> Except<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, IEnumerable<TResult> collection, IEqualityComparer<TResult> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchExcept<TResult, TStep>(source, collection, comparer);
        }

        public static HeuristicSearchBase<TResult, TStep> Contains<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, IEnumerable<TResult> collection)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchContains<TResult, TStep>(source, collection, null);
        }

        public static HeuristicSearchBase<TResult, TStep> Contains<TResult, TStep>(this HeuristicSearchBase<TResult, TStep> source, IEnumerable<TResult> collection, IEqualityComparer<TResult> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchContains<TResult, TStep>(source, collection, comparer);
        }
    }
}