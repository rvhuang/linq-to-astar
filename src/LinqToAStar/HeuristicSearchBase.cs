using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqToAStar
{
    using Core;

    /// <summary>
    /// Defines the instance that allows LINQ expressions to be applied to heuristic algorithms.
    /// </summary>
    /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>
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

        /// <summary>
        /// Gets the initial state of the problem.
        /// </summary>
        public TStep From { get; private set; }

        /// <summary>
        /// Gets the goal state of the problem.
        /// </summary>
        public TStep To { get; private set; }

        /// <summary>
        /// Gets the comparer used to test if two <typeparamref name="TStep"/> instances are equal.
        /// </summary>
        public IEqualityComparer<TStep> StepComparer => _comparer;

        /// <summary>
        /// Gets the algorithm name.
        /// </summary>
        public virtual string AlgorithmName => _source != null ? _source.AlgorithmName : string.Empty;

        /// <summary>
        /// Gets the comparer used to compare two <see cref="Node{TFactor, TStep}"/> instances.
        /// </summary>
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
            _expander = expander ?? throw new ArgumentNullException(nameof(expander));
        }

        #endregion

        #region IEnumerable Members 

        /// <summary>
        /// Enumerates each step of the solution found by the algorithm.
        /// </summary>
        /// <returns>Each step of the solution.</returns>
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

        /// <summary>
        /// Gets available nodes from specific step. 
        /// </summary>
        /// <param name="step">The specific step.</param>
        /// <param name="level">The corresponding level of <paramref name="step"/>.</param>
        /// <returns>Available nodes from specific step.</returns>
        public IEnumerable<Node<TFactor, TStep>> Expands(TStep step, int level)
        {
            foreach (var next in Expander(step, level))
                foreach (var n in ConvertToNodes(next, level + 1))
                    yield return n;
        }

        /// <summary>
        /// Gets available nodes from specific step. 
        /// </summary>
        /// <param name="step">The specific step.</param>
        /// <param name="level">The corresponding level of <paramref name="step"/>.</param>
        /// <param name="predicate">A callback that </param>
        /// <returns>A function to test each step for a condition.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> is null.</exception>
        public IEnumerable<Node<TFactor, TStep>> Expands(TStep step, int level, Func<TStep, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            foreach (var next in Expander(step, level))
                if (predicate(next))
                    foreach (var n in ConvertToNodes(next, level + 1))
                        yield return n;
        }

        /// <summary>
        /// Converts specific step to one or more nodes.
        /// </summary>
        /// <param name="step">The specific step.</param>
        /// <param name="level">The corresponding level of <paramref name="step"/>.</param>
        /// <returns>Corresponding nodes of specific step.</returns>
        public IEnumerable<Node<TFactor, TStep>> ConvertToNodes(TStep step, int level)
        {
            foreach (var r in Converter(step, level))
                yield return new Node<TFactor, TStep>(step, r, level);
        }

        #endregion
    }
}