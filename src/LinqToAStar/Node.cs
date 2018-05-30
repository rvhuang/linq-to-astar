using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    public class Node<TFactor, TStep>
    {
        #region Properties

        public Node<TFactor, TStep> Previous
        {
            get; set;
        }

        public Node<TFactor, TStep> Next
        {
            get; set;
        }

        public TStep Step
        {
            get; private set;
        }

        public int Level
        {
            get; private set;
        }

        public TFactor Factor
        {
            get; private set;
        }

        #endregion

        #region Constructor

        internal Node(TStep step, TFactor factor, int level)
        {
            Step = step;
            Factor = factor;
            Level = level;
        }

        #endregion

        #region Methods

        internal IEnumerable<TFactor> EnumerateFactors()
        {
            var node = this;

            do
            {
                yield return node.Factor;
                node = node.Next;
            }
            while (node != null);
        }

        internal Node<TFactor, TStep> TraceBack()
        {
            var node = this;

            while (node.Previous != null)
            {
                node.Previous.Next = node;
                node = node.Previous;
            }
            return node;
        }

        internal IEnumerable<TFactor> EnumerateReverseFactors()
        {
            var node = this;

            yield return node.Factor;

            while (node.Previous != null)
            {
                node.Previous.Next = node;
                node = node.Previous;

                yield return node.Factor;
            }
        }

        #endregion

        #region Overrides 

        public override string ToString()
        {
            return $"{Step}({Factor}) Level: {Level}";
        }

        #endregion

        #region Other

        public static Node<TFactor, TStep> Create(TStep step, TFactor factor, int level)
        {
            if (step == null) throw new ArgumentNullException(nameof(step));
            if (level < 0) throw new ArgumentOutOfRangeException(nameof(level));

            return new Node<TFactor, TStep>(step, factor, level);
        }

        #endregion
    }
}