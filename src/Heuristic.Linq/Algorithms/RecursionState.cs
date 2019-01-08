using System;
using System.Collections.Generic;

namespace Heuristic.Linq.Algorithms
{
    internal struct RecursionState<TFactor, TStep>
    {
        public RecursionFlag Flag
        {
            get; private set;
        }

        public Node<TFactor, TStep> Node
        {
            get; private set;
        }

        public IReadOnlyCollection<Node<TFactor, TStep>> Candidates // Optional, for observers only
        {
            get; private set;
        }

        public RecursionState(RecursionFlag flag, Node<TFactor, TStep> node)
        {
            Flag = flag;
            Node = node;
            Candidates = Array.Empty<Node<TFactor, TStep>>();
        }

        public RecursionState(RecursionFlag flag, Node<TFactor, TStep> node, IReadOnlyCollection<Node<TFactor, TStep>> candidates)
        {
            Flag = flag;
            Node = node;
            Candidates = candidates;
        }

        public override string ToString()
        {
            return $"{Node.Step} -> {Node.Factor} ({Flag})";
        }
    }

    internal enum RecursionFlag
    {
        Found,

        InProgress,

        NotFound,
    }
}