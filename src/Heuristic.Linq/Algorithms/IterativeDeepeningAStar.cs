using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Heuristic.Linq.Algorithms
{
    class IterativeDeepeningAStar : IAlgorithm, IObservableAlgorithm
    {
        public static int MaxNumberOfLoops => 64; // Consider exposing this.

        string IAlgorithm.AlgorithmName => nameof(IterativeDeepeningAStar);

        Node<TFactor, TStep> IAlgorithm.Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            return new IterativeDeepeningAStar<TFactor, TStep>(source).Run();
        }

        Node<TFactor, TStep> IObservableAlgorithm.Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            return new ObservableIterativeDeepeningAStar<TFactor, TStep>(source, observer).Run();
        }

        internal static Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            return new IterativeDeepeningAStar<TFactor, TStep>(source).Run();
        }

        internal static Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer)
        {
            Debug.WriteLine("LINQ Expression Stack: {0}", source);

            return new ObservableIterativeDeepeningAStar<TFactor, TStep>(source, observer).Run();
        }
    }

    abstract class IterativeDeepeningAStarBase<TFactor, TStep>
    {
        #region Properties

        protected HeuristicSearchBase<TFactor, TStep> Source { get; private set; }

        #endregion

        #region Constructor

        internal IterativeDeepeningAStarBase(HeuristicSearchBase<TFactor, TStep> source)
        {
            Source = source;
        }

        #endregion

        #region Methods
        
        public abstract Node<TFactor, TStep> Run();

        protected abstract AlgorithmState<TFactor, TStep> Search(Stack<Node<TFactor, TStep>> path, Node<TFactor, TStep> bound, ISet<TStep> visited);

        protected Stack<Node<TFactor, TStep>> GetInitialStack()
        {
            try
            {
                return new Stack<Node<TFactor, TStep>>(Source.ConvertToNodes(Source.From, 0).OrderBy(n => n.Factor, Source.NodeComparer));
            }
            catch (Exception error)
            {
                throw error.InnerException ?? error;
            }
        }

        #endregion
    }

    class IterativeDeepeningAStar<TFactor, TStep> : IterativeDeepeningAStarBase<TFactor, TStep>
    {
        #region Constructor

        internal IterativeDeepeningAStar(HeuristicSearchBase<TFactor, TStep> source)
            : base(source)
        {
        }

        #endregion

        #region Methods

        public override Node<TFactor, TStep> Run()
        {
            var counter = 0;
            var path = GetInitialStack();
            var bound = path.Peek();

            while (counter <= IterativeDeepeningAStar.MaxNumberOfLoops)
            {
                var t = Search(path, bound, new HashSet<TStep>(Source.StepComparer));

                if (t.Flag == AlgorithmFlag.Found)
                    return t.Node;
                if (t.Flag == AlgorithmFlag.NotFound)
                    return null;

                // In Progress
                bound = t.Node;
                counter++;
            }
            return null;
        }

        protected override AlgorithmState<TFactor, TStep> Search(Stack<Node<TFactor, TStep>> path, Node<TFactor, TStep> bound, ISet<TStep> visited)
        {
            var current = path.Peek();

            if (Source.NodeComparer.Compare(current, bound) > 0)
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.InProgress, current);

            if (Source.StepComparer.Equals(current.Step, Source.To))
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.Found, current);

            var min = default(Node<TFactor, TStep>);
            var hasMin = false;
            var nexts = Source.Expands(current.Step, current.Level, visited.Add).ToArray();

            Array.Sort(nexts, Source.NodeComparer);

            foreach (var next in nexts)
            {
                Debug.WriteLine($"{current.Step}\t{current.Level} -> {next.Step}\t{next.Level}");

                next.Previous = current;
                path.Push(next);

                var t = Search(path, bound, visited);

                if (t.Flag == AlgorithmFlag.Found) return t;
                if (!hasMin || Source.NodeComparer.Compare(t.Node, min) < 0)
                {
                    min = t.Node;
                    hasMin = true;
                }
                path.Pop();
            }
            return new AlgorithmState<TFactor, TStep>(hasMin ? AlgorithmFlag.InProgress : AlgorithmFlag.NotFound, min);
        }

        #endregion 
    }

    class ObservableIterativeDeepeningAStar<TFactor, TStep> : IterativeDeepeningAStarBase<TFactor, TStep>
    {
        #region Fields

        private readonly IProgress<AlgorithmState<TFactor, TStep>> _observer;

        #endregion

        #region Constructor

        internal ObservableIterativeDeepeningAStar(HeuristicSearchBase<TFactor, TStep> source, IProgress<AlgorithmState<TFactor, TStep>> observer)
            : base(source)
        {
            _observer = observer;
        }

        #endregion

        #region Methods

        public override Node<TFactor, TStep> Run()
        {
            var counter = 0;
            var path = GetInitialStack();
            var bound = path.Peek();

            while (counter <= IterativeDeepeningAStar.MaxNumberOfLoops)
            {
                var t = Search(path, bound, new HashSet<TStep>(Source.StepComparer));

                if (t.Flag == AlgorithmFlag.Found)
                    return _observer.ReportAndReturn(t).Node;
                if (t.Flag == AlgorithmFlag.NotFound)
                    return _observer.NotFound();

                // In Progress
                bound = t.Node;
                counter++;
            }
            return _observer.NotFound();
        }

        protected override AlgorithmState<TFactor, TStep> Search(Stack<Node<TFactor, TStep>> path, Node<TFactor, TStep> bound, ISet<TStep> visited)
        {
            /*
             * Important Note: 
             * Only the status AlgorithmFlag.InProgress should be reported from this method
             * because either AlgorithmFlag.Found or AlgorithmFlag.NotFound should only occur once.
             */
            var current = _observer.InProgress(path.Peek(), path);

            if (Source.NodeComparer.Compare(current, bound) > 0)
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.InProgress, current);

            if (Source.StepComparer.Equals(current.Step, Source.To))
                return new AlgorithmState<TFactor, TStep>(AlgorithmFlag.Found, current, path);

            var min = default(Node<TFactor, TStep>);
            var hasMin = false;
            var nexts = Source.Expands(current.Step, current.Level, visited.Add).ToArray();

            Array.Sort(nexts, Source.NodeComparer);

            foreach (var next in nexts)
            {
                Debug.WriteLine($"{current.Step}\t{current.Level} -> {next.Step}\t{next.Level}");

                next.Previous = current;
                path.Push(next);

                var t = Search(path, bound, visited);

                if (t.Flag == AlgorithmFlag.Found) return t;
                if (!hasMin || Source.NodeComparer.Compare(t.Node, min) < 0)
                {
                    min = t.Node;
                    hasMin = true;
                }
                path.Pop();
            }
            return new AlgorithmState<TFactor, TStep>(hasMin ? AlgorithmFlag.InProgress : AlgorithmFlag.NotFound, min);
        }

        #endregion 
    }
}