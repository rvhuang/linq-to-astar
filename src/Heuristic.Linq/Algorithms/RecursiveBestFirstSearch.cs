using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Heuristic.Linq.Algorithms
{
    static class RecursiveBestFirstSearch
    {
        public static Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            return new RecursiveBestFirstSearch<TFactor, TStep>(source).Run();
        }

        public static Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            return new ObservableRecursiveBestFirstSearch<TFactor, TStep>(source, observer).Run();
        }
    }

    class RecursiveBestFirstSearch<TFactor, TStep>
    {
        #region Fields

        private readonly HeuristicSearchBase<TFactor, TStep> _source;
        private readonly IComparer<Node<TFactor, TStep>> _nodeComparer;

        #endregion

        #region Constructor

        internal RecursiveBestFirstSearch(HeuristicSearchBase<TFactor, TStep> source)
        {
            _source = source;
            _nodeComparer = source.NodeComparer.FactorOnlyComparer;
        }

        #endregion

        #region Public Method

        public Node<TFactor, TStep> Run()
        {
            var inits = _source.ConvertToNodes(_source.From, 0).ToArray();

            if (inits.Length == 0)
                return null;

            try
            {
                Array.Sort(inits, _nodeComparer);
            }
            catch (Exception error)
            {
                throw error.InnerException ?? error;
            }

            var best = inits[0];
            var state = Search(best, null, new HashSet<TStep>(_source.StepComparer));

            return state.Flag == AlgorithmFlag.Found ? state.Node : null;
        }

        #endregion

        #region Core

        private AlgorithmState<TFactor, TStep> Search(Node<TFactor, TStep> current, Node<TFactor, TStep> bound, ISet<TStep> visited)
        {
            visited.Add(current.Step);

            if (_source.StepComparer.Equals(current.Step, _source.To))
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.Found, current);

            var nexts = _source.Expands(current.Step, current.Level, step => !visited.Contains(step)).ToArray();

            if (nexts.Length == 0)
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.NotFound, current);

            Array.ForEach(nexts, next => next.Previous = current);
            Array.Sort(nexts, _nodeComparer);

            var sortAt = 0;
            var state = default(AlgorithmState<TFactor, TStep>);

            while (nexts.Length - sortAt > 0)
            {
                var best = nexts[sortAt]; // nexts.First();

                Debug.WriteLine($"{current.Step}\t{current.Level} -> {best.Step}\t{best.Level}");

                if (_nodeComparer.Compare(best, bound) > 0)
                    return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.NotFound, best);

                if (nexts.Length - sortAt < 2)
                    state = Search(best, null, visited);
                else
                    state = Search(best, _nodeComparer.Min(nexts[sortAt + 1], bound), visited);

                switch (state.Flag)
                {
                    case AlgorithmFlag.Found:
                        return state;

                    case AlgorithmFlag.NotFound:
                        sortAt++; // nexts.RemoveAt(0);
                        break;
                }
            }
            return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.NotFound, null);
        }

        #endregion 
    }

    class ObservableRecursiveBestFirstSearch<TFactor, TStep>
    {
        #region Fields

        private readonly HeuristicSearchBase<TFactor, TStep> _source;
        private readonly IProgress<AlgorithmState<TFactor, TStep>> _observer;
        private readonly IComparer<Node<TFactor, TStep>> _nodeComparer;

        #endregion

        #region Constructor

        internal ObservableRecursiveBestFirstSearch(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer)
        {
            _source = source;
            _observer = observer;
            _nodeComparer = source.NodeComparer.FactorOnlyComparer;
        }

        #endregion

        #region Public Method

        public Node<TFactor, TStep> Run()
        {
            var inits = _source.ConvertToNodes(_source.From, 0).ToArray();

            if (inits.Length == 0)
                return null;

            try
            {
                Array.Sort(inits, _nodeComparer);
            }
            catch (Exception error)
            {
                throw error.InnerException ?? error;
            }

            var best = inits[0];
            var state = Search(best, null, new HashSet<TStep>(_source.StepComparer));

            return state.Flag == AlgorithmFlag.Found ? _observer.ReportAndReturn(state).Node : _observer.NotFound();
        }

        #endregion

        #region Core

        private AlgorithmState<TFactor, TStep> Search(Node<TFactor, TStep> current, Node<TFactor, TStep> bound, ISet<TStep> visited)
        {
            /*
             * Important Note: 
             * Only the status AlgorithmFlag.InProgress should be reported from this method
             * because either AlgorithmFlag.Found or AlgorithmFlag.NotFound should only occur once.
             */
            visited.Add(current.Step);

            if (_source.StepComparer.Equals(current.Step, _source.To))
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.Found, current);

            var nexts = _source.Expands(current.Step, current.Level, step => !visited.Contains(step)).ToArray();

            if (nexts.Length == 0)
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.NotFound, current);

            Array.ForEach(nexts, next => next.Previous = current);
            Array.Sort(nexts, _nodeComparer);

            var sortAt = 0;
            var state = default(AlgorithmState<TFactor, TStep>);

            while (nexts.Length - sortAt > 0)
            {
                var best = _observer.InProgress(nexts[sortAt], new ArraySegment<Node<TFactor, TStep>>(nexts, sortAt, nexts.Length - sortAt)); // nexts.First();

                Debug.WriteLine($"{current.Step}\t{current.Level} -> {best.Step}\t{best.Level}");

                if (_nodeComparer.Compare(best, bound) > 0)
                    return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.NotFound, best);

                if (nexts.Length - sortAt < 2)
                    state = Search(best, null, visited);
                else
                    state = Search(best, _nodeComparer.Min(nexts[sortAt + 1], bound), visited);

                switch (state.Flag)
                {
                    case AlgorithmFlag.Found:
                        return state;

                    case AlgorithmFlag.NotFound:
                        sortAt++; // nexts.RemoveAt(0);
                        break;
                }
            }
            return AlgorithmState<TFactor, TStep>.NotFound;
        }

        #endregion 
    }


    internal struct RecursiveBestFirstSearchAlgorithm : IAlgorithm, IObservableAlgorithm
    {
        string IAlgorithm.AlgorithmName => nameof(RecursiveBestFirstSearch);

        Node<TFactor, TStep> IAlgorithm.Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            return new RecursiveBestFirstSearch<TFactor, TStep>(source).Run();
        }

        Node<TFactor, TStep> IObservableAlgorithm.Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            return new ObservableRecursiveBestFirstSearch<TFactor, TStep>(source, observer).Run();
        }
    }
}