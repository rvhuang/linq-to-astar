using System.Collections.Generic;

namespace LinqToAStar
{
    public interface INodeComparer<TFactor, TStep> : IComparer<Node<TFactor, TStep>>, IComparer<TFactor>
    {
        IComparer<Node<TFactor, TStep>> FactorOnlyComparer { get; }
    }
}
