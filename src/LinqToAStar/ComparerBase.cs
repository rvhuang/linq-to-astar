using System.Collections.Generic;

namespace LinqToAStar
{
    internal abstract class ComparerBase<TStep, TResult> : IComparer<Node<TStep, TResult>>, IComparer<TResult>
    {
        #region Fields

        private readonly bool _descending;
        private readonly IComparer<Node<TStep, TResult>> _resultComparer;

        #endregion

        #region Properties

        public IComparer<Node<TStep, TResult>> ResultComparer => _resultComparer;

        #endregion

        #region Constructors

        public ComparerBase(bool descending)
        {
            _descending = descending;
            _resultComparer = Comparer<Node<TStep, TResult>>.Create(CompareResultOnly);
        }

        #endregion

        #region Comparisons

        public int Compare(Node<TStep, TResult> x, Node<TStep, TResult> y)
        {
            if (x == null) return y == null ? 0 : (_descending ? -1 : 1);
            if (y == null) return x == null ? 0 : (_descending ? 1 :-1);

            return _descending ? 0 - OnCompare(x, y) : OnCompare(x, y);
        }

        public int Compare(TResult x, TResult y)
        {
            return _descending ? 0 - OnCompare(x, y) : OnCompare(x, y);
        }

        public int CompareResultOnly(Node<TStep, TResult> x, Node<TStep, TResult> y)
        {
            if (x == null) return y == null ? 0 : (_descending ? -1 : 1);
            if (y == null) return x == null ? 0 : (_descending ? 1 :-1);

            return Compare(x.Result, y.Result);
        }

        #endregion

        #region To be implemented

        protected abstract int OnCompare(Node<TStep, TResult> x, Node<TStep, TResult> y);

        protected virtual int OnCompare(TResult x, TResult y)
        {
            return Comparer<TResult>.Default.Compare(x, y);
        }
        
        #endregion
    }
}