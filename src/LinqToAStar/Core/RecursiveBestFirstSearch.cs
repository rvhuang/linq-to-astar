using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar.Core
{
    class RecursiveBestFirstSearch<TResult, TStep> : IEnumerable<TResult>
    {
        #region Fields

        private readonly HeuristicSearchBase<TResult, TStep> _source;
        private int _max = 128;

        #endregion

        #region Properties

        public int MaxNumberOfLoops => _max;

        #endregion

        #region Constructor

        internal RecursiveBestFirstSearch(HeuristicSearchBase<TResult, TStep> source)
        {
            _source = source;
        }

        #endregion

        #region Override

        public IEnumerator<TResult> GetEnumerator()
        {
            var inits = _source.ConvertAnyway(_source.From, 0).OrderBy(n => n.Result, _source.NodeComparer).ToArray();
            if (inits.Length == 0) return Enumerable.Empty<TResult>().GetEnumerator();

            var bound = inits[0];
            var state = Search(bound, bound, new HashSet<TStep>(_source.Comparer));

            return state.Node != null ? state.Node.TracesBack().GetEnumerator() : Enumerable.Empty<TResult>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Core

        private RecursionState<TStep, TResult> Search(Node<TStep, TResult> current, Node<TStep, TResult> bound, ISet<TStep> visited)
        {
            if (_source.NodeComparer.Compare(current, bound) > 0)
                return new RecursionState<TStep, TResult>(RecursionFlag.InProgress, current);

            if (_source.Comparer.Equals(current.Step, _source.To))
                return new RecursionState<TStep, TResult>(RecursionFlag.Found, current);

            var nexts = _source.Expands(current.Step, current.Level, visited.Add).ToList();
            if (nexts.Count == 0) return new RecursionState<TStep, TResult>(RecursionFlag.NotFound, null);

            var counter = 0;

            nexts.ForEach(next => next.Previous = current);

            while (counter < _max)
            {
                nexts.Sort(_source.NodeComparer);

                var best = nexts[0];
#if DEBUG
                Console.WriteLine($"{current.Step}\t{current.Level} -> {best.Step}\t{best.Level}");
#endif
                if (_source.NodeComparer.Compare(best, bound) > 0)
                    return new RecursionState<TStep, TResult>(RecursionFlag.InProgress, best);

                var alternative = _source.NodeComparer.Min(nexts.ElementAtOrDefault(1), bound);
                var result = Search(best, alternative, visited);

                if (result.Flag == RecursionFlag.NotFound || result.Flag == RecursionFlag.Found)
                    return result;

                nexts.Add(result.Node);
                counter++;
            }
            return new RecursionState<TStep, TResult>(RecursionFlag.NotFound, null);
        }

        #endregion 
    }
}