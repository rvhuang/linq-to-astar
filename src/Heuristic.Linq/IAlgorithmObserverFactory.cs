namespace Heuristic.Linq
{
    /// <summary>
    /// Represents the object that is able to create <see cref="IAlgorithmObserver{TFactor, TStep}"/> instances.
    /// </summary>
    public interface IAlgorithmObserverFactory
    {
        /// <summary>
        /// Creates an <see cref="IAlgorithmObserver{TFactor, TStep}"/> instance.
        /// </summary>
        /// <param name="source">The instance that allows LINQ expressions to be applied to.</param>
        /// <returns>An <see cref="IAlgorithmObserver{TFactor, TStep}"/> instance.</returns>
        IAlgorithmObserver<TFactor, TStep> Create<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source);
    }
}