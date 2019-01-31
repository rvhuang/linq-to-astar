using System.Collections.Generic;

namespace Heuristic.Linq
{
    /// <summary>
    /// Defines the comparer used to compare two <see cref="Node{TFactor, TStep}"/> instances. 
    /// </summary>
    /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
    /// <typeparam name="TStep">The type of step of the problem.</typeparam>
    public interface INodeComparer<TFactor, TStep> : IComparer<Node<TFactor, TStep>>, IComparer<TFactor>
    {
        /// <summary>
        /// Gets the comparer that compare two <see cref="Node{TFactor, TStep}"/> instances.
        /// The result is based on <see cref="Node{TFactor, TStep}.Factor"/> only.
        /// </summary>
        IComparer<Node<TFactor, TStep>> FactorOnlyComparer { get; }
    }
}
