using System;
using System.Collections.Generic;

namespace Heuristic.Linq
{
    /// <summary>
    /// Defines a node that represents specific step and its corresponding level of the problem.
    /// </summary>
    /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>
    public class Node<TFactor, TStep> : INode<TStep>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the previous node of current instance.
        /// </summary>
        public Node<TFactor, TStep> Previous
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the next node of current instance.
        /// </summary>
        public Node<TFactor, TStep> Next
        {
            get; set;
        }

        /// <summary>
        /// Gets the step of current node.
        /// </summary>
        public TStep Step
        {
            get; private set;
        }

        /// <summary>
        /// Gets the corresponding level of <see cref="Step"/>.
        /// </summary>
        public int Level
        {
            get; private set;
        }

        /// <summary>
        /// Gets the factor used to evaluate with heuristic function.
        /// </summary>
        public TFactor Factor
        {
            get; private set;
        }

        INode<TStep> INode<TStep>.Previous => Previous;

        INode<TStep> INode<TStep>.Next => Next; 

        #endregion

        #region Constructor

        internal Node(TStep step, TFactor factor, int level)
        {
            Step = step;
            Factor = factor;
            Level = level;
        }

        #endregion

        #region Methods

        internal IEnumerable<Node<TFactor, TStep>> EnumerateNodes()
        {
            var node = this;

            do
            {
                yield return node;
                node = node.Next;
            }
            while (node != null);
        }

        internal IEnumerable<TFactor> EnumerateFactors()
        {
            var node = this;

            do
            {
                yield return node.Factor;
                node = node.Next;
            }
            while (node != null);
        }

        internal Node<TFactor, TStep> TraceBack()
        {
            var node = this;

            while (node.Previous != null)
            {
                node.Previous.Next = node;
                node = node.Previous;
            }
            return node;
        }

        internal IEnumerable<Node<TFactor, TStep>> EnumerateReverseNodes()
        {
            var node = this;

            yield return node;

            while (node.Previous != null)
            {
                node.Previous.Next = node;
                node = node.Previous;

                yield return node;
            }
        }

        internal IEnumerable<TFactor> EnumerateReverseFactors()
        {
            var node = this;

            yield return node.Factor;

            while (node.Previous != null)
            {
                node.Previous.Next = node;
                node = node.Previous;

                yield return node.Factor;
            }
        }

        #endregion

        #region Other
        
        /// <summary>
        /// Creates a <see cref="Node{TFactor, TStep}"/> instance from step, factor and level.
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="factor">The factor used to evaluate with heuristic function.</param>
        /// <param name="level">The corresponding level of step.</param>
        /// <returns>An instance that consists of node information.</returns>
        public static Node<TFactor, TStep> Create(TStep step, TFactor factor, int level)
        {
            if (step == null) throw new ArgumentNullException(nameof(step));
            if (level < 0) throw new ArgumentOutOfRangeException(nameof(level));

            return new Node<TFactor, TStep>(step, factor, level);
        }

        #endregion
    }
}