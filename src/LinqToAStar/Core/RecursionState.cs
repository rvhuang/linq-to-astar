namespace LinqToAStar.Core
{
    internal struct RecursionState<TResult, TStep>
    {
        public RecursionFlag Flag
        {
            get; private set;
        }

        public Node<TResult, TStep> Node
        {
            get; private set;
        }

        public RecursionState(RecursionFlag flag, Node<TResult, TStep> node)
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