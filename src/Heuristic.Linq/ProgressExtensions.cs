using System;
using System.Collections.Generic;

namespace Heuristic.Linq
{
    using Algorithms;

    static class ProgressExtensions // TODO: Consider expose this.
    {
        public static Node<TFactor, TStep> Found<TFactor, TStep>(this IProgress<AlgorithmState<TFactor, TStep>> observer, Node<TFactor, TStep> current, IReadOnlyCollection<Node<TFactor, TStep>> candidates)
        {
            observer.Report(new AlgorithmState<TFactor, TStep>(AlgorithmFlag.Found, current, candidates));
            return current;
        }

        public static Node<TFactor, TStep> InProgress<TFactor, TStep>(this IProgress<AlgorithmState<TFactor, TStep>> observer, Node<TFactor, TStep> current, IReadOnlyCollection<Node<TFactor, TStep>> candidates)
        {
            observer.Report(new AlgorithmState<TFactor, TStep>(AlgorithmFlag.InProgress, current, candidates));
            return current;
        }

        public static Node<TFactor, TStep> NotFound<TFactor, TStep>(this IProgress<AlgorithmState<TFactor, TStep>> observer)
        {
            observer.Report(AlgorithmState<TFactor, TStep>.NotFound);
            return null;
        }

        public static AlgorithmState<TFactor, TStep> ReportAndReturn<TFactor, TStep>(this IProgress<AlgorithmState<TFactor, TStep>> observer, AlgorithmState<TFactor, TStep> state)
        {
            observer.Report(state);
            return state;
        }

        public static AlgorithmState<TFactor, TStep> ReportAndReturn<TFactor, TStep>(this IProgress<AlgorithmState<TFactor, TStep>> observer, AlgorithmFlag flag, Node<TFactor, TStep> node)
        {
            var state = new AlgorithmState<TFactor, TStep>(flag, node);

            observer.Report(state);
            return state;
        }

        public static AlgorithmState<TFactor, TStep> ReportAndReturn<TFactor, TStep>(this IProgress<AlgorithmState<TFactor, TStep>> observer, AlgorithmFlag flag, Node<TFactor, TStep> node, IReadOnlyCollection<Node<TFactor, TStep>> candidates)
        {
            var state = new AlgorithmState<TFactor, TStep>(flag, node, candidates);

            observer.Report(state);
            return state;
        }
    }
}