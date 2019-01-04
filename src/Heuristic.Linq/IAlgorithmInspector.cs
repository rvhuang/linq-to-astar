using System;
using System.Collections.Generic;
using System.Text;

namespace Heuristic.Linq
{
    interface IAlgorithmInspector<TFactor, TStep>
    {
        void MovingToNextNode(Node<TFactor, TStep> current, IList<Node<TFactor, TStep>> candidates);

        void MovedToNextNode(Node<TFactor, TStep> current, IReadOnlyList<Node<TFactor, TStep>> candidates);

        void Complete(Node<TFactor, TStep> current, IReadOnlyList<Node<TFactor, TStep>> candidates);
    }
}
