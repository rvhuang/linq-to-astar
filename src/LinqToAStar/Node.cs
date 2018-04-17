using System.Collections;
using System.Collections.Generic;

namespace LinqToAStar
{
    class Node<TStep, TResult> : IEnumerable<TResult>
    {
        public Node<TStep, TResult> Previous
        {
            get; set;
        }

        public TStep Step
        {
            get; private set;
        }

        public Node<TStep, TResult> Next
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

        public Node<TStep, TResult> TracesBack()
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
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return $"{Step}({Result}) Level: {Level}";
        }
    }
}