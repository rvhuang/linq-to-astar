using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    public static partial class Extensions
    {
        public static HeuristicSearchBase<TFactor, TStep> Select<TSource, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, TFactor> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelect<TSource, TFactor, TStep>(source, (s, i) => selector(s));
        }

        public static HeuristicSearchBase<TFactor, TStep> Select<TSource, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, TFactor> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelect<TSource, TFactor, TStep>(source, selector);
        }

        public static HeuristicSearchBase<TFactor, TStep> SelectMany<TSource, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, IEnumerable<TFactor>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelectMany<TSource, TFactor, TStep>(source, (s, i) => selector(s));
        }

        public static HeuristicSearchBase<TFactor, TStep> SelectMany<TSource, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, IEnumerable<TFactor>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelectMany<TSource, TFactor, TStep>(source, selector);
        }

        public static HeuristicSearchBase<TFactor, TStep> SelectMany<TSource, TCollection, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TFactor> resultSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return new HeuristicSearchSelectMany<TSource, TCollection, TFactor, TStep>(source, (s, i) => collectionSelector(s), resultSelector);
        }

        public static HeuristicSearchBase<TFactor, TStep> SelectMany<TSource, TCollection, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TFactor> resultSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return new HeuristicSearchSelectMany<TSource, TCollection, TFactor, TStep>(source, collectionSelector, resultSelector);
        }

        public static HeuristicSearchBase<TFactor, TStep> Where<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return new HeuristicSearchWhere<TFactor, TStep>(source, (r, i) => predicate(r));
        }

        public static HeuristicSearchBase<TFactor, TStep> Where<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return new HeuristicSearchWhere<TFactor, TStep>(source, predicate);
        }

        public static HeuristicSearchBase<TFactor, TStep> Except<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, IEnumerable<TFactor> collection)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchExcept<TFactor, TStep>(source, collection, null);
        }

        public static HeuristicSearchBase<TFactor, TStep> Except<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, IEnumerable<TFactor> collection, IEqualityComparer<TFactor> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchExcept<TFactor, TStep>(source, collection, comparer);
        }

        public static HeuristicSearchBase<TFactor, TStep> Contains<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, IEnumerable<TFactor> collection)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchContains<TFactor, TStep>(source, collection, null);
        }

        public static HeuristicSearchBase<TFactor, TStep> Contains<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, IEnumerable<TFactor> collection, IEqualityComparer<TFactor> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchContains<TFactor, TStep>(source, collection, comparer);
        }
    }
}