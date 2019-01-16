using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Heuristic.Linq.Algorithms
{
    internal class BestFirstSearch : IAlgorithm, IObservableAlgorithm
    {
        string IAlgorithm.AlgorithmName => nameof(BestFirstSearch);

        Node<TFactor, TStep> IAlgorithm.Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source)
        {
            return Run(source);
        }

        Node<TFactor, TStep> IObservableAlgorithm.Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer)
        {
            return Run(source, observer);
        }

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

        public static Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            var nc = source.NodeComparer.FactorOnlyComparer;
            var sc = source.StepComparer;
            var nexts = new List<Node<TFactor, TStep>>(source.ConvertToNodes(source.From, 0));

            if (nexts.Count == 0)
                return observer.NotFound();

            var visited = new HashSet<TStep>(sc);
            var sortAt = 0;

            while (nexts.Count - sortAt > 0)
            {
                var best = observer.InProgress(nexts[sortAt], nexts.GetRange(sortAt, nexts.Count - sortAt)); // nexts.First();
                var sortAll = false;

                if (sc.Equals(best.Step, source.To))
                    return observer.Found(best, nexts.GetRange(sortAt, nexts.Count - sortAt));

                sortAt++; // nexts.RemoveAt(0);

                foreach (var next in source.Expands(best.Step, best.Level, visited.Add))
                {
                    next.Previous = best;

                    if (sc.Equals(next.Step, source.To))
                        return observer.Found(next, nexts.GetRange(sortAt, nexts.Count - sortAt));

                    sortAll = sortAll || nc.Compare(nexts[nexts.Count - 1], next) > 0;
                    nexts.Add(next);

                    Debug.WriteLine($"{best.Step}\t{best.Level} -> {next.Step}\t{next.Level}");
                }
                if (sortAll)
                    nexts.Sort(sortAt, nexts.Count - sortAt, nc);
            }
            return observer.NotFound();
        }
    }
}