using System.Collections.Generic;

namespace Heuristic.Linq.Algorithms
{
    /// <summary>
    /// Represents the state of an algorithm from an abstract view.
    /// </summary>
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>
    public interface IAlgorithmState<out TStep>
    {
        /// <summary>
        /// Gets the flag that represents current status.
        /// </summary>
        AlgorithmFlag Flag { get; }

        /// <summary>
        /// Gets the current node where the progress is at.
        /// </summary>
        INode<TStep> Node { get; }
         
        /// <summary>
        /// Gets the collection of <see cref="INode{TStep}"/> instances that will possibly be visited in future.
        /// </summary>
        IReadOnlyCollection<INode<TStep>> Candidates { get; }
    }
}