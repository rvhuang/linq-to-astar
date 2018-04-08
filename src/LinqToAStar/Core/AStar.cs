using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar.Core
{
    internal class AStar<TResult, TStep> : IEnumerable<TResult>
    {
        #region Fields

        private readonly HeuristicSearchBase<TResult, TStep> _source;

        #endregion

        #region Constructor

        internal AStar(HeuristicSearchBase<TResult, TStep> source)  
        {
            _source = source;
        }

        #endregion

        #region Override

        public IEnumerator<TResult> GetEnumerator()
        {            
            var open = new List<Node<TStep, TResult>>(_source.ConvertAnyway(_source.From, 0));
            
            if (open.Count == 0) 
                return Enumerable.Empty<TResult>().GetEnumerator();
            
            open.Sort(_source.NodeComparer);
            
            var closed = new HashSet<TStep>(_source.Comparer);

            while (open.Count > 0)
            {
                var current = open[0];
                var hasNext = false;

                if (_source.Comparer.Equals(current.Step, _source.To))
                    return current.TracesBack().GetEnumerator();
                
                open.RemoveAt(0);
                closed.Add(current.Step);

                foreach (var next in _source.Expands(current.Step, current.Level))
                {
                    if (closed.Contains(next.Step)) continue;
                    if (open.Find(step => _source.Comparer.Equals(next.Step, step.Step)) == null)
                    {
#if DEBUG
                        Console.WriteLine($"{current.Step}\t{current.Level} -> {next.Step}\t{next.Level}");
#endif
                        next.Previous = current;
                        open.Add(next);
                        hasNext = true;
                    }
                }
                if (hasNext) 
                    open.Sort(_source.NodeComparer);
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
