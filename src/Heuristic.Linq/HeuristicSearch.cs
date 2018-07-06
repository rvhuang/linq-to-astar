using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Heuristic.Linq.Test")]

namespace Heuristic.Linq
{
    using Algorithms;

    /// <summary>
    /// Provides a set of static methods to initialize <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with specific algorithm.
    /// </summary>
    public static class HeuristicSearch
    {
        #region Fields

        private readonly static ConcurrentDictionary<string, Func<string, IAlgorithm>> algorithms;

        #endregion

        #region Constructor

        static HeuristicSearch()
        {
            var presets = new[]
            {
                new KeyValuePair<string, Func<string, IAlgorithm>>(nameof(AStar), (n) => new AStarAlgorithm()),
                new KeyValuePair<string, Func<string, IAlgorithm>>(nameof(BestFirstSearch), (n) => new BestFirstSearchrAlgorithm()),
                new KeyValuePair<string, Func<string, IAlgorithm>>(nameof(IterativeDeepeningAStar), (n) => new IterativeDeepeningAStarAlgorithm()),
                new KeyValuePair<string, Func<string, IAlgorithm>>(nameof(RecursiveBestFirstSearch), (n) => new RecursiveBestFirstSearchAlgorithm()),
            };
            algorithms = new ConcurrentDictionary<string, Func<string, IAlgorithm>>(presets);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a read-only dictionary that contains registered <see cref="IAlgorithm"/> names their corresponding factory methods.
        /// </summary>
        public static IReadOnlyDictionary<string, Func<string, IAlgorithm>> RegisteredAlgorithms => algorithms;

        #endregion

        #region Built-in Algorithms

        /// <summary>
        /// Initialize an <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with A* search algorithm.
        /// </summary>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="from">The initial step of the problem.</param>
        /// <param name="to">The goal step of the problem.</param>
        /// <param name="expander">The callback that expands specific step to available next steps.</param>
        /// <returns>The instance that is ready to be applied with LINQ expressions.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="expander"/> is null.</exception>
        public static HeuristicSearchBase<TStep, TStep> AStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(AStar), from, to, null, expander);
        }

        /// <summary>
        /// Initialize an <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with A* search algorithm.
        /// </summary>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="from">The initial step of the problem.</param>
        /// <param name="to">The goal step of the problem.</param>
        /// <param name="expander">The callback that expands specific step to available next steps.</param>
        /// <param name="comparer">The comparer to test equality of two <typeparamref name="TStep"/> instance.</param>
        /// <returns>The instance that is ready to be applied with LINQ expressions.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="expander"/> is null.</exception>
        public static HeuristicSearchBase<TStep, TStep> AStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(AStar), from, to, comparer, expander);
        }

        /// <summary>
        /// Initialize an <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with Best-first Search (BFS) algorithm.
        /// </summary>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="from">The initial step of the problem.</param>
        /// <param name="to">The goal step of the problem.</param>
        /// <param name="expander">The callback that expands specific step to available next steps.</param>
        /// <returns>The instance that is ready to be applied with LINQ expressions.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="expander"/> is null.</exception>
        public static HeuristicSearchBase<TStep, TStep> BestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(BestFirstSearch), from, to, null, expander);
        }

        /// <summary>
        /// Initialize an <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with Best-first Search (BFS) algorithm.
        /// </summary>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="from">The initial step of the problem.</param>
        /// <param name="to">The goal step of the problem.</param>
        /// <param name="expander">The callback that expands specific step to available next steps.</param>
        /// <param name="comparer">The comparer to test equality of two <typeparamref name="TStep"/> instance.</param>
        /// <returns>The instance that is ready to be applied with LINQ expressions.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="expander"/> is null.</exception>
        public static HeuristicSearchBase<TStep, TStep> BestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(BestFirstSearch), from, to, comparer, expander);
        }

        /// <summary>
        /// Initialize an <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with Recursive Best-first Search (RBFS) algorithm.
        /// </summary>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="from">The initial step of the problem.</param>
        /// <param name="to">The goal step of the problem.</param>
        /// <param name="expander">The callback that expands specific step to available next steps.</param>
        /// <returns>The instance that is ready to be applied with LINQ expressions.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="expander"/> is null.</exception>
        public static HeuristicSearchBase<TStep, TStep> RecursiveBestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(RecursiveBestFirstSearch), from, to, null, expander);
        }

        /// <summary>
        /// Initialize an <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with Recursive Best-first Search (RBFS) algorithm.
        /// </summary>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="from">The initial step of the problem.</param>
        /// <param name="to">The goal step of the problem.</param>
        /// <param name="expander">The callback that expands specific step to available next steps.</param>
        /// <param name="comparer">The comparer to test equality of two <typeparamref name="TStep"/> instance.</param>
        /// <returns>The instance that is ready to be applied with LINQ expressions.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="expander"/> is null.</exception>
        public static HeuristicSearchBase<TStep, TStep> RecursiveBestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(RecursiveBestFirstSearch), from, to, comparer, expander);
        }

        /// <summary>
        /// Initialize an <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with Iterative Deepening A* (IDA*) algorithm.
        /// </summary>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="from">The initial step of the problem.</param>
        /// <param name="to">The goal step of the problem.</param>
        /// <param name="expander">The callback that expands specific step to available next steps.</param>
        /// <returns>The instance that is ready to be applied with LINQ expressions.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="expander"/> is null.</exception>
        public static HeuristicSearchBase<TStep, TStep> IterativeDeepeningAStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(IterativeDeepeningAStar), from, to, null, expander);
        }

        /// <summary>
        /// Initialize an <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with Iterative Deepening A* (IDA*) algorithm.
        /// </summary>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="from">The initial step of the problem.</param>
        /// <param name="to">The goal step of the problem.</param>
        /// <param name="expander">The callback that expands specific step to available next steps.</param>
        /// <param name="comparer">The comparer to test equality of two <typeparamref name="TStep"/> instance.</param>
        /// <returns>The instance that is ready to be applied with LINQ expressions.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="expander"/> is null.</exception>
        public static HeuristicSearchBase<TStep, TStep> IterativeDeepeningAStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(IterativeDeepeningAStar), from, to, comparer, expander);
        }

        #endregion

        #region Customized Algorithms

        /// <summary>
        /// Registers a user-defined algorithm.
        /// </summary>
        /// <typeparam name="TAlgorithm">The type of algorithm that implements <see cref="IAlgorithm"/> interface.</typeparam>
        /// <param name="algorithmName">The name of algorithm</param>
        /// <returns>true if successfully registered. Otherwise false.</returns>
        public static bool Register<TAlgorithm>(string algorithmName)
            where TAlgorithm : IAlgorithm, new()
        {
            return Register<TAlgorithm>(algorithmName, (name) => new TAlgorithm());
        }

        /// <summary>
        /// Registers a user-defined algorithm with its factory method.
        /// </summary>
        /// <typeparam name="TAlgorithm">The type of algorithm that implements <see cref="IAlgorithm"/> interface.</typeparam>
        /// <param name="algorithmName">The name of algorithm</param>
        /// <param name="factory"></param>
        /// <returns>true if successfully registered. Otherwise false.</returns>
        public static bool Register<TAlgorithm>(string algorithmName, Func<string, IAlgorithm> factory)
            where TAlgorithm : IAlgorithm
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            try
            {
                return algorithms.TryAdd(algorithmName, factory);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(nameof(algorithmName), e);
            }
        }

        /// <summary>
        /// Initialize an <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with user-defined algorithm.
        /// </summary>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="algorithmName">The name of algorithm</param>
        /// <param name="from">The initial step of the problem.</param>
        /// <param name="to">The goal step of the problem.</param>
        /// <param name="expander">The callback that expands specific step to available next steps.</param>
        /// <returns>The instance that is ready to be applied with LINQ expressions.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="expander"/> is null.</exception>
        public static HeuristicSearchBase<TStep, TStep> Use<TStep>(string algorithmName, TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return Use(algorithmName, from, to, expander, null);
        }

        /// <summary>
        /// Initialize an <see cref="HeuristicSearchBase{TFactor, TStep}"/> instance with user-defined algorithm.
        /// </summary>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="algorithmName">The name of algorithm</param>
        /// <param name="from">The initial step of the problem.</param>
        /// <param name="to">The goal step of the problem.</param>
        /// <param name="expander">The callback that expands specific step to available next steps.</param>
        /// <param name="comparer">The comparer to test equality of two <typeparamref name="TStep"/> instance.</param>
        /// <returns>The instance that is ready to be applied with LINQ expressions.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="algorithmName"/> or <paramref name="expander"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="algorithmName"/> cannot be found.</exception>
        public static HeuristicSearchBase<TStep, TStep> Use<TStep>(string algorithmName, TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            try
            {
                if (!algorithms.ContainsKey(algorithmName)) throw new ArgumentException(nameof(algorithmName));
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(nameof(algorithmName), e);
            }
            return new HeuristicSearchInitial<TStep>(algorithmName, from, to, comparer, expander);
        }

        #endregion
    }
}