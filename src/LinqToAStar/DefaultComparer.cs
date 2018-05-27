using System.Collections.Generic;

namespace LinqToAStar
{
    internal class DefaultComparer<TFactor, TStep> : INodeComparer<TFactor, TStep>
    {
        #region Fields

        private readonly bool _descending;
        private readonly IComparer<TFactor> _resultComparer;
        private readonly IComparer<Node<TFactor, TStep>> _resultOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TFactor, TStep>> ResultOnlyComparer => _resultOnlyComparer;

        #endregion

        #region Constructors

        public DefaultComparer() : this(false) { }

        public DefaultComparer(bool descending) : this(null, false) { }

        public DefaultComparer(IComparer<TFactor> resultComparer, bool descending)
        {
            _descending = descending;
            _resultComparer = resultComparer ?? Comparer<TFactor>.Default;
            _resultOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareResultOnly);
        }

        #endregion

        #region Comparisons

        public int Compare(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            var r = CompareResultOnly(x, y);

            return r != 0 ? r : DistanceHelper.Int32Comparer.Compare(x.Level, y.Level);
        }

        public int Compare(TFactor x, TFactor y)
        {
            return _descending ? 0 - _resultComparer.Compare(x, y) : _resultComparer.Compare(x, y);
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