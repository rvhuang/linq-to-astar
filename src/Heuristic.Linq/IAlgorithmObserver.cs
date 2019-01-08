using System.Collections.Generic;

namespace Heuristic.Linq
{
    /// <summary>
    /// Represents an object that observes the solution finding process within an algorithm.
    /// </summary>
    /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function.</typeparam>
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>
    public interface IAlgorithmObserver<TFactor, TStep>
    {
        /// <summary>
        /// The method that is called when the algorithm is moving to next <see cref="Node{TFactor, TStep}"/> instance.
        /// </summary>
        /// <param name="current">The current node where the algorithm is at.</param>
        /// <param name="candidates">A collection that consists of unvisited potential nodes.</param>
        /// <remarks>
        /// 
        /// </remarks>
        void OnMovingToNextNode(Node<TFactor, TStep> current, IReadOnlyCollection<Node<TFactor, TStep>> candidates);

        /// <summary>
        /// The method that is called when the algorithm has moved to next <see cref="Node{TFactor, TStep}"/> instance.
        /// </summary>
        /// <param name="current">The current node where the algorithm is at.</param>
        /// <param name="candidates">A collection that consists of unvisited potential nodes.</param>
        /// <remarks>
        /// 
        /// </remarks>
        void OnMovedToNextNode(Node<TFactor, TStep> current, IReadOnlyCollection<Node<TFactor, TStep>> candidates);

        /// <summary>
        /// The method that is called when the algorithm have found the solution.
        /// </summary>
        /// <param name="current">The current node where the algorithm is at.</param>
        /// <param name="candidates">A collection that consists of remaining unvisited potential nodes.</param>
        void OnCompleted(Node<TFactor, TStep> current, IReadOnlyCollection<Node<TFactor, TStep>> candidates);

        /// <summary>
        /// The method that is called when no solutions are found.
        /// </summary>
        /// <param name="candidates">A collection that consists of remaining unvisited potential nodes.</param>
        void OnNotFound(IReadOnlyCollection<Node<TFactor, TStep>> candidates);
    }
}
