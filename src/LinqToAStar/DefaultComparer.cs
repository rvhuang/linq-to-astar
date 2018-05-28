using System.Collections.Generic;

namespace LinqToAStar
{
    internal class DefaultComparer<TFactor, TStep> : INodeComparer<TFactor, TStep>
    {
        #region Fields

        private readonly bool _descending;
        private readonly IComparer<TFactor> _factorComparer;
        private readonly IComparer<Node<TFactor, TStep>> _factorOnlyComparer;

        #endregion

        #region Properties

        public IComparer<Node<TFactor, TStep>> FactorOnlyComparer => _factorOnlyComparer;

        #endregion

        #region Constructors

        public DefaultComparer() : this(false) { }

        public DefaultComparer(bool descending) : this(null, false) { }

        public DefaultComparer(IComparer<TFactor> factorComparer, bool descending)
        {
            _descending = descending;
            _factorComparer = factorComparer ?? Comparer<TFactor>.Default;
            _factorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        #endregion

        #region Comparisons

        public int Compare(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            var r = CompareFactorOnly(x, y);

            return r != 0 ? r : DistanceHelper.Int32Comparer.Compare(x.Level, y.Level);
        }

        public int Compare(TFactor x, TFactor y)
        {
            return _descending ? 0 - _factorComparer.Compare(x, y) : _factorComparer.Compare(x, y);
        }

        #endregion

        #region Others

        private int CompareFactorOnly(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return Compare(x.Fector, y.Fector);
        }

        #endregion
    }
}