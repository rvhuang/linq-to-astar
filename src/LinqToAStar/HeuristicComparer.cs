using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    class HeuristicComparer<TStep, TResult, TKey> : INodeComparer<TStep, TResult>
    {
        #region Fields

        private readonly Func<TResult, double> _keySelector;
        private readonly IComparer<Node<TStep, TResult>> _resultOnyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TStep, TResult>> ResultOnlyComparer => _resultOnyComparer;

        #endregion

        #region Constructor

        public HeuristicComparer(Func<TResult, TKey> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            if (descending)
                _keySelector = s => 0 - Convert.ToDouble(keySelector(s));
            else
                _keySelector = s => Convert.ToDouble(keySelector(s));

            _resultOnyComparer = Comparer<Node<TStep, TResult>>.Create(CompareResultOnly);
        }

        #endregion

        #region Methods

        public int Compare(Node<TStep, TResult> x, Node<TStep, TResult> y)
        {
            return DistanceHelper.DoubleComparer.Compare(_keySelector(x.Result) + x.Level, _keySelector(y.Result) + y.Level);
        }

        public int Compare(TResult x, TResult y)
        {
            return DistanceHelper.DoubleComparer.Compare(_keySelector(x), _keySelector(y));
        }

        #endregion

        #region Others

        private int CompareResultOnly(Node<TStep, TResult> x, Node<TStep, TResult> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return Compare(x.Result, y.Result);
        }

        #endregion
    }
}