using System;

namespace Heuristic.Linq
{
    using Algorithms;

    /// <summary>
    /// Represents an algorithm that can be observed with an <see cref="IProgress{T}"/> instance.
    /// </summary>
    public interface IObservableAlgorithm : IAlgorithm
    {
        /// <summary>
        /// Run the algorithm with applied LINQ expressions and an <see cref="IProgress{T}"/> instance.
        /// </summary>
        /// <param name="source">The instance that allows LINQ expressions to be applied to.</param>
        /// <param name="observer">An <see cref="IProgress{T}"/> instance that observes the solution finding process.</param>
        /// <returns>The last node of solution found by the algorithm, or null if not found.</returns>
        Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer);
    }
}