using System;

namespace Heuristic.Linq
{
    using Algorithms;

    /// <summary>
    /// Represents the object that is able to create <see cref="IProgress{T}"/> instances.
    /// </summary>
    public interface IAlgorithmObserverFactory
    {
        /// <summary>
        /// Creates an <see cref="IProgress{T}"/> instance where T is <see cref="AlgorithmState{TFactor, TStep}"/>.
        /// </summary>
        /// <param name="source">The instance that allows LINQ expressions to be applied to.</param>
        /// <returns>An <see cref="IProgress{T}"/> instance.</returns>
        IProgress<AlgorithmState<TFactor, TStep>> Create<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source);
    }
}