using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Heuristic.Linq.Algorithms
{
    class RecursiveBestFirstSearch : IAlgorithm, IObservableAlgorithm
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

    abstract class RecursiveBestFirstSearchBase<TFactor, TStep>
    {
        #region Properties 

        protected HeuristicSearchBase<TFactor, TStep> Source { get; private set; }

        protected IComparer<Node<TFactor, TStep>> NodeComparer { get; private set; }

        #endregion

        #region Constructor

        internal RecursiveBestFirstSearchBase(HeuristicSearchBase<TFactor, TStep> source)
        {
            Source = source;
            NodeComparer = source.NodeComparer.FactorOnlyComparer;
        }

        #endregion

        #region Methods

        public abstract Node<TFactor, TStep> Run();

        protected abstract AlgorithmState<TFactor, TStep> Search(Node<TFactor, TStep> current, Node<TFactor, TStep> bound, ISet<TStep> visited);

        #endregion
    }

    class RecursiveBestFirstSearch<TFactor, TStep> : RecursiveBestFirstSearchBase<TFactor, TStep>
    {
        #region Constructor

        internal RecursiveBestFirstSearch(HeuristicSearchBase<TFactor, TStep> source)
            : base(source)
        {
        }

        #endregion

        #region Methods

        public override Node<TFactor, TStep> Run()
        {
            var inits = Source.ConvertToNodes(Source.From, 0).ToArray();

            if (inits.Length == 0)
                return null;

            try
            {
                Array.Sort(inits, NodeComparer);
            }
            catch (Exception error)
            {
                throw error.InnerException ?? error;
            }

            var best = inits[0];
            var state = Search(best, null, new HashSet<TStep>(Source.StepComparer));

            return state.Flag == AlgorithmFlag.Found ? state.Node : null;
        }

        protected override AlgorithmState<TFactor, TStep> Search(Node<TFactor, TStep> current, Node<TFactor, TStep> bound, ISet<TStep> visited)
        {
            visited.Add(current.Step);

            if (Source.StepComparer.Equals(current.Step, Source.To))
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.Found, current);

            var nexts = Source.Expands(current.Step, current.Level, step => !visited.Contains(step)).ToArray();

            if (nexts.Length == 0)
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.NotFound, current);

            Array.ForEach(nexts, next => next.Previous = current);
            Array.Sort(nexts, NodeComparer);

            var sortAt = 0;
            var state = default(AlgorithmState<TFactor, TStep>);

            while (nexts.Length - sortAt > 0)
            {
                var best = nexts[sortAt]; // nexts.First();

                Debug.WriteLine($"{current.Step}\t{current.Level} -> {best.Step}\t{best.Level}");

                if (NodeComparer.Compare(best, bound) > 0)
                    return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.NotFound, best);

                if (nexts.Length - sortAt < 2)
                    state = Search(best, null, visited);
                else
                    state = Search(best, NodeComparer.Min(nexts[sortAt + 1], bound), visited);

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

    class ObservableRecursiveBestFirstSearch<TFactor, TStep> : RecursiveBestFirstSearchBase<TFactor, TStep>
    {
        #region Fields

        private readonly IProgress<AlgorithmState<TFactor, TStep>> _observer;

        #endregion

        #region Constructor

        internal ObservableRecursiveBestFirstSearch(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer)
            : base(source)
        {
            _observer = observer;
        }

        #endregion

        #region Methods

        public override Node<TFactor, TStep> Run()
        {
            var inits = Source.ConvertToNodes(Source.From, 0).ToArray();

            if (inits.Length == 0)
                return _observer.NotFound();

            try
            {
                Array.Sort(inits, NodeComparer);
            }
            catch (Exception error)
            {
                throw error.InnerException ?? error;
            }

            var best = _observer.InProgress(inits[0], inits);
            var state = Search(best, null, new HashSet<TStep>(Source.StepComparer));

            return state.Flag == AlgorithmFlag.Found ? _observer.ReportAndReturn(state).Node : _observer.NotFound();
        }

        protected override AlgorithmState<TFactor, TStep> Search(Node<TFactor, TStep> current, Node<TFactor, TStep> bound, ISet<TStep> visited)
        {
            /*
             * Important Note: 
             * Only the status AlgorithmFlag.InProgress should be reported from this method
             * because either AlgorithmFlag.Found or AlgorithmFlag.NotFound should only occur once.
             */
            visited.Add(current.Step);

            if (Source.StepComparer.Equals(current.Step, Source.To))
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.Found, current);

            var nexts = Source.Expands(current.Step, current.Level, step => !visited.Contains(step)).ToArray();

            if (nexts.Length == 0)
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.NotFound, current);

            Array.ForEach(nexts, next => next.Previous = current);
            Array.Sort(nexts, NodeComparer);

            var sortAt = 0;
            var state = default(AlgorithmState<TFactor, TStep>);

            while (nexts.Length - sortAt > 0)
            {
                var best = _observer.InProgress(nexts[sortAt], new ArraySegment<Node<TFactor, TStep>>(nexts, sortAt, nexts.Length - sortAt)); // nexts.First();

                Debug.WriteLine($"{current.Step}\t{current.Level} -> {best.Step}\t{best.Level}");

                if (NodeComparer.Compare(best, bound) > 0)
                    return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.NotFound, best);

                if (nexts.Length - sortAt < 2)
                    state = Search(best, null, visited);
                else
                    state = Search(best, NodeComparer.Min(nexts[sortAt + 1], bound), visited);

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
}