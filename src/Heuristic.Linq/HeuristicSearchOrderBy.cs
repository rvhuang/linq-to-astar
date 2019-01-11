using System;
using System.Collections.Generic;
using System.Linq;

namespace Heuristic.Linq
{
    /// <summary>
    /// Defines the instance that is applied with heuristic function.
    /// </summary>
    /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>
    public class HeuristicSearchOrderBy<TFactor, TStep> : HeuristicSearchBase<TFactor, TStep>, IOrderedEnumerable<TFactor>
    {
        #region Constructors

        internal HeuristicSearchOrderBy(HeuristicSearchBase<TFactor, TStep> source, INodeComparer<TFactor, TStep> nodeComparer)
            : base(source.AlgorithmName, source.From, source.To, source.StepComparer, nodeComparer, source.Converter, source.Expander)
        {
            IsReversed = source.IsReversed;
            AlgorithmObserverFactory = source.AlgorithmObserverFactory;
        }

        #endregion

        #region IOrderedEnumerable<TFactor>

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, float> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, double> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, decimal> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, byte> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, sbyte> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, short> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, ushort> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, int> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, uint> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, long> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, ulong> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable<TKey>(Func<TFactor, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = NodeComparer;
            var comparer2 = new NormalComparer<TFactor, TKey, TStep>(keySelector, null, descending);

            return new HeuristicSearchOrderBy<TFactor, TStep>(this, new CombinedComparer<TFactor, TStep>(comparer1, comparer2));
        }

        IOrderedEnumerable<TFactor> IOrderedEnumerable<TFactor>.CreateOrderedEnumerable<TKey>(Func<TFactor, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            return CreateOrderedEnumerable(keySelector, comparer, descending);
        }

        #endregion

        #region Override

        /// <summary>
        /// Gets the string that represents current instance.
        /// </summary>
        /// <returns>The string that represents current instance.</returns>
        /// <remarks>This will print out LINQ expression stack from inital to current instance.</remarks>
        public override string ToString()
        {
            return string.Join(" -> ", Source == null ? "(Initial)" : Source.ToString(), base.ToString());
        }

        #endregion
    }
}