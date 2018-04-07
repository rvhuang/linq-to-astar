using System.Collections.Generic;

namespace LinqToAStar
{
    internal abstract class ComparerBase<T> : IComparer<T>
    {
        private readonly bool _descending;

        public ComparerBase(bool descending)
        {
            _descending = descending;
        }

        public int Compare(T x, T y)
        {
            return _descending ? 0 - OnCompare(x, y) : OnCompare(x, y);
        }

        protected abstract int OnCompare(T x, T y);
    }
}