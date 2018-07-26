using System.Collections.Generic;

namespace Heuristic.Linq
{
    class CombinedComparer<TFactor, TStep> : INodeComparer<TFactor, TStep>
    {
        #region Fields

        private readonly INodeComparer<TFactor, TStep> _comparer1;
        private readonly INodeComparer<TFactor, TStep> _comparer2;
        private readonly IComparer<Node<TFactor, TStep>> _factorOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TFactor, TStep>> FactorOnlyComparer => _factorOnlyComparer;

        #endregion

        #region Constructors

        public CombinedComparer(INodeComparer<TFactor, TStep> comparer1, INodeComparer<TFactor, TStep> comparer2)
        {
            _comparer1 = comparer1;
            _comparer2 = comparer2;
            _factorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        #endregion

        #region Overrides

        public int Compare(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            var r = _comparer1.Compare(x, y);

            return r != 0 ? r : _comparer2.Compare(x, y);
        }

        public int Compare(TFactor x, TFactor y)
        {
            var r = _comparer1.Compare(x, y);

            return r != 0 ? r : _comparer2.Compare(x, y);
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