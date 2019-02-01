using System;
using System.Collections.Generic;

namespace Heuristic.Linq.Algorithms
{
    /// <summary>
    /// Represents the state of an algorithm.
    /// </summary>
    /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>
    public struct AlgorithmState<TFactor, TStep> : IAlgorithmState<TStep>
    {
        /// <summary>
        /// Gets the default instance that represents the status where solution is not found. 
        /// </summary>
        public static readonly AlgorithmState<TFactor, TStep> NotFound = new AlgorithmState<TFactor, TStep>(AlgorithmFlag.NotFound, null);

        /// <summary>
        /// Gets the flag that represents current status.
        /// </summary>
        public AlgorithmFlag Flag
        {
            get; private set;
        }

        /// <summary>
        /// Gets the current node where the progress is at.
        /// </summary>
        public Node<TFactor, TStep> Node
        {
            get; private set;
        }

        /// <summary>
        /// Gets the collection of <see cref="Node{TFactor, TStep}"/> instances that will possibly be visited in future.
        /// </summary>
        public IReadOnlyCollection<Node<TFactor, TStep>> Candidates
        {
            get; private set;
        }

        INode<TStep> IAlgorithmState<TStep>.Node => Node;

        IReadOnlyCollection<INode<TStep>> IAlgorithmState<TStep>.Candidates => Candidates;

        /// <summary>
        /// Creates an instance of the structure.
        /// </summary>
        /// <param name="flag">The flag that represents current status.</param>
        /// <param name="node">The current node where the progress is at.</param>
        public AlgorithmState(AlgorithmFlag flag, Node<TFactor, TStep> node)
        {
            Flag = flag;
            Node = node;
            Candidates = Array.Empty<Node<TFactor, TStep>>();
        }

        /// <summary>
        /// Creates an instance of the structure.
        /// </summary>
        /// <param name="flag">The flag that represents current status.</param>
        /// <param name="node">The current node where the progress is at.</param>
        /// <param name="candidates">The collection of <see cref="Node{TFactor, TStep}"/> instances that will possibly be visited in future.</param>
        public AlgorithmState(AlgorithmFlag flag, Node<TFactor, TStep> node, IReadOnlyCollection<Node<TFactor, TStep>> candidates)
        {
            Flag = flag;
            Node = node;
            Candidates = candidates ?? Array.Empty<Node<TFactor, TStep>>();
        }
    }

    /// <summary>
    /// Represets the status of the solution.
    /// </summary>
    public enum AlgorithmFlag
    {
        /// <summary>
        /// Represents the status where solution is not found. 
        /// </summary>
        /// <remarks>
        /// This will only occur once observed by <see cref="IProgress{T}"/> instances.
        /// </remarks>
        NotFound,

        /// <summary>
        /// Represents the status where the solution is still in progress. 
        /// </summary>
        InProgress,

        /// <summary>
        /// Represents the status where the algorithm has found the solution.
        /// </summary>
        /// <remarks>
        /// This will only occur once observed by <see cref="IProgress{T}"/> instances.
        /// </remarks>
        Found,
    }
}