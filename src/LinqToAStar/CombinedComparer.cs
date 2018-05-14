using System.Collections.Generic;

namespace LinqToAStar
{
    class CombinedComparer<TResult, TStep> : INodeComparer<TResult, TStep>
    {
        #region Fields

        private readonly INodeComparer<TResult, TStep> _comparer1;
        private readonly INodeComparer<TResult, TStep> _comparer2;
        private readonly IComparer<Node<TResult, TStep>> _resultOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TResult, TStep>> ResultOnlyComparer => _resultOnlyComparer;

        #endregion

        #region Constructors

        public CombinedComparer(INodeComparer<TResult, TStep> comparer1, INodeComparer<TResult, TStep> comparer2)
        {
            _comparer1 = comparer1;
            _comparer2 = comparer2;
            _resultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        #endregion

        #region Overrides

        public int Compare(Node<TResult, TStep> x, Node<TResult, TStep> y)
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

        private int CompareResultOnly(Node<TResult, TStep> x, Node<TResult, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return Compare(x.Result, y.Result);
        }

        #endregion
    }
}