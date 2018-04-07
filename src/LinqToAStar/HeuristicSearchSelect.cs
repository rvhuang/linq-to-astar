using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar
{
    internal class HeuristicSearchSelect<TSource, TResult, TStep> : HeuristicSearchBase<TResult, TStep>
    {
        #region Fields

        private readonly HeuristicSearchBase<TSource, TStep> _source; 
        private readonly Func<TSource, int, TResult> _selector;

        #endregion

        #region Properties

        public override string AlgorithmName => _source.AlgorithmName;

        internal override Func<TStep, int, IEnumerable<TResult>> Converter => Convert;

        #endregion

        #region Constructor

        public HeuristicSearchSelect(HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, TResult> selector)
            : base(source.From, source.To, source.Comparer, source.Expander)
        {
            _source = source;
            _selector = selector;
        }

        #endregion

        #region Overrides

        public override IEnumerator<TResult> GetEnumerator()
        {
            return _source.AsEnumerable().Select(_selector).GetEnumerator();
        }

        #endregion

        #region Others

        private IEnumerable<TResult> Convert(TStep step, int level)
        { 
            foreach(var r in _source.Converter(step, level))
                yield return _selector(r, level);
        }

        #endregion
    }
}