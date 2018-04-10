using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    class NormalComparer<TStep, TResult, TKey> : ComparerBase<TStep, TResult>
    {
        #region Fields

        private readonly Func<TResult, TKey> _keySelector;
        private readonly IComparer<TKey> _keyComparer;

        #endregion

        #region Constructors

        public NormalComparer(Func<TResult, TKey> keySelector, IComparer<TKey> comparer, bool descending)
            : base(descending)
        {
            _keySelector = keySelector ?? throw new ArgumentNullException(nameof(keySelector));
            _keyComparer = comparer ?? Comparer<TKey>.Default;
        }

        #endregion

        #region Overrides

        protected override int OnCompare(Node<TStep, TResult> x, Node<TStep, TResult> y)
        {
            var result = _keyComparer.Compare(_keySelector(x.Result), _keySelector(y.Result));

            if (result != 0)
                return result;

            return DistanceHelper.Int32Comparer.Compare(x.Level, y.Level);
        }

        protected override int OnCompare(TResult x, TResult y)
        {
            return _keyComparer.Compare(_keySelector(x), _keySelector(y));
        }
        
        #endregion
    }
}