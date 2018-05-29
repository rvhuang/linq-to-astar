namespace LinqToAStar
{
    public interface IAlgorithm
    {
        string AlgorithmName { get; }

        Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source);
    }
}