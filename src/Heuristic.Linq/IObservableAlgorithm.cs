namespace Heuristic.Linq
{
    interface IObservableAlgorithm : IAlgorithm
    {
        Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IAlgorithmObserver<TFactor, TStep> inspector);
    }
}