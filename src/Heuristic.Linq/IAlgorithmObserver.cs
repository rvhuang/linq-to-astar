using System.Collections.Generic;

namespace Heuristic.Linq
{
    interface IAlgorithmObserver<TFactor, TStep>
    {
        void OnMovingToNextNode(Node<TFactor, TStep> current, IList<Node<TFactor, TStep>> candidates);

        void OnMovedToNextNode(Node<TFactor, TStep> current, IList<Node<TFactor, TStep>> candidates);

        void OnCompleted(Node<TFactor, TStep> current, IList<Node<TFactor, TStep>> candidates);

        void OnNotFound(Node<TFactor, TStep> current);
    }
}
