using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Heuristic.Linq
{
    using Algorithms;

    /// <summary>
    /// Provide a set of LINQ clauses to <see cref="HeuristicSearchBase{TFactor, TStep}"/> class.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Select the factor used to evaluate with heuristic functions.
        /// </summary>
        /// <typeparam name="TSource">The source type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="selector">The selector to select factor from current instance.</param>
        /// <returns>An instance with type <typeparamref name="TFactor"/> as factor.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> is null.</exception>
        public static HeuristicSearchBase<TFactor, TStep> Select<TSource, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, TFactor> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelect<TSource, TFactor, TStep>(source, (s, i) => selector(s));
        }

        /// <summary>
        /// Select the factor used to evaluate with heuristic functions.
        /// </summary>
        /// <typeparam name="TSource">The source type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="selector">The selector with index argument to select factor from current instance.</param>
        /// <returns>An instance with type <typeparamref name="TFactor"/> as factor.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> is null.</exception>
        public static HeuristicSearchBase<TFactor, TStep> Select<TSource, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, TFactor> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelect<TSource, TFactor, TStep>(source, selector);
        }

        /// <summary>
        /// Select one or more factors used to evaluate with heuristic functions.
        /// </summary>
        /// <typeparam name="TSource">The source type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="selector">The selector to select factor from current instance.</param>
        /// <returns>An instance with type <typeparamref name="TFactor"/> as factor.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> is null.</exception>
        /// <remarks>Only the factor with lowest cost estimated by heuristic function will be considerd.</remarks>
        public static HeuristicSearchBase<TFactor, TStep> SelectMany<TSource, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, IEnumerable<TFactor>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelectMany<TSource, TFactor, TStep>(source, (s, i) => selector(s));
        }

        /// <summary>
        /// Select one or more factors used to evaluate with heuristic functions.
        /// </summary>
        /// <typeparam name="TSource">The source type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="selector">The selector with index argument to select factor from current instance.</param>
        /// <returns>An instance with type <typeparamref name="TFactor"/> as factor.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> is null.</exception>
        /// <remarks>Only the factor with lowest cost estimated by heuristic function will be considerd.</remarks>
        public static HeuristicSearchBase<TFactor, TStep> SelectMany<TSource, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, IEnumerable<TFactor>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return new HeuristicSearchSelectMany<TSource, TFactor, TStep>(source, selector);
        }

        /// <summary>
        /// Select one or more factors used to evaluate with heuristic functions.
        /// </summary>
        /// <typeparam name="TSource">The source type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TCollection">The type of the intermediate elements collected by the function represented by <paramref name="collectionSelector"/>.</typeparam>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="collectionSelector">A projection function to apply to each element of the source.</param>
        /// <param name="factorSelector">The selector to select factor from current instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="collectionSelector"/> or <paramref name="factorSelector"/> is null.</exception>
        /// <returns>An instance with type <typeparamref name="TFactor"/> as factor.</returns>
        /// <remarks>Only the factor with lowest cost estimated by heuristic function will be considerd.</remarks>
        public static HeuristicSearchBase<TFactor, TStep> SelectMany<TSource, TCollection, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TFactor> factorSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (factorSelector == null) throw new ArgumentNullException(nameof(factorSelector));

            return new HeuristicSearchSelectMany<TSource, TCollection, TFactor, TStep>(source, (s, i) => collectionSelector(s), factorSelector);
        }

        /// <summary>
        /// Select one or more factors used to evaluate with heuristic functions.
        /// </summary>
        /// <typeparam name="TSource">The source type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TCollection">The type of the intermediate elements collected by the function represented by <paramref name="collectionSelector"/>.</typeparam>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="collectionSelector">A projection function to apply to each element of the source.</param>
        /// <param name="factorSelector">The selector to select factor from current instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="collectionSelector"/> or <paramref name="factorSelector"/> is null.</exception>
        /// <returns>An instance with type <typeparamref name="TFactor"/> as factor.</returns>
        /// <remarks>Only the factor with lowest cost estimated by heuristic function will be considerd.</remarks>
        public static HeuristicSearchBase<TFactor, TStep> SelectMany<TSource, TCollection, TFactor, TStep>(this HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TFactor> factorSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (factorSelector == null) throw new ArgumentNullException(nameof(factorSelector));

            return new HeuristicSearchSelectMany<TSource, TCollection, TFactor, TStep>(source, collectionSelector, factorSelector);
        }

        /// <summary>
        /// Apply filter to current instance. 
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="predicate">A function to test each source element for a condition.</param>
        /// <returns>The instance with appied filter.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
        public static HeuristicSearchBase<TFactor, TStep> Where<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return new HeuristicSearchWhere<TFactor, TStep>(source, (r, i) => predicate(r));
        }

        /// <summary>
        /// Apply filter to current instance. 
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="predicate">A function to test each source element and its index for a condition.</param>
        /// <returns>The instance with appied filter.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
        public static HeuristicSearchBase<TFactor, TStep> Where<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return new HeuristicSearchWhere<TFactor, TStep>(source, predicate);
        }

        /// <summary>
        /// Apply black-listing filter to current instance by giving a <typeparamref name="TStep"/> collection.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="collection">The collection as filter condition.</param>
        /// <returns>The instance with appied filter.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="collection"/> is null.</exception>
        public static HeuristicSearchBase<TFactor, TStep> Except<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, IEnumerable<TFactor> collection)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchExcept<TFactor, TStep>(source, collection, null);
        }

        /// <summary>
        /// Apply black-listing  filter to current instance by giving a <typeparamref name="TStep"/> collection and specific comparer.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="collection">The collection as filter condition.</param>
        /// <param name="comparer">The specific comparer.</param>
        /// <returns>The instance with appied filter.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="collection"/> is null.</exception>
        public static HeuristicSearchBase<TFactor, TStep> Except<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, IEnumerable<TFactor> collection, IEqualityComparer<TFactor> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchExcept<TFactor, TStep>(source, collection, comparer);
        }

        /// <summary>
        /// Apply white-listing filter to current instance by giving a <typeparamref name="TStep"/> collection.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="collection">The collection as filter condition.</param>
        /// <returns>The instance with appied filter.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="collection"/> is null.</exception>
        public static HeuristicSearchBase<TFactor, TStep> Contains<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, IEnumerable<TFactor> collection)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchContains<TFactor, TStep>(source, collection, null);
        }

        /// <summary>
        /// Apply white-listing  filter to current instance by giving a <typeparamref name="TStep"/> collection and specific comparer.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="collection">The collection as filter condition.</param>
        /// <param name="comparer">The specific comparer.</param>
        /// <returns>The instance with appied filter.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="collection"/> is null.</exception>
        public static HeuristicSearchBase<TFactor, TStep> Contains<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, IEnumerable<TFactor> collection, IEqualityComparer<TFactor> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return new HeuristicSearchContains<TFactor, TStep>(source, collection, comparer);
        }

        /// <summary>
        /// Inverts the order of solution from <see cref="HeuristicSearchBase{TFactor, TStep}.From"/> to <see cref="HeuristicSearchBase{TFactor, TStep}.To"/> 
        /// to <see cref="HeuristicSearchBase{TFactor, TStep}.To"/> to <see cref="HeuristicSearchBase{TFactor, TStep}.From"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <returns>An instance with type <typeparamref name="TFactor"/> as factor.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static HeuristicSearchBase<TFactor, TStep> Reverse<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            source.IsReversed = !source.IsReversed;

            return source;
        }

        /// <summary>
        /// Determines whether the solution can be found.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <returns>true if the solution can be found; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static bool Any<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.Run() != null;
        }

        /// <summary>
        /// Returns the number of steps in solution.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <returns>The number of steps in solution.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static int Count<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var lastNode = source.Run();

            return lastNode == null ? 0 : lastNode.Level + 1;
        }

        /// <summary>
        /// Returns the number of steps in solution, in <see cref="Int64"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <returns>The number of steps in solution.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static long LongCount<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var lastNode = source.Run();

            return lastNode == null ? 0 : lastNode.Level + 1;
        }

        /// <summary>
        /// Returns first step of the solution.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <returns>The first step of the solution.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Solution is not found.</exception>
        public static TFactor First<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var lastNode = source.Run();

            if (lastNode == null) throw new InvalidOperationException("Sequence contains no elements.");

            return source.IsReversed ? lastNode.Factor : lastNode.TraceBack().Factor;
        }

        /// <summary>
        /// Returns first step of the solution, or default value of <typeparamref name="TFactor"/> if solution is not found.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <returns>The first step of the solution.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception> 
        public static TFactor FirstOrDefault<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var lastNode = source.Run();

            if (lastNode == null) return default(TFactor);

            return source.IsReversed ? lastNode.Factor : lastNode.TraceBack().Factor;
        }

        /// <summary>
        /// Returns last step of the solution.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <returns>The last step of the solution.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Solution is not found.</exception>
        public static TFactor Last<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var lastNode = source.Run();

            if (lastNode == null) throw new InvalidOperationException("Sequence contains no elements.");

            return source.IsReversed ? lastNode.TraceBack().Factor : lastNode.Factor;
        }

        /// <summary>
        /// Returns last step of the solution, or default value of <typeparamref name="TFactor"/> if solution is not found.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <returns>The last step of the solution.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception> 
        public static TFactor LastOrDefault<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var lastNode = source.Run();

            if (lastNode == null) return default(TFactor);

            return source.IsReversed ? lastNode.TraceBack().Factor : lastNode.Factor;
        }

        internal static Node<TFactor, TStep> Run<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source)
        {
            Debug.WriteLine($"Searching path between {source.From} and {source.To} with {source.AlgorithmName}...");

            var lastNode = default(Node<TFactor, TStep>);

            switch (source.AlgorithmName)
            {
                case nameof(AStar):
                    lastNode = AStar.Run(source);
                    break;

                case nameof(BestFirstSearch):
                    lastNode = BestFirstSearch.Run(source);
                    break;

                case nameof(IterativeDeepeningAStar):
                    lastNode = IterativeDeepeningAStar.Run(source);
                    break;

                case nameof(RecursiveBestFirstSearch):
                    lastNode = RecursiveBestFirstSearch.Run(source);
                    break;

                default:
                    lastNode = HeuristicSearch.RegisteredAlgorithms[source.AlgorithmName](source.AlgorithmName).Run(source);
                    break;
            }

            return lastNode;
        }
    }
}