using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Heuristic.Linq
{
    /// <summary>
    /// Defines the instance that allows LINQ expressions to be applied to heuristic algorithms.
    /// </summary>
    /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>
    public abstract class HeuristicSearchBase<TFactor, TStep> : IEnumerable<TFactor>
    {
        #region Fields

        internal static readonly bool IsFactorComparable = typeof(IComparable<TFactor>).IsAssignableFrom(typeof(TFactor));

        private readonly string _algorithmName;
        private readonly IEqualityComparer<TStep> _ec;
        private readonly INodeComparer<TFactor, TStep> _nc;
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
        public IEqualityComparer<TStep> StepComparer => _ec;

        /// <summary>
        /// Gets the algorithm name.
        /// </summary>
        public string AlgorithmName => _algorithmName;

        /// <summary>
        /// Gets the comparer used to compare two <see cref="Node{TFactor, TStep}"/> instances.
        /// </summary>
        public INodeComparer<TFactor, TStep> NodeComparer => _nc;

        internal bool IsReversed { get; set; }

        internal Func<TStep, int, IEnumerable<TStep>> Expander => _expander;

        internal HeuristicSearchBase<TFactor, TStep> Source => _source;

        internal virtual Func<TStep, int, IEnumerable<TFactor>> Converter => _converter;

        #endregion

        #region Constructors

        internal HeuristicSearchBase(HeuristicSearchBase<TFactor, TStep> source)
            : this(source.AlgorithmName, source.From, source.To, source.StepComparer, source.NodeComparer, source.Converter, source.Expander)
        {
            _source = source;

            IsReversed = source.IsReversed;
        } 

        internal HeuristicSearchBase(string algorithmName, TStep from, TStep to, IEqualityComparer<TStep> ec, INodeComparer<TFactor, TStep> nc,
            Func<TStep, int, IEnumerable<TFactor>> converter, Func<TStep, int, IEnumerable<TStep>> expander)
        {
            From = from;
            To = to;

            _algorithmName = algorithmName;
            _ec = ec ?? EqualityComparer<TStep>.Default;
            _nc = nc != null ? nc : (IsFactorComparable ? new DefaultComparer<TFactor, TStep>() : null);
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
            var lastNode = this.Run();

            if (lastNode == null) // Solution not found
                return Enumerable.Empty<TFactor>().GetEnumerator();

            if (IsReversed)
                return lastNode.EnumerateReverseFactors().GetEnumerator();
            else
                return lastNode.TraceBack().EnumerateFactors().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates an array that consists of the solution found by the algorithm.
        /// </summary>
        /// <returns>An array that consists of the solution found by the algorithm.</returns>
        public virtual TFactor[] ToArray()
        {
            var lastNode = this.Run();

            if (lastNode == null) // Solution not found
                return Array.Empty<TFactor>();

            var array = new TFactor[lastNode.Level + 1];

            if (IsReversed)
            {
                foreach (var node in lastNode.EnumerateReverseNodes())
                {
                    array[lastNode.Level - node.Level] = node.Factor;
                }
            }
            else
            {
                foreach (var node in lastNode.TraceBack().EnumerateNodes())
                {
                    array[node.Level] = node.Factor;
                }
            }
            return array;
        }

        /// <summary>
        /// Creates a <see cref="List{T}"/> instance that consists of the solution found by the algorithm.
        /// </summary>
        /// <returns>An <see cref="List{T}"/> instance that consists of the solution found by the algorithm.</returns>
        public virtual List<TFactor> ToList()
        {
            return new List<TFactor>(ToArray());
        }

        // Consider exposing this method in future.
        internal TOutput[] ToArray<TOutput>(Func<TFactor, int, TOutput> converter)
        {
            var lastNode = this.Run();

            if (lastNode == null) // Solution not found
                return Array.Empty<TOutput>();

            var array = new TOutput[lastNode.Level + 1];

            if (IsReversed)
            {
                foreach (var node in lastNode.EnumerateReverseNodes())
                {
                    array[lastNode.Level - node.Level] = converter(node.Factor, node.Level);
                }
            }
            else
            {
                foreach (var node in lastNode.TraceBack().EnumerateNodes())
                {
                    array[node.Level] = converter(node.Factor, node.Level);
                }
            }
            return array;
        }

        // Consider exposing this method in future.
        internal List<TOutput> ToList<TOutput>(Func<TFactor, int, TOutput> converter)
        {
            return new List<TOutput>(ToArray(converter));
        }

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