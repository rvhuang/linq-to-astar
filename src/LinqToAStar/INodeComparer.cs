using System.Collections.Generic;

namespace LinqToAStar
{
    interface INodeComparer<TFactor, TStep> : IComparer<Node<TFactor, TStep>>, IComparer<TFactor>
    {
        IComparer<Node<TFactor, TStep>> ResultOnlyComparer { get; }
    }
}
