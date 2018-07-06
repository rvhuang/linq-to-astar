using System.Collections.Generic;
using System.Diagnostics;

namespace Heuristic.Linq.Algorithms
{
    internal static class BestFirstSearch
    {
        public static Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            var nc = source.NodeComparer.FactorOnlyComparer;
            var sc = source.StepComparer;
            var nexts = new List<Node<TFactor, TStep>>(source.ConvertToNodes(source.From, 0));

            if (nexts.Count == 0)
                return null;

            var visited = new HashSet<TStep>(sc);
            var sortAt = 0;

            while (nexts.Count - sortAt > 0)
            {
                var best = nexts[sortAt]; // nexts.First();
                var sortAll = false;

                if (sc.Equals(best.Step, source.To))
                    return best;

                sortAt++; // nexts.RemoveAt(0);

                foreach (var next in source.Expands(best.Step, best.Level, visited.Add))
                {
                    next.Previous = best;

                    if (sc.Equals(next.Step, source.To))
                        return next;

                    sortAll = sortAll || nc.Compare(nexts[nexts.Count - 1], next) > 0;
                    nexts.Add(next);

                    Debug.WriteLine($"{best.Step}\t{best.Level} -> {next.Step}\t{next.Level}");
                }
                if (sortAll)
                    nexts.Sort(sortAt, nexts.Count - sortAt, nc);
            }
            return null;
        }
    }

    internal struct BestFirstSearchrAlgorithm : IAlgorithm
    {
        string IAlgorithm.AlgorithmName => nameof(BestFirstSearch);

        Node<TFactor, TStep> IAlgorithm.Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source)
        {
            return BestFirstSearch.Run(source);
        }
    }
}