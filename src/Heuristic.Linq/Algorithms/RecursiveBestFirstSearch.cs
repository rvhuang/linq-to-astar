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

        public static Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IAlgorithmObserver<TFactor, TStep> observer)
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

        #region Override

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

            return state.Flag == RecursionFlag.Found ? state.Node : null;
        }

        #endregion

        #region Core

        private RecursionState<TFactor, TStep> Search(Node<TFactor, TStep> current, Node<TFactor, TStep> bound, ISet<TStep> visited)
        {
            visited.Add(current.Step);

            if (_source.StepComparer.Equals(current.Step, _source.To))
                return new RecursionState<TFactor, TStep>(RecursionFlag.Found, current);

            var nexts = _source.Expands(current.Step, current.Level, step => !visited.Contains(step)).ToArray();

            if (nexts.Length == 0)
                return new RecursionState<TFactor, TStep>(RecursionFlag.NotFound, current);

            Array.ForEach(nexts, next => next.Previous = current);
            Array.Sort(nexts, _nodeComparer);

            var sortAt = 0;
            var state = default(RecursionState<TFactor, TStep>);

            while (nexts.Length - sortAt > 0)
            {
                var best = nexts[sortAt]; // nexts.First();

                Debug.WriteLine($"{current.Step}\t{current.Level} -> {best.Step}\t{best.Level}");

                if (_nodeComparer.Compare(best, bound) > 0)
                    return new RecursionState<TFactor, TStep>(RecursionFlag.NotFound, best);

                if (nexts.Length - sortAt < 2)
                    state = Search(best, null, visited);
                else
                    state = Search(best, _nodeComparer.Min(nexts[sortAt + 1], bound), visited);

                switch (state.Flag)
                {
                    case RecursionFlag.Found:
                        return state;

                    case RecursionFlag.NotFound:
                        sortAt++; // nexts.RemoveAt(0);
                        break;
                }
            }
            return new RecursionState<TFactor, TStep>(RecursionFlag.NotFound, null);
        }

        #endregion 
    }

    class ObservableRecursiveBestFirstSearch<TFactor, TStep>
    {
        #region Fields

        private readonly HeuristicSearchBase<TFactor, TStep> _source;
        private readonly IAlgorithmObserver<TFactor, TStep> _observer;
        private readonly IComparer<Node<TFactor, TStep>> _nodeComparer;

        #endregion

        #region Constructor

        internal ObservableRecursiveBestFirstSearch(HeuristicSearchBase<TFactor, TStep> source, IAlgorithmObserver<TFactor, TStep> observer)
        {
            _source = source;
            _observer = observer;
            _nodeComparer = source.NodeComparer.FactorOnlyComparer;
        }

        #endregion

        #region Override

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

            switch (state.Flag)
            {
                case RecursionFlag.Found:
                    _observer.OnCompleted(state.Node, state.Candidates);
                    return state.Node;
                default:
                    _observer.OnNotFound(state.Candidates);
                    return null;
            }
        }

        #endregion

        #region Core

        private RecursionState<TFactor, TStep> Search(Node<TFactor, TStep> current, Node<TFactor, TStep> bound, ISet<TStep> visited)
        {
            visited.Add(current.Step);

            if (_source.StepComparer.Equals(current.Step, _source.To))
                return new RecursionState<TFactor, TStep>(RecursionFlag.Found, current);

            var nexts = _source.Expands(current.Step, current.Level, step => !visited.Contains(step)).ToArray();

            _observer.OnMovingToNextNode(current, nexts);

            if (nexts.Length == 0)
                return new RecursionState<TFactor, TStep>(RecursionFlag.NotFound, current);

            Array.ForEach(nexts, next => next.Previous = current);
            Array.Sort(nexts, _nodeComparer);

            var sortAt = 0;
            var state = default(RecursionState<TFactor, TStep>);

            while (nexts.Length - sortAt > 0)
            {
                var best = nexts[sortAt]; // nexts.First();

                _observer.OnMovedToNextNode(best, nexts);
                
                if (_nodeComparer.Compare(best, bound) > 0)
                    return new RecursionState<TFactor, TStep>(RecursionFlag.NotFound, best, nexts);

                if (nexts.Length - sortAt < 2)
                    state = Search(best, null, visited);
                else
                    state = Search(best, _nodeComparer.Min(nexts[sortAt + 1], bound), visited);

                switch (state.Flag)
                {
                    case RecursionFlag.Found:
                        return state;

                    case RecursionFlag.NotFound:
                        sortAt++; // nexts.RemoveAt(0);
                        break;
                }
            }
            return new RecursionState<TFactor, TStep>(RecursionFlag.NotFound, null, nexts);
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

        Node<TFactor, TStep> IObservableAlgorithm.Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IAlgorithmObserver<TFactor, TStep> observer)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            return new ObservableRecursiveBestFirstSearch<TFactor, TStep>(source, observer).Run();
        }
    }
}