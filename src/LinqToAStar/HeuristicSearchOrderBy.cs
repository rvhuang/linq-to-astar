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

            var lastNode = default(Node<TFactor, TStep>);

            switch (AlgorithmName)
            {
                case nameof(AStar):
                    lastNode = AStar.Run(this);
                    break;

                case nameof(BestFirstSearch):
                    lastNode = BestFirstSearch.Run(this);
                    break;

                case nameof(IterativeDeepeningAStar):
                    lastNode = IterativeDeepeningAStar.Run(this);
                    break;

                case nameof(RecursiveBestFirstSearch):
                    lastNode = RecursiveBestFirstSearch.Run(this);
                    break;

                default:
                    lastNode = HeuristicSearch.RegisteredAlgorithms[AlgorithmName](AlgorithmName).Run(this);
                    break;
            }
            if (lastNode == null) // Solution not found
                return Enumerable.Empty<TFactor>().GetEnumerator();

            if (IsReversed)
                return lastNode.EnumerateReverseFactors().GetEnumerator();
            else
                return lastNode.TraceBack().EnumerateFactors().GetEnumerator();
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