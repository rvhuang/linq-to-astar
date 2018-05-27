using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    class NormalComparer<TFactor, TKey, TStep> : INodeComparer<TFactor, TStep>
    {
        #region Fields

        private readonly bool _descending;
        private readonly Func<TFactor, TKey> _keySelector;
        private readonly IComparer<TKey> _keyComparer;
        private readonly IComparer<Node<TFactor, TStep>> _resultOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TFactor, TStep>> ResultOnlyComparer => _resultOnlyComparer;

        #endregion

        #region Constructors

        public NormalComparer(Func<TFactor, TKey> keySelector, IComparer<TKey> keyComparer, bool descending)
        {
            _descending = descending;
            _keySelector = keySelector;
            _keyComparer = keyComparer ?? Comparer<TKey>.Default;
            _resultOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareResultOnly);
        }

        #endregion

        #region Overrides

        public int Compare(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            var r = Compare(x, y);

            return r != 0 ? r : DistanceHelper.Int32Comparer.Compare(x.Level, y.Level);
        }

        public int Compare(TFactor x, TFactor y)
        {
            var r = _keyComparer.Compare(_keySelector(x), _keySelector(y));

            return _descending ? 0 - r : r;
        }

        #endregion

        #region Others

        private int CompareResultOnly(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return Compare(x.Result, y.Result);
        }

        #endregion
    }
}