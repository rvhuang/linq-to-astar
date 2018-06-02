using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqToAStar
{
    using Core;

    public abstract class HeuristicSearchBase<TFactor, TStep> : IEnumerable<TFactor>
    {
        #region Fields

        internal static readonly bool IsFactorComparable = typeof(IComparable<TFactor>).IsAssignableFrom(typeof(TFactor));

        private readonly IEqualityComparer<TStep> _comparer;
        private readonly HeuristicSearchBase<TFactor, TStep> _source;
        private readonly Func<TStep, int, IEnumerable<TFactor>> _converter;
        private readonly Func<TStep, int, IEnumerable<TStep>> _expander;
        
        #endregion

        #region Properties

        public TStep From { get; private set; }

        public TStep To { get; private set; }
        
        public IEqualityComparer<TStep> StepComparer => _comparer;

        public virtual string AlgorithmName => _source != null ? _source.AlgorithmName : string.Empty;

        public virtual INodeComparer<TFactor, TStep> NodeComparer => _source != null ? _source.NodeComparer : new DefaultComparer<TFactor, TStep>();

        internal bool IsReversed { get; set; }

        internal Func<TStep, int, IEnumerable<TStep>> Expander => _expander;

        internal HeuristicSearchBase<TFactor, TStep> Source => _source;

        internal virtual Func<TStep, int, IEnumerable<TFactor>> Converter => _converter;
        
        #endregion

        #region Constructors

        internal HeuristicSearchBase(HeuristicSearchBase<TFactor, TStep> source)
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
            Func<TStep, int, IEnumerable<TFactor>> converter, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            From = from;
            To = to;

            _comparer = comparer ?? EqualityComparer<TStep>.Default;
            _converter = converter;
            _expander = expander;
        }

        #endregion

        #region IEnumerable Members 

        public virtual IEnumerator<TFactor> GetEnumerator()
        {
            Debug.WriteLine($"Searching path between {From} and {To} with {AlgorithmName}...");

            var lastNode = default(Node<TFactor, TStep>);

            switch (AlgorithmName)
            {
                case nameof(AStar):
                    lastNode = AStar.Run(this);
                    break;

                case nameof(BestFirstSearch):
                    lastNode = BestFirstSearch.Run(this); 
                    break;

                case nameof(IterativeDeepeningAStar):
                    lastNode = IterativeDeepeningAStar.Run(this);
                    break;

                case nameof(RecursiveBestFirstSearch):
                    lastNode = RecursiveBestFirstSearch.Run(this);
                    break;

                default:
                    lastNode = HeuristicSearch.RegisteredAlgorithms[AlgorithmName](AlgorithmName).Run(this);
                    break;
            }
            if (lastNode == null) // Solution not found
                return Enumerable.Empty<TFactor>().GetEnumerator();

            if (IsReversed)
                return lastNode.EnumerateReverseFactors().GetEnumerator();
            else
                return lastNode.TraceBack().EnumerateFactors().GetEnumerator();
        } 

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region Others

        public IEnumerable<Node<TFactor, TStep>> Expands(TStep step, int level)
        {
            foreach (var next in Expander(step, level))
                foreach (var n in ConvertToNodes(next, level + 1))
                    yield return n;
        }

        public IEnumerable<Node<TFactor, TStep>> Expands(TStep step, int level, Func<TStep, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            foreach (var next in Expander(step, level))
                if (predicate(next))
                    foreach (var n in ConvertToNodes(next, level + 1))
                        yield return n;
        }

        public IEnumerable<Node<TFactor, TStep>> ConvertToNodes(TStep step, int level)
        {
            foreach (var r in Converter(step, level))
                yield return new Node<TFactor, TStep>(step, r, level);
        }

        #endregion
    }
}
