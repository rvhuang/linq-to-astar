using System.Collections.Generic;

namespace LinqToAStar
{
    interface INodeComparer<TResult, TStep> : IComparer<Node<TResult, TStep>>, IComparer<TResult>
    {
        IComparer<Node<TResult, TStep>> ResultOnlyComparer { get; }
    }
}
