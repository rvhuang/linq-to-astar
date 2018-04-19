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

        private INodeComparer<TStep, TResult> _nodeComparer;

        #endregion

        #region Properties

        internal override INodeComparer<TStep, TResult> NodeComparer => _nodeComparer;

        #endregion

        #region Constructors

        internal HeuristicSearchOrderBy(HeuristicSearchBase<TResult, TStep> source, INodeComparer<TStep, TResult> nodeComparer)
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
                case nameof(AStar<TResult, TStep>):
                    return new AStar<TResult, TStep>(this).GetEnumerator();

                case nameof(BestFirstSearch<TResult, TStep>):
                    return new BestFirstSearch<TResult, TStep>(this).GetEnumerator();

                case nameof(RecursiveBestFirstSearch<TResult, TStep>):
                    return new RecursiveBestFirstSearch<TResult, TStep>(this).GetEnumerator();

                case nameof(IterativeDeepeningAStar<TResult, TStep>):
                    return new IterativeDeepeningAStar<TResult, TStep>(this).GetEnumerator();
            }
            return base.GetEnumerator();
        }

        #endregion

        #region IOrderedEnumerable<TResult>

        public HeuristicSearchOrderBy<TResult, TStep> CreateOrderedEnumerable<TKey>(Func<TResult, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var comparer1 = _nodeComparer;
            var comparer2 = HeuristicSearch.CreateComparer<TResult, TKey, TStep>(keySelector, comparer, descending);

            _nodeComparer = new CombinedComparer<TStep, TResult>(comparer1, comparer2);

            return this;
        }

        IOrderedEnumerable<TResult> IOrderedEnumerable<TResult>.CreateOrderedEnumerable<TKey>(Func<TResult, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            return CreateOrderedEnumerable(keySelector, comparer, descending);
        }

        #endregion
    }
}