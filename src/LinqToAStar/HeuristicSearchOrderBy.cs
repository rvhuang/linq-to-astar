using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqToAStar
{
    using Core;

    public class HeuristicSearchOrderBy<TResult, TStep> : HeuristicSearchBase<TResult, TStep>, IOrderedEnumerable<TResult>
    {
        #region Fields

        private INodeComparer<TResult, TStep> _nodeComparer;

        #endregion

        #region Properties

        internal override INodeComparer<TResult, TStep> NodeComparer => _nodeComparer;

        #endregion

        #region Constructors

        internal HeuristicSearchOrderBy(HeuristicSearchBase<TResult, TStep> source, INodeComparer<TResult, TStep> nodeComparer)
            : base(source)
        {
            _nodeComparer = nodeComparer;
        }

        #endregion

        #region Overrides

        public override IEnumerator<TResult> GetEnumerator()
        {
            Debug.WriteLine($"Searching path between {From} and {To} with {AlgorithmName}...");

            switch (AlgorithmName)
            {
                case nameof(AStar):
                    return AStar.Run(this).GetEnumerator();

                case nameof(BestFirstSearch):
                    return BestFirstSearch.Run(this).GetEnumerator();

                case nameof(RecursiveBestFirstSearch):
                    return RecursiveBestFirstSearch.Run(this).GetEnumerator();

                case nameof(IterativeDeepeningAStar):
                    return IterativeDeepeningAStar.Run(this).GetEnumerator();
            }
            return base.GetEnumerator();
        }

        #endregion

        #region IOrderedEnumerable<TResult>

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, float> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, double> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, decimal> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, byte> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, sbyte> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, short> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, ushort> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, int> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, uint> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, long> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable(Func<TResult, ulong> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TResult, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable<TKey>(Func<TResult, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new NormalComparer<TResult, TKey, TStep>(keySelector, null, descending);

            _nodeComparer = new CombinedComparer<TResult, TStep>(comparer1, comparer2);

            return this;
        }

        IOrderedEnumerable<TResult> IOrderedEnumerable<TResult>.CreateOrderedEnumerable<TKey>(Func<TResult, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            return CreateOrderedEnumerable(keySelector, comparer, descending);
        }

        #endregion
    }
}