using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    class NormalComparer<TResult, TKey, TStep> : INodeComparer<TResult, TStep>
    {
        #region Fields

        private readonly bool _descending;
        private readonly Func<TResult, TKey> _keySelector;
        private readonly IComparer<TKey> _keyComparer;
        private readonly IComparer<Node<TResult, TStep>> _resultOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TResult, TStep>> ResultOnlyComparer => _resultOnlyComparer;

        #endregion

        #region Constructors

        public NormalComparer(Func<TResult, TKey> keySelector, IComparer<TKey> keyComparer, bool descending)
        {
            _descending = descending;
            _keySelector = keySelector;
            _keyComparer = keyComparer ?? Comparer<TKey>.Default;
            _resultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        #endregion

        #region Overrides

        public int Compare(Node<TResult, TStep> x, Node<TResult, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            var r = Compare(x, y);

            return r != 0 ? r : DistanceHelper.Int32Comparer.Compare(x.Level, y.Level);
        }

        public int Compare(TResult x, TResult y)
        {
            var r = _keyComparer.Compare(_keySelector(x), _keySelector(y));

            return _descending ? 0 - r : r;
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