namespace Heuristic.Linq
{
    /// <summary>
    /// Represents an algorithm.
    /// </summary>
    /// <seealso cref="HeuristicSearch.Register{TAlgorithm}(string)"/>
    public interface IAlgorithm
    {
        /// <summary>
        /// Gets the algorithm name.
        /// </summary>
        string AlgorithmName { get; }

        /// <summary>
        /// Run the algorithm with applied LINQ expressions.
        /// </summary>
        /// <param name="source">The instance that allows LINQ expressions to be applied to.</param>
        /// <returns>The last node of solution found by the algorithm, or null if not found.</returns>
        Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source);
    }
}