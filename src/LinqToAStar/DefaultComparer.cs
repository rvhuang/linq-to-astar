using System.Collections.Generic;

namespace LinqToAStar
{
    internal class DefaultComparer<TStep, TResult> : INodeComparer<TStep, TResult>
    {
        #region Fields

        private readonly bool _descending;
        private readonly IComparer<TResult> _resultComparer;
        private readonly IComparer<Node<TStep, TResult>> _resultOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TStep, TResult>> ResultOnlyComparer => _resultOnlyComparer;

        #endregion

        #region Constructors

        public DefaultComparer() : this(false) { }

        public DefaultComparer(bool descending) : this(null, false) { }

        public DefaultComparer(IComparer<TResult> resultComparer, bool descending)
        {
            _descending = descending;
            _resultComparer = resultComparer ?? Comparer<TResult>.Default;
            _resultOnlyComparer = Comparer<Node<TStep, TResult>>.Create(CompareResultOnly);
        }

        #endregion

        #region Comparisons

        public int Compare(Node<TStep, TResult> x, Node<TStep, TResult> y)
        {
            var r = CompareResultOnly(x, y);

            return r != 0 ? r : DistanceHelper.Int32Comparer.Compare(x.Level, y.Level);
        }

        public int Compare(TResult x, TResult y)
        {
            return _descending ? 0 - _resultComparer.Compare(x, y) : _resultComparer.Compare(x, y);
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