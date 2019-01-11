using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Heuristic.Linq.Algorithms
{
    internal class AStar : IAlgorithm, IObservableAlgorithm
    {
        string IAlgorithm.AlgorithmName => nameof(AStar);

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

            var nc = source.NodeComparer;
            var sc = source.StepComparer;
            var open = new List<Node<TFactor, TStep>>(source.ConvertToNodes(source.From, 0));

            if (open.Count == 0)
                return null;

            open.Sort(nc);

            var closed = new HashSet<TStep>(sc);
            var sortAt = 0;

            while (open.Count - sortAt > 0)
            {
                var current = open[sortAt];
                var sortAll = false;

                if (sc.Equals(current.Step, source.To))
                    return current;

                sortAt++;
                closed.Add(current.Step);

                foreach (var next in source.Expands(current.Step, current.Level))
                {
                    if (closed.Contains(next.Step)) continue;
                    if (open.Find(step => sc.Equals(next.Step, step.Step)) == null)
                    {
                        next.Previous = current;

                        if (sc.Equals(next.Step, source.To))
                            return next;

                        sortAll = sortAll || nc.Compare(open[open.Count - 1], next) > 0;
                        open.Add(next);

                        Debug.WriteLine($"{current.Step}\t{current.Level} -> {next.Step}\t{next.Level}");
                    }
                }
                if (sortAll)
                    open.Sort(sortAt, open.Count - sortAt, nc);
            }
            return null;
        }

        public static Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            var nc = source.NodeComparer;
            var sc = source.StepComparer;
            var open = new List<Node<TFactor, TStep>>(source.ConvertToNodes(source.From, 0));

            if (open.Count == 0)
                return observer.NotFound();

            open.Sort(nc);

            var closed = new HashSet<TStep>(sc);
            var sortAt = 0;

            while (open.Count - sortAt > 0)
            {
                var current = observer.InProgress(open[sortAt], open.GetRange(sortAt, open.Count - sortAt));
                var sortAll = false;

                if (sc.Equals(current.Step, source.To))
                    return observer.Found(current, open.GetRange(sortAt, open.Count - sortAt));

                sortAt++;
                closed.Add(current.Step);

                foreach (var next in source.Expands(current.Step, current.Level))
                {
                    if (closed.Contains(next.Step)) continue;
                    if (open.Find(step => sc.Equals(next.Step, step.Step)) == null)
                    {
                        next.Previous = current;

                        if (sc.Equals(next.Step, source.To))
                            return observer.Found(next, open.GetRange(sortAt, open.Count - sortAt));

                        sortAll = sortAll || nc.Compare(open[open.Count - 1], next) > 0;
                        open.Add(next);

                        Debug.WriteLine($"{current.Step}\t{current.Level} -> {next.Step}\t{next.Level}");
                    }
                }
                if (sortAll)
                    open.Sort(sortAt, open.Count - sortAt, nc);
            }
            return observer.NotFound();
        }
    }
}