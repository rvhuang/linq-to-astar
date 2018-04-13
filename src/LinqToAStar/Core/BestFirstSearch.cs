using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar.Core
{
    internal class BestFirstSearch<TResult, TStep> : IEnumerable<TResult>
    {
        #region Fields

        private readonly HeuristicSearchBase<TResult, TStep> _source;

        #endregion

        #region Constructor

        internal BestFirstSearch(HeuristicSearchBase<TResult, TStep> source)
        {
            _source = source;
        }

        #endregion

        #region Override

        public IEnumerator<TResult> GetEnumerator()
        {
            var nextSteps = new List<Node<TStep, TResult>>(_source.ConvertAnyway(_source.From, 0));

            if (nextSteps.Count == 0)
                return Enumerable.Empty<TResult>().GetEnumerator();

            var visited = new HashSet<TStep>(_source.Comparer);

            while (nextSteps.Count > 0)
            {
                var best = nextSteps.First();
                var hasNext = false;

                if (_source.Comparer.Equals(best.Step, _source.To))
                    return best.TracesBack().GetEnumerator();

                nextSteps.RemoveAt(0);

                foreach (var next in _source.Expands(best.Step, best.Level, visited.Add))
                {
#if DEBUG
                    Console.WriteLine($"{best.Step}\t{best.Level} -> {next.Step}\t{next.Level}");
#endif
                    next.Previous = best;
                    nextSteps.Add(next);
                    hasNext = true;
                }
                if (hasNext)
                    nextSteps.Sort(_source.NodeComparer.CompareResultOnly);
            }
            return Enumerable.Empty<TResult>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}