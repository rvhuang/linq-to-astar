using System.Collections;
using System.Collections.Generic;

namespace LinqToAStar
{
    public class Node<TFactor, TStep> : IEnumerable<TFactor>
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

        public TFactor Factor
        {
            get; private set;
        }

        public Node(TStep step, TFactor factor, int level)
        {
            Step = step;
            Factor = factor;
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

        public IEnumerable<Node<TFactor, TStep>> GenerateNodeSequence()
        {
            var node = this;

            do
            {
                yield return node;
                node = node.Next;
            }
            while (node != null);
        }

        public IEnumerator<TFactor> GetEnumerator()
        {
            var node = this;

            do
            {
                yield return node.Factor;
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
            return $"{Step}({Factor}) Level: {Level}";
        }
    }
}