using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
            var nexts = new List<Node<TStep, TResult>>(_source.ConvertAnyway(_source.From, 0));

            if (nexts.Count == 0)
                return Enumerable.Empty<TResult>().GetEnumerator();

            var visited = new HashSet<TStep>(_source.StepComparer);

            while (nexts.Count > 0)
            {
                var best = nexts.First();
                var hasNext = false;

                if (_source.StepComparer.Equals(best.Step, _source.To))
                    return best.TraceBack().GetEnumerator();

                nexts.RemoveAt(0);

                foreach (var next in _source.Expands(best.Step, best.Level, visited.Add))
                {
                    Debug.WriteLine($"{best.Step}\t{best.Level} -> {next.Step}\t{next.Level}");

                    next.Previous = best;
                    nexts.Add(next);
                    hasNext = true;
                }
                if (hasNext)
                    nexts.Sort(_source.NodeComparer.ResultOnlyComparer);
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