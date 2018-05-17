using System.Collections.Generic;

namespace LinqToAStar
{
    internal class DefaultComparer<TResult, TStep> : INodeComparer<TResult, TStep>
    {
        #region Fields

        private readonly bool _descending;
        private readonly IComparer<TResult> _resultComparer;
        private readonly IComparer<Node<TResult, TStep>> _resultOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TResult, TStep>> ResultOnlyComparer => _resultOnlyComparer;

        #endregion

        #region Constructors

        public DefaultComparer() : this(false) { }

        public DefaultComparer(bool descending) : this(null, false) { }

        public DefaultComparer(IComparer<TResult> resultComparer, bool descending)
        {
            _descending = descending;
            _resultComparer = resultComparer ?? Comparer<TResult>.Default;
            _resultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        #endregion

        #region Comparisons

        public int Compare(Node<TResult, TStep> x, Node<TResult, TStep> y)
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

        private int CompareResultOnly(Node<TResult, TStep> x, Node<TResult, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return Compare(x.Result, y.Result);
        }

        #endregion
    }
}