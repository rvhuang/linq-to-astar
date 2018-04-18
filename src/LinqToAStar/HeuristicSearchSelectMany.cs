using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar
{
    internal class HeuristicSearchSelectMany<TSource, TCollection, TResult, TStep> : HeuristicSearchBase<TResult, TStep>
    {
        #region Fields

        private readonly HeuristicSearchBase<TSource, TStep> _source;
        private readonly Func<TSource, int, IEnumerable<TCollection>> _collectionSelector;
        private readonly Func<TSource, TCollection, TResult> _resultSelector;

        #endregion

        #region Properties

        public override string AlgorithmName => _source.AlgorithmName;

        internal override Func<TStep, int, IEnumerable<TResult>> Converter => Convert;

        #endregion

        #region Constructors

        internal HeuristicSearchSelectMany(HeuristicSearchBase<TSource, TStep> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
            : base(source.From, source.To, source.StepComparer, source.Expander)
        {
            _source = source;
            _collectionSelector = collectionSelector;
            _resultSelector = resultSelector;
        }

        #endregion

        #region Overrides

        public override IEnumerator<TResult> GetEnumerator()
        {
            return _source.AsEnumerable().SelectMany(_collectionSelector, _resultSelector).GetEnumerator();
        }

        #endregion

        #region Others

        private IEnumerable<TResult> Convert(TStep step, int level)
        {
            foreach (var s in _source.Converter(step, level))
                foreach (var c in _collectionSelector(s, level))
                    yield return _resultSelector(s, c);
        }

        #endregion
    }

    internal class HeuristicSearchSelectMany<TSource, TResult, TStep> : HeuristicSearchBase<TResult, TStep>
    {
        #region Fields

        private readonly HeuristicSearchBase<TSource, TStep> _source;
        private readonly Func<TSource, int, IEnumerable<TResult>> _selector;

        #endregion

        #region Properties

        public override string AlgorithmName => _source.AlgorithmName;

        internal override Func<TStep, int, IEnumerable<TResult>> Converter => Convert;

        #endregion

        #region Constructors

        internal HeuristicSearchSelectMany(HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, IEnumerable<TResult>> selector)
            : base(source.From, source.To, source.StepComparer, source.Expander)
        {
            _source = source;
            _selector = selector;
        }

        #endregion

        #region Overrides

        public override IEnumerator<TResult> GetEnumerator()
        {
            return _source.AsEnumerable().SelectMany(_selector).GetEnumerator();
        }

        #endregion

        #region Others

        private IEnumerable<TResult> Convert(TStep step, int level)
        {
            foreach (var s in _source.Converter(step, level))
                foreach (var r in _selector(s, level))
                    yield return r;
        }

        #endregion
    }
}