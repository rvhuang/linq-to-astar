using System.Collections.Generic;

namespace LinqToAStar
{
    interface INodeComparer<TStep, TResult> : IComparer<Node<TStep, TResult>>, IComparer<TResult>
    {
        IComparer<Node<TStep, TResult>> ResultOnlyComparer { get; }
    }
}
