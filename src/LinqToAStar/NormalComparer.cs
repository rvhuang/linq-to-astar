using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    class NormalComparer<TStep, TResult, TKey> : INodeComparer<TStep, TResult>
    {
        #region Fields

        private readonly bool _descending;
        private readonly Func<TResult, TKey> _keySelector;
        private readonly IComparer<TKey> _keyComparer;
        private readonly IComparer<Node<TStep, TResult>> _resultOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TStep, TResult>> ResultOnlyComparer => _resultOnlyComparer;

        #endregion

        #region Constructors

        public NormalComparer(Func<TResult, TKey> keySelector, IComparer<TKey> keyComparer, bool descending)
        {
            _descending = descending;
            _keySelector = keySelector ?? throw new ArgumentNullException(nameof(keySelector));
            _keyComparer = keyComparer ?? Comparer<TKey>.Default;
            _resultOnlyComparer = Comparer<Node<TStep, TResult>>.Create(CompareResultOnly);
        }

        #endregion

        #region Overrides

        public int Compare(Node<TStep, TResult> x, Node<TStep, TResult> y)
        {
            var r = CompareResultOnly(x, y);

            return r != 0 ? r : DistanceHelper.Int32Comparer.Compare(x.Level, y.Level);
        }

        public int Compare(TResult x, TResult y)
        {
            return _keyComparer.Compare(_keySelector(x), _keySelector(y));
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