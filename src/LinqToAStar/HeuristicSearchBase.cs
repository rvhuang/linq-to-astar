using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar
{
    public abstract class HeuristicSearchBase<TResult, TStep> : IEnumerable<TResult>
    {
        #region Fields

        private readonly IEqualityComparer<TStep> _comparer;
        private readonly HeuristicSearchBase<TResult, TStep> _source;
        private readonly Func<TStep, int, IEnumerable<TResult>> _converter;
        private readonly Func<TStep, int, IEnumerable<TStep>> _expander;
        
        #endregion

        #region Properties

        public TStep From { get; private set; }

        public TStep To { get; private set; }
        
        public Func<TStep, int, IEnumerable<TStep>> Expander => _expander;

        public IEqualityComparer<TStep> StepComparer => _comparer;

        public virtual string AlgorithmName => _source != null ? _source.AlgorithmName : string.Empty;

        internal HeuristicSearchBase<TResult, TStep> Source => _source;

        internal virtual Func<TStep, int, IEnumerable<TResult>> Converter => _converter;

        internal virtual INodeComparer<TStep, TResult> NodeComparer => _source != null ? _source.NodeComparer : new DefaultComparer<TStep, TResult>();

        #endregion

        #region Constructors

        internal HeuristicSearchBase(HeuristicSearchBase<TResult, TStep> source)
            : this(source.From, source.To, source.StepComparer, source.Converter, source.Expander)
        {
            _source = source;
        }

        internal HeuristicSearchBase(TStep from, TStep to, IEqualityComparer<TStep> comparer,
            Func<TStep, int, IEnumerable<TStep>> expander)
            : this(from, to, comparer, null, expander)
        {
        }

        internal HeuristicSearchBase(TStep from, TStep to, IEqualityComparer<TStep> comparer,
            Func<TStep, int, IEnumerable<TResult>> converter, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            From = from;
            To = to;

            _comparer = comparer ?? EqualityComparer<TStep>.Default;
            _converter = converter;
            _expander = expander;
        }

        #endregion

        #region IEnumerable Members

        public virtual IEnumerator<TResult> GetEnumerator()
        {
            return (_source ?? Enumerable.Empty<TResult>()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Others

        internal IEnumerable<Node<TStep, TResult>> Expands(TStep step, int level)
        {
            foreach (var next in Expander(step, level))
                foreach (var n in ConvertToNodes(next, level + 1))
                    yield return n;
        }

        internal IEnumerable<Node<TStep, TResult>> Expands(TStep step, int level, Func<TStep, bool> predicate)
        {
            foreach (var next in Expander(step, level).Where(predicate))
                foreach (var n in ConvertToNodes(next, level + 1))
                    yield return n;
        }

        internal IEnumerable<Node<TStep, TResult>> ConvertToNodes(TStep step, int level)
        {
            foreach (var r in Converter(step, level))
                yield return new Node<TStep, TResult>(step, r, level);
        }

        #endregion
    }
}
