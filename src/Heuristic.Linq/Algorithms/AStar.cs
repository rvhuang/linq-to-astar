﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Heuristic.Linq.Algorithms
{
    internal static class AStar
    {
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
        
        public static Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IAlgorithmObserver<TFactor, TStep> observer)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            var nc = source.NodeComparer;
            var sc = source.StepComparer;
            var open = new List<Node<TFactor, TStep>>(source.ConvertToNodes(source.From, 0));

            if (open.Count == 0)
            {
                observer.OnNotFound(null, Array.Empty<Node<TFactor, TStep>>());
                return null;
            }
            open.Sort(nc);

            var closed = new HashSet<TStep>(sc);
            var sortAt = 0;
            var current = open[sortAt];

            while (open.Count - sortAt > 0)
            {
                current = open[sortAt];

                if (sc.Equals(current.Step, source.To))
                {
                    observer.OnCompleted(current, open.GetRange(sortAt + 1, open.Count - sortAt));
                    return current;
                }

                sortAt++;
                observer.OnMovingToNextNode(current, open.GetRange(sortAt, open.Count - sortAt));
                closed.Add(current.Step);

                var sortAll = false;

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
                    }
                }
                if (sortAll)
                    open.Sort(sortAt, open.Count - sortAt, nc);

                if (open.Count - sortAt > 0)
                    observer.OnMovedToNextNode(open[sortAt], open.GetRange(sortAt, open.Count - sortAt));
            }
            observer.OnNotFound(current, Array.Empty<Node<TFactor, TStep>>());
            return null;
        }
    }

    internal struct AStarAlgorithm : IAlgorithm, IObservableAlgorithm
    {
        string IAlgorithm.AlgorithmName => nameof(AStar);

        Node<TFactor, TStep> IAlgorithm.Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source)
        {
            return AStar.Run(source);
        }

        Node<TFactor, TStep> IObservableAlgorithm.Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IAlgorithmObserver<TFactor, TStep> observer)
        {
            return AStar.Run(source, observer);
        }
    }
}