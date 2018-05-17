using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    using Core;

    public static class HeuristicSearch
    {
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

        internal static INodeComparer<TResult, TStep> CreateComparer<TResult, TKey, TStep>(Func<TResult, TKey> keySelector, IComparer<TKey> keyComparer, bool descending)
        {
            if (keyComparer != null) return new NormalComparer<TStep, TResult, TKey>(keySelector, keyComparer, descending);

            var comparer = default(INodeComparer<TResult, TStep>);
            
            switch (Type.GetTypeCode(typeof(TKey)))
            {
                case TypeCode.Byte:
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
                    comparer = new HeuristicComparer<TStep, TResult, TKey>(keySelector, descending);
                    break;

                default:
                    comparer = new NormalComparer<TStep, TResult, TKey>(keySelector, null, descending);
                    break;
            }
            return comparer;
        }
    }
}