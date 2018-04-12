using System.Collections.Generic;

namespace LinqToAStar.Core
{
    internal class RecursionState<TResult, TStep>
    {
        private readonly HeuristicSearchBase<TResult, TStep> _owner; 
        private readonly ISet<TStep> _visited;

        public ISet<TStep> Visited => _visited;

        public RecursionState(HeuristicSearchBase<TResult, TStep> owner)
        { 
            _owner = owner; 
            _visited = new HashSet<TStep>(owner.Comparer);
        }
    }

    internal enum RecursionFlag
    {
        Found,

        InProgress,

        NotFound,
    }

    internal struct RecursionResult<TStep, TResult>
    {
        public RecursionFlag Flag
        {
            get; private set;
        }

        public Node<TStep, TResult> Node
        {
            get; private set;
        }

        public RecursionResult(RecursionFlag flag, Node<TStep, TResult> node)
        {  
            Flag = flag; 
            Node = node;
        }

        public override string ToString()
        {
            return $"{Node.Step} -> {Node.Result} ({Flag})";
        }
    } 
}