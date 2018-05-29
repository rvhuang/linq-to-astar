using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqToAStar
{
    using Core;

    public class HeuristicSearchOrderBy<TFactor, TStep> : HeuristicSearchBase<TFactor, TStep>, IOrderedEnumerable<TFactor>
    {
        #region Fields

        private INodeComparer<TFactor, TStep> _nodeComparer;

        #endregion

        #region Properties

        public override INodeComparer<TFactor, TStep> NodeComparer => _nodeComparer;

        #endregion

        #region Constructors

        internal HeuristicSearchOrderBy(HeuristicSearchBase<TFactor, TStep> source, INodeComparer<TFactor, TStep> nodeComparer)
            : base(source)
        {
            _nodeComparer = nodeComparer;
        }

        #endregion

        #region Overrides

        public override IEnumerator<TFactor> GetEnumerator()
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

        #region IOrderedEnumerable<TFactor>

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, float> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, double> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, decimal> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, byte> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, sbyte> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, short> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, ushort> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, int> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, uint> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, long> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable(Func<TFactor, ulong> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new HeuristicComparer<TFactor, TStep>(keySelector, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        internal HeuristicSearchOrderBy<TFactor, TStep> CreateOrderedEnumerable<TKey>(Func<TFactor, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = new NormalComparer<TFactor, TKey, TStep>(keySelector, null, descending);

            _nodeComparer = new CombinedComparer<TFactor, TStep>(comparer1, comparer2);

            return this;
        }

        IOrderedEnumerable<TFactor> IOrderedEnumerable<TFactor>.CreateOrderedEnumerable<TKey>(Func<TFactor, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            return CreateOrderedEnumerable(keySelector, comparer, descending);
        }

        #endregion
    }
}