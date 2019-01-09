using System;
using System.Collections.Generic;
using System.Linq;

namespace Heuristic.Linq
{
    internal class HeuristicSearchSelectMany<TSource, TCollection, TFactor, TStep> : HeuristicSearchBase<TFactor, TStep>
    {
        #region Fields

        private readonly HeuristicSearchBase<TSource, TStep> _source;
        private readonly Func<TSource, int, IEnumerable<TCollection>> _collectionSelector;
        private readonly Func<TSource, TCollection, TFactor> _factorSelector;

        #endregion

        #region Properties

        internal override Func<TStep, int, IEnumerable<TFactor>> Converter => Convert;

        #endregion

        #region Constructors

        internal HeuristicSearchSelectMany(HeuristicSearchBase<TSource, TStep> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TFactor> factorSelector)
            : base(source.AlgorithmName, source.From, source.To, source.StepComparer, null, null, source.Expander)
        {
            _source = source;
            _collectionSelector = collectionSelector;
            _factorSelector = factorSelector;

            IsReversed = source.IsReversed;
            AlgorithmObserverFactory = source.AlgorithmObserverFactory;
        }

        #endregion

        #region Others

        private IEnumerable<TFactor> Convert(TStep step, int level)
        {
            foreach (var s in _source.Converter(step, level))
                foreach (var c in _collectionSelector(s, level))
                    yield return _factorSelector(s, c);
        }

        #endregion

        #region Override

        public sealed override IEnumerator<TFactor> GetEnumerator()
        {
            // TODO: Optimize this.
            return _source.AsEnumerable().SelectMany(_collectionSelector, _factorSelector).GetEnumerator();
        }

        public sealed override TFactor[] ToArray()
        {
            // TODO: Optimize this.
            return _source.AsEnumerable().SelectMany(_collectionSelector, _factorSelector).ToArray();
        }

        public sealed override List<TFactor> ToList()
        {
            // TODO: Optimize this.
            return _source.AsEnumerable().SelectMany(_collectionSelector, _factorSelector).ToList();
        }

        public override string ToString()
        {
            return string.Join(" -> ", _source.ToString(), base.ToString());
        }

        #endregion
    }

    internal class HeuristicSearchSelectMany<TSource, TFactor, TStep> : HeuristicSearchBase<TFactor, TStep>
    {
        #region Fields

        private readonly HeuristicSearchBase<TSource, TStep> _source;
        private readonly Func<TSource, int, IEnumerable<TFactor>> _selector;

        #endregion

        #region Properties

        internal override Func<TStep, int, IEnumerable<TFactor>> Converter => Convert;

        #endregion

        #region Constructors

        internal HeuristicSearchSelectMany(HeuristicSearchBase<TSource, TStep> source, Func<TSource, int, IEnumerable<TFactor>> selector)
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
            foreach (var s in _source.Converter(step, level))
                foreach (var r in _selector(s, level))
                    yield return r;
        }

        #endregion

        #region Override

        public sealed override IEnumerator<TFactor> GetEnumerator()
        {
            // TODO: Optimize this.
            return _source.AsEnumerable().SelectMany(_selector).GetEnumerator();
        }

        public sealed override TFactor[] ToArray()
        {
            // TODO: Optimize this.
            return _source.AsEnumerable().SelectMany(_selector).ToArray();
        }

        public sealed override List<TFactor> ToList()
        {
            // TODO: Optimize this.
            return _source.AsEnumerable().SelectMany(_selector).ToList();
        }

        public override string ToString()
        {
            return string.Join(" -> ", _source.ToString(), base.ToString());
        }

        #endregion
    }
}