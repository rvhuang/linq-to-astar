using System;

namespace Heuristic.Linq
{
    using Algorithms;

    /// <summary>
    /// Provides the default implementation of <see cref="IAlgorithmObserverFactory{TStep}"/> interface.
    /// </summary>
    /// <typeparam name="TStep"></typeparam>
    public class AlgorithmObserverFactory<TStep> : IAlgorithmObserverFactory<TStep>
    {
        /// <summary>
        /// Invoked when a new <see cref="AlgorithmProgress{TStep}"/> instance is created.
        /// </summary>
        public readonly EventHandler<AlgorithmProgress<TStep>> Created;

        /// <summary>
        /// Initializes a new instance of current class.
        /// </summary>
        public AlgorithmObserverFactory() { }

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
            Created?.Invoke(this, progress);
        }
    }
}