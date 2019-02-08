using System;
using System.Collections.Generic;

namespace Heuristic.Linq
{
    using Algorithms;

    /// <summary>
    /// Provides the default implementation of <see cref="IAlgorithmObserverFactory{TStep}"/> interface.
    /// </summary> 
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>   
    public class AlgorithmObserverFactory<TStep> : IAlgorithmObserverFactory<TStep>
    {
        private readonly List<AlgorithmProgress<TStep>> progresses;

        /// <summary>
        /// Gets the collection of <see cref="AlgorithmProgress{TStep}"/> instances created by the factory.
        /// </summary>
        public IReadOnlyList<AlgorithmProgress<TStep>> Progresses => progresses;

        /// <summary>
        /// Invoked when a new <see cref="AlgorithmProgress{TStep}"/> instance is created.
        /// </summary>
        public event EventHandler<AlgorithmProgress<TStep>> Created;

        /// <summary>
        /// Initializes a new instance of current class.
        /// </summary>
        public AlgorithmObserverFactory() => progresses = new List<AlgorithmProgress<TStep>>();

        IProgress<AlgorithmState<TFactor, TStep>> IAlgorithmObserverFactory<TStep>.Create<TFactor>(HeuristicSearchBase<TFactor, TStep> source)
        {
            var progress = new AlgorithmProgress<TFactor, TStep>();

            OnCreated(progress);

            return progress;
        }

        /// <summary>
        /// Invokes <see cref="Created"/> event.
        /// </summary>
        /// <param name="progress">The new <see cref="AlgorithmProgress{TStep}"/> instance.</param>
        protected virtual void OnCreated(AlgorithmProgress<TStep> progress)
        {
            progresses.Add(progress);
            Created?.Invoke(this, progress);
        }
    }
}