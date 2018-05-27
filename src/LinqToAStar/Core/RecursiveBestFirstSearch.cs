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
        private readonly IComparer<Node<TResult, TStep>> _nodeComparer;

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
            var inits = _source.ConvertToNodes(_source.From, 0).ToArray();

            if (inits.Length == 0)
                return Enumerable.Empty<TResult>().GetEnumerator();

            Array.Sort(inits, _nodeComparer);

            var best = inits[0];
            var state = Search(best, null, new HashSet<TStep>(_source.StepComparer));

            return state.Flag == RecursionFlag.Found ? state.Node.TraceBack().GetEnumerator() : Enumerable.Empty<TResult>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Core

        private RecursionState<TResult, TStep> Search(Node<TResult, TStep> current, Node<TResult, TStep> bound, ISet<TStep> visited)
        {
            visited.Add(current.Step);

            if (_source.StepComparer.Equals(current.Step, _source.To))
                return new RecursionState<TResult, TStep>(RecursionFlag.Found, current);

            var nexts = _source.Expands(current.Step, current.Level, step => !visited.Contains(step)).ToArray();

            if (nexts.Length == 0)
                return new RecursionState<TResult, TStep>(RecursionFlag.NotFound, current);

            Array.ForEach(nexts, next => next.Previous = current);
            Array.Sort(nexts, _nodeComparer);

            var sortAt = 0;
            var state = default(RecursionState<TResult, TStep>);

            while (nexts.Length - sortAt > 0)
            {
                var best = nexts[sortAt]; // nexts.First();

                Debug.WriteLine($"{current.Step}\t{current.Level} -> {best.Step}\t{best.Level}");
                 
                if (_nodeComparer.Compare(best, bound) > 0)
                    return new RecursionState<TResult, TStep>(RecursionFlag.NotFound, best);

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
            return new RecursionState<TResult, TStep>(RecursionFlag.NotFound, null);
        }

        #endregion 
    }
}