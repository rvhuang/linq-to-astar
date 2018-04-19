using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    using Core;

    public static class HeuristicSearch
    {
        public static HeuristicSearchBase<TStep, TStep> AStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(AStar<TStep, TStep>), from, to, null, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> AStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(AStar<TStep, TStep>), from, to, comparer, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> BestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(BestFirstSearch<TStep, TStep>), from, to, null, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> BestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(BestFirstSearch<TStep, TStep>), from, to, comparer, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> RecursiveBestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(RecursiveBestFirstSearch<TStep, TStep>), from, to, null, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> RecursiveBestFirstSearch<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(RecursiveBestFirstSearch<TStep, TStep>), from, to, comparer, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> IterativeDeepeningAStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            return new HeuristicSearchInitial<TStep>(nameof(IterativeDeepeningAStar<TStep, TStep>), from, to, null, expander);
        }

        public static HeuristicSearchBase<TStep, TStep> IterativeDeepeningAStar<TStep>(TStep from, TStep to, Func<TStep, int, IEnumerable<TStep>> expander, IEqualityComparer<TStep> comparer)
        {
            return new HeuristicSearchInitial<TStep>(nameof(IterativeDeepeningAStar<TStep, TStep>), from, to, comparer, expander);
        }

        internal static INodeComparer<TStep, TResult> CreateComparer<TResult, TKey, TStep>(Func<TResult, TKey> keySelector, IComparer<TKey> keyComparer, bool descending)
        {
            if (keyComparer != null) return new NormalComparer<TStep, TResult, TKey>(keySelector, keyComparer, descending);

            var comparer = default(INodeComparer<TStep, TResult>);
            
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