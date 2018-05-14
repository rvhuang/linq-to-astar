using System.Collections;
using System.Collections.Generic;

namespace LinqToAStar
{
    class Node<TResult, TStep> : IEnumerable<TResult>
    {
        public Node<TResult, TStep> Previous
        {
            get; set;
        }

        public TStep Step
        {
            get; private set;
        }

        public Node<TResult, TStep> Next
        {
            get; set;
        }

        public int Level
        {
            get; private set;
        }

        public TResult Result
        {
            get; private set;
        }

        public Node(TStep step, TResult result, int level)
        {
            Step = step;
            Result = result;
            Level = level;
        }

        public Node<TResult, TStep> TraceBack()
        {
            var node = this;

            while (node.Previous != null)
            {
                node.Previous.Next = node;
                node = node.Previous;
            }
            return node;
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            var node = this;

            do
            {
                yield return node.Result;
                node = node.Next;
            }
            while (node != null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"{Step}({Result}) Level: {Level}";
        }
    }
}