using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqToAStar.Core
{
    static class IterativeDeepeningAStar
    {
        public static IEnumerable<TResult> Run<TResult, TStep>(HeuristicSearchBase<TResult, TStep> source)
        {
            return new IterativeDeepeningAStar<TResult, TStep>(source);
        }
    }

    internal class IterativeDeepeningAStar<TResult, TStep> : IEnumerable<TResult>
    {
        #region Fields

        private readonly HeuristicSearchBase<TResult, TStep> _source;
        private readonly int _max = 1024;

        #endregion

        #region Properties

        public int MaxNumberOfLoops => _max;

        #endregion

        #region Constructor

        internal IterativeDeepeningAStar(HeuristicSearchBase<TResult, TStep> source)
        {
            _source = source;
        }

        #endregion

        #region Override

        public IEnumerator<TResult> GetEnumerator()
        {
            var counter = 0;
            var path = new Stack<Node<TStep, TResult>>(_source.ConvertAnyway(_source.From, 0).OrderBy(n => n.Result, _source.NodeComparer));
            var bound = path.Peek();

            while (counter <= _max)
            {
                var t = Search(path, bound, new HashSet<TStep>(_source.StepComparer));

                if (t.Flag == RecursionFlag.Found)
                    return t.Node.TraceBack().GetEnumerator();
                if (t.Flag == RecursionFlag.NotFound)
                    return Enumerable.Empty<TResult>().GetEnumerator();

                // In Progress
                bound = t.Node;
                counter++;
            }
            return Enumerable.Empty<TResult>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Core

        private RecursionState<TStep, TResult> Search(Stack<Node<TStep, TResult>> path, Node<TStep, TResult> bound, ISet<TStep> visited)
        {
            var current = path.Peek();

            if (_source.NodeComparer.Compare(current, bound) > 0)
                return new RecursionState<TStep, TResult>(RecursionFlag.InProgress, current);

            if (_source.StepComparer.Equals(current.Step, _source.To))
                return new RecursionState<TStep, TResult>(RecursionFlag.Found, current);

            var min = default(Node<TStep, TResult>);
            var hasMin = false;
            var nexts = _source.Expands(current.Step, current.Level, visited.Add).ToArray();

            Array.Sort(nexts, _source.NodeComparer);

            foreach (var next in nexts)
            {
                Debug.WriteLine($"{current.Step}\t{current.Level} -> {next.Step}\t{next.Level}");

                next.Previous = current;
                path.Push(next);

                var t = Search(path, bound, visited);

                if (t.Flag == RecursionFlag.Found) return t; 
                if (!hasMin || _source.NodeComparer.Compare(t.Node, min) < 0)
                {
                    min = t.Node;
                    hasMin = true;
                }
                path.Pop();
            }
            return new RecursionState<TStep, TResult>(hasMin ? RecursionFlag.InProgress : RecursionFlag.NotFound, min);
        }

        #endregion 
    }
}