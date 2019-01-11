using System;
using System.Collections.Generic;

namespace Heuristic.Linq
{
    internal class DefaultComparer<TFactor, TStep> : INodeComparer<TFactor, TStep>
    {
        #region Fields

        private readonly bool _descending;
        private readonly IComparer<TFactor> _factorComparer;
        private readonly IComparer<Node<TFactor, TStep>> _factorOnlyComparer;

        #endregion

        #region Properties

        public static DefaultComparer<TFactor, TStep> Default { get; } = new DefaultComparer<TFactor, TStep>();

        public IComparer<Node<TFactor, TStep>> FactorOnlyComparer
        {
            get { return _factorOnlyComparer; }
        }

        #endregion

        #region Constructors

        public DefaultComparer() : this(false) { }

        public DefaultComparer(bool descending)
        {
            _descending = descending;
            _factorComparer = HeuristicSearchBase<TFactor, TStep>.IsFactorComparable ? Comparer<TFactor>.Default : null;
            _factorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        #endregion

        #region Comparisons

        public int Compare(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            var r = 0;

            if (_factorComparer != null)
                r = _descending ? _factorComparer.Compare(y.Factor, x.Factor) : _factorComparer.Compare(x.Factor, y.Factor);

            return r != 0 ? r : DistanceHelper.Int32Comparer.Compare(x.Level, y.Level);
        }

        public int Compare(TFactor x, TFactor y)
        {
            if (_factorComparer == null)
                throw new InvalidOperationException($"Unable to evaluate steps. The orderby clause is missing or {typeof(TFactor)} does not implement {typeof(IComparable<TFactor>)}.");

            return _descending ? _factorComparer.Compare(y, x) : _factorComparer.Compare(x, y);
        }

        #endregion

        #region Others

        private int CompareFactorOnly(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return Compare(y.Factor, x.Factor);
        }

        #endregion
    }
}