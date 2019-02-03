using System;

namespace Heuristic.Linq
{
    using Algorithms;

    /// <summary>
    /// Represents the object that is able to create <see cref="IProgress{T}"/> instances.
    /// </summary>
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>
    public interface IAlgorithmObserverFactory<TStep>
    {
        /// <summary>
        /// Creates an <see cref="IProgress{T}"/> instance where T is <see cref="AlgorithmState{TFactor, TStep}"/>.
        /// </summary>
        /// <param name="source">The instance that allows LINQ expressions to be applied to.</param>
        /// <returns>An <see cref="IProgress{T}"/> instance.</returns>
        IProgress<AlgorithmState<TFactor, TStep>> Create<TFactor>(HeuristicSearchBase<TFactor, TStep> source);
    }
}