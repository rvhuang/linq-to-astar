using System;
using System.Collections.Generic;
using System.Linq;

namespace Heuristic.Linq
{
    internal class HeuristicSearchSelect<TSource, TFactor, TStep> : HeuristicSearchBase<TFactor, TStep>
    {
        #region Fields

        private readonly HeuristicSearchBase<TSource, TStep> _source;
        private readonly Func<TSource, int, TFactor> _selector;

        #endregion

        #region Properties
         
        internal override Func<TStep, int, IEnumerable<TFactor>> Converter => Convert;

        #endregion

        #region Constructor

        public HeuristicSearchSelect(HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, TFactor> selector)
            : base(source.AlgorithmName, source.From, source.To, source.StepComparer, null, null, source.Expander)
        {
            _source = source;
            _selector = selector;

            IsReversed = source.IsReversed;
            AlgorithmObserverFactory = source.AlgorithmObserverFactory;
        }

        #endregion

        #region Others

        private IEnumerable<TFactor> Convert(TStep step, int level)
        {
            foreach (var r in _source.Converter(step, level))
                yield return _selector(r, level);
        }

        #endregion

        #region Override

        public sealed override IEnumerator<TFactor> GetEnumerator()
        {
            return _source.AsEnumerable().Select(_selector).GetEnumerator();
        }

        public sealed override TFactor[] ToArray()
        {
            return _source.ToArray(_selector);
        }

        public sealed override List<TFactor> ToList()
        {
            return _source.ToList(_selector);
        }

        public override string ToString()
        {
            return string.Join(" -> ", _source.ToString(), base.ToString());
        }

        #endregion
    }
}