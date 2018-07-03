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
        private readonly IComparer<Node<TFactor, TStep>> _factorOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TFactor, TStep>> FactorOnlyComparer => _factorOnlyComparer;

        #endregion

        #region Constructors

        public NormalComparer(Func<TFactor, TKey> keySelector, IComparer<TKey> keyComparer, bool descending)
        {
            _descending = descending;
            _keySelector = keySelector;
            _keyComparer = keyComparer ?? Comparer<TKey>.Default;
            _factorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
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
            return _descending ?
                _keyComparer.Compare(_keySelector(y), _keySelector(x)) :
                _keyComparer.Compare(_keySelector(x), _keySelector(y));
        }

        #endregion

        #region Others

        private int CompareFactorOnly(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return Compare(x.Factor, y.Factor);
        }

        #endregion
    }
}