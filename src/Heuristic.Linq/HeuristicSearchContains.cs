using System;
using System.Collections.Generic;

namespace Heuristic.Linq
{
    class HeuristicSearchContains<TFactor, TStep> : HeuristicSearchBase<TFactor, TStep>
    {
        #region Fields

        private readonly IEnumerable<TFactor> _collection;
        private readonly IEqualityComparer<TFactor> _comparer;

        private ISet<TFactor> _set;

        #endregion

        #region Properties

        internal override Func<TStep, int, IEnumerable<TFactor>> Converter => Convert;

        #endregion

        #region Constructors

        internal HeuristicSearchContains(HeuristicSearchBase<TFactor, TStep> source, IEnumerable<TFactor> collection, IEqualityComparer<TFactor> comparer)
            : base(source)
        {
            _collection = collection;
            _comparer = comparer;
        }

        #endregion

        #region Overrides

        private IEnumerable<TFactor> Convert(TStep step, int level)
        {
            if (_set == null)
                _set = new HashSet<TFactor>(_collection, _comparer);

            foreach (var r in Source.Converter(step, level))
                if (_set.Contains(r))
                    yield return r;
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return string.Join(" -> ", Source == null ? "(Initial)" : Source.ToString(), base.ToString());
        }

        #endregion
    }
}