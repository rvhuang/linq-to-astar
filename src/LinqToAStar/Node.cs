using System.Collections;
using System.Collections.Generic;

namespace LinqToAStar
{
    class Node<TFactor, TStep> : IEnumerable<TFactor>
    {
        public Node<TFactor, TStep> Previous
        {
            get; set;
        }

        public TStep Step
        {
            get; private set;
        }

        public Node<TFactor, TStep> Next
        {
            get; set;
        }

        public int Level
        {
            get; private set;
        }

        public TFactor Result
        {
            get; private set;
        }

        public Node(TStep step, TFactor result, int level)
        {
            Step = step;
            Result = result;
            Level = level;
        }

        public Node<TFactor, TStep> TraceBack()
        {
            var node = this;

            while (node.Previous != null)
            {
                node.Previous.Next = node;
                node = node.Previous;
            }
            return node;
        }

        public IEnumerator<TFactor> GetEnumerator()
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