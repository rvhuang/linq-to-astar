using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar
{
    internal class HeuristicSearchSelect<TSource, TFactor, TStep> : HeuristicSearchBase<TFactor, TStep>
    {
        #region Fields

        private readonly HeuristicSearchBase<TSource, TStep> _source;
        private readonly Func<TSource, int, TFactor> _selector;

        #endregion

        #region Properties

        public override string AlgorithmName => _source.AlgorithmName;

        internal override Func<TStep, int, IEnumerable<TFactor>> Converter => Convert;

        #endregion

        #region Constructor

        public HeuristicSearchSelect(HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, TFactor> selector)
            : base(source.From, source.To, source.StepComparer, source.Expander)
        {
            _source = source;
            _selector = selector;
        }

        #endregion

        #region Overrides

        public override IEnumerator<TFactor> GetEnumerator()
        {
            return _source.AsEnumerable().Select(_selector).GetEnumerator();
        }

        #endregion

        #region Others

        private IEnumerable<TFactor> Convert(TStep step, int level)
        {
            foreach (var r in _source.Converter(step, level))
                yield return _selector(r, level);
        }

        #endregion
    }
}