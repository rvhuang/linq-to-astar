using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LinqToAStar
{
    public static class HeuristicSearch
    {
        #region Fields

        private readonly static ConcurrentDictionary<string, Func<string, IAlgorithm>> algorithms = new ConcurrentDictionary<string, Func<string, IAlgorithm>>();

        #endregion

        #region Properties

        public static IReadOnlyDictionary<string, Func<string, IAlgorithm>> RegisteredAlgorithms => algorithms;

        #endregion

        #region Built-in Algorithms

        public static HeuristicSearchBase<TStep, TStep> AStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(AStar), from, to, null, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> AStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(AStar), from, to, comparer, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> BestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(BestFirstSearch), from, to, null, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> BestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(BestFirstSearch), from, to, comparer, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> RecursiveBestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(RecursiveBestFirstSearch), from, to, null, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> RecursiveBestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(RecursiveBestFirstSearch), from, to, comparer, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> IterativeDeepeningAStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(IterativeDeepeningAStar), from, to, null, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> IterativeDeepeningAStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(IterativeDeepeningAStar), from, to, comparer, expander);
        }

        #endregion

        #region Customized Algorithms

        public static bool Register<TAlgorithm>(string algorithmName)
            where TAlgorithm : IAlgorithm, new()
        {
            return Register<TAlgorithm>(algorithmName, (name) => new TAlgorithm());
        }

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

        public static HeuristicSearchBase<TStep, TStep> Use<TStep>(string algorithmName, TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return Use(algorithmName, from, to, expander, null);
        }

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