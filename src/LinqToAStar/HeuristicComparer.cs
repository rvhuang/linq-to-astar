using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    class HeuristicComparer<TStep, TResult, TKey> : INodeComparer<TResult, TStep>
    {
        #region Fields

        private readonly Func<TResult, double> _keySelector;
        private readonly IComparer<Node<TResult, TStep>> _resultOnyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TResult, TStep>> ResultOnlyComparer => _resultOnyComparer;

        #endregion

        #region Constructor

        public HeuristicComparer(Func<TResult, TKey> keySelector, bool descending)
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            if (descending)
                _keySelector = s => 0 - Convert.ToDouble(keySelector(s));
            else
                _keySelector = s => Convert.ToDouble(keySelector(s));

            _resultOnyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        #endregion

        #region Methods

        public int Compare(Node<TResult, TStep> x, Node<TResult, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return DistanceHelper.DoubleComparer.Compare(_keySelector(x.Result) + x.Level, _keySelector(y.Result) + y.Level);
        }

        public int Compare(TResult x, TResult y)
        {
            return DistanceHelper.DoubleComparer.Compare(_keySelector(x), _keySelector(y));
        }

        #endregion

        #region Others

        private int CompareResultOnly(Node<TResult, TStep> x, Node<TResult, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return Compare(x.Result, y.Result);
        }

        #endregion
    }
}