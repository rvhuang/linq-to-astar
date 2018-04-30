using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqToAStar.Core
{
    static class RecursiveBestFirstSearch
    {
        public static IEnumerable<TResult> Run<TResult, TStep>(HeuristicSearchBase<TResult, TStep> source)
        {
            return new RecursiveBestFirstSearch<TResult, TStep>(source);
        }
    }

    class RecursiveBestFirstSearch<TResult, TStep> : IEnumerable<TResult>
    {
        #region Fields

        private readonly HeuristicSearchBase<TResult, TStep> _source;
        private readonly IComparer<Node<TStep, TResult>> _nodeComparer;

        private int _max = 128; 

        #endregion

        #region Properties

        public int MaxNumberOfLoops => _max;

        #endregion

        #region Constructor

        internal RecursiveBestFirstSearch(HeuristicSearchBase<TResult, TStep> source)
        {
            _source = source;
            _nodeComparer = source.NodeComparer.ResultOnlyComparer;
        }

        #endregion

        #region Override

        public IEnumerator<TResult> GetEnumerator()
        {
            var inits = _source.ConvertAnyway(_source.From, 0).ToArray();

            if (inits.Length == 0)
                return Enumerable.Empty<TResult>().GetEnumerator();

            Array.Sort(inits, _nodeComparer);

            var bound = inits[0];
            var state = Search(bound, bound, new HashSet<TStep>(_source.StepComparer));

            return state.Node != null ? state.Node.TraceBack().GetEnumerator() : Enumerable.Empty<TResult>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Core

        private RecursionState<TStep, TResult> Search(Node<TStep, TResult> current, Node<TStep, TResult> bound, ISet<TStep> visited)
        {
            if (_nodeComparer.Compare(current, bound) > 0)
                return new RecursionState<TStep, TResult>(RecursionFlag.InProgress, current);

            if (_source.StepComparer.Equals(current.Step, _source.To))
                return new RecursionState<TStep, TResult>(RecursionFlag.Found, current);

            var nexts = _source.Expands(current.Step, current.Level, visited.Add).ToList();

            if (nexts.Count == 0)
                return new RecursionState<TStep, TResult>(RecursionFlag.NotFound, null);

            nexts.ForEach(next => next.Previous = current);
            nexts.Sort(_nodeComparer);

            var sortAt = 0;
            var state = new RecursionState<TStep, TResult>(RecursionFlag.InProgress, nexts[sortAt]);

            while (nexts.Count > 0 && _nodeComparer.Compare(nexts[sortAt], bound) <= 0)
            {
                var best = nexts[sortAt]; // nexts.First();

                Debug.WriteLine($"{current.Step}\t{current.Level} -> {best.Step}\t{best.Level}");
 
                if (nexts.Count - sortAt < 2)
                    state = Search(best, bound, visited);
                else
                    state = Search(best, _nodeComparer.Min(nexts[sortAt + 1], bound), visited);

                switch (state.Flag)
                {
                    case RecursionFlag.Found:
                        return state;
                    case RecursionFlag.InProgress:
                        nexts.Add(state.Node);
                        nexts.Sort(sortAt, nexts.Count - sortAt, _nodeComparer);
                        break;
                    case RecursionFlag.NotFound:
                        sortAt++; // nexts.RemoveAt(0);
                        break;
                    default:
                        break;
                }
            }
            return nexts.Count > 0 ?
                new RecursionState<TStep, TResult>(RecursionFlag.InProgress, nexts[sortAt]) :
                new RecursionState<TStep, TResult>(RecursionFlag.NotFound, null);
        }

        #endregion 
    }
}