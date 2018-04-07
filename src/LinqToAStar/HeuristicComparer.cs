using System;

namespace LinqToAStar
{
    class HeuristicComparer<TStep, TResult, TKey> : ComparerBase<Node<TStep, TResult>>
    {
        private readonly Func<TResult, double> _keySelector;

        public HeuristicComparer(Func<TResult, TKey> keySelector, bool descending)
            : base(descending)
        {
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            _keySelector = s => Convert.ToDouble(keySelector(s));
        }

        protected override int OnCompare(Node<TStep, TResult> x, Node<TStep, TResult> y)
        {
            return DistanceHelper.DoubleComparer.Compare(_keySelector(x.Result) + x.Level, _keySelector(y.Result) + y.Level);
        }
    }
}