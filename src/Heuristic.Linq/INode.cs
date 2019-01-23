namespace Heuristic.Linq
{
    /// <summary>
    /// Provides an abstract view of node information.
    /// </summary>
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>
    public interface INode<out TStep>
    {
        /// <summary>
        /// Gets the previous node of current instance.
        /// </summary>
        INode<TStep> Previous { get; }

        /// <summary>
        /// Gets the next node of current instance.
        /// </summary>
        INode<TStep> Next { get; }

        /// <summary>
        /// Gets the step of current node.
        /// </summary>
        TStep Step { get; }

        /// <summary>
        /// Gets the corresponding level of <see cref="Step"/>.
        /// </summary>
        int Level { get; }
    }
}
