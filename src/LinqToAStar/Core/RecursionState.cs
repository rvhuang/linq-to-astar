namespace LinqToAStar.Core
{
    internal struct RecursionState<TStep, TResult>
    {
        public RecursionFlag Flag
        {
            get; private set;
        }

        public Node<TStep, TResult> Node
        {
            get; private set;
        }

        public RecursionState(RecursionFlag flag, Node<TStep, TResult> node)
        {  
            Flag = flag; 
            Node = node;
        }

        public override string ToString()
        {
            return $"{Node.Step} -> {Node.Result} ({Flag})";
        }
    }

    internal enum RecursionFlag
    {
        Found,

        InProgress,

        NotFound,
    } 
}