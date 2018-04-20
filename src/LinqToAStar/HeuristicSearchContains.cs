using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    class HeuristicSearchContains<TResult, TStep> : HeuristicSearchBase<TResult, TStep>
    {
        #region Fields

        private readonly IEnumerable<TResult> _collection;
        private readonly IEqualityComparer<TResult> _comparer;

        private ISet<TResult> _set;

        #endregion

        #region Properties

        internal override Func<TStep, int, IEnumerable<TResult>> Converter => Convert;

        #endregion

        #region Constructors

        internal HeuristicSearchContains(HeuristicSearchBase<TResult, TStep> source, IEnumerable<TResult> collection, IEqualityComparer<TResult> comparer)
            : base(source)
        {
            _collection = collection;
            _comparer = comparer;
        }

        #endregion

        #region Overrides

        public override IEnumerator<TResult> GetEnumerator()
        {
            return EnumerateFromSource().GetEnumerator();
        }

        #endregion

        #region Others

        private IEnumerable<TResult> EnumerateFromSource()
        {
            if (_set == null)
                _set = new HashSet<TResult>(_collection, _comparer);

            foreach (var r in Source)
                if (_set.Contains(r))
                    yield return r;
        }

        private IEnumerable<TResult> Convert(TStep step, int level)
        {
            if (_set == null)
                _set = new HashSet<TResult>(_collection, _comparer);

            foreach (var r in Source.Converter(step, level))
                if (_set.Contains(r))
                    yield return r;
        }

        #endregion
    }
}