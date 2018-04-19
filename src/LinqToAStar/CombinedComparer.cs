using System.Collections.Generic;

namespace LinqToAStar
{
    class CombinedComparer<TStep, TResult> : INodeComparer<TStep, TResult>
    {
        #region Fields

        private readonly INodeComparer<TStep, TResult> _comparer1;
        private readonly INodeComparer<TStep, TResult> _comparer2;
        private readonly IComparer<Node<TStep, TResult>> _resultOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TStep, TResult>> ResultOnlyComparer => _resultOnlyComparer;

        #endregion

        #region Constructors

        public CombinedComparer(INodeComparer<TStep, TResult> comparer1, INodeComparer<TStep, TResult> comparer2)
        {
            _comparer1 = comparer1;
            _comparer2 = comparer2;
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
            var r = _comparer1.Compare(x, y);

            return r != 0 ? r : _comparer2.Compare(x, y);
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