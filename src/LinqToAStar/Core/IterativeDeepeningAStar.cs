using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar.Core
{
    internal class IterativeDeepeningAStar<TResult, TStep> : IEnumerable<TResult>
    {
        #region Fields

        private readonly HeuristicSearchBase<TResult, TStep> _source;
        private int _max = 1024;

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
            var bound = _source.ConvertAnyway(_source.From, 0).OrderBy(n => n.Result, _source.NodeComparer).First();
            
            while (counter <= _max)
            {
                var t = Search(bound, bound, new HashSet<TStep>(_source.Comparer));

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

        private RecursionState<TStep, TResult> Search(Node<TStep, TResult> current, Node<TStep, TResult> bound, ISet<TStep> visited)
        {
            if (_source.NodeComparer.Compare(current, bound) > 0)
                return new RecursionState<TStep, TResult>(RecursionFlag.InProgress, current);

            if (_source.Comparer.Equals(current.Step, _source.To)) 
                return new RecursionState<TStep, TResult>(RecursionFlag.Found, current); 

            var min = default(Node<TStep, TResult>);
            var hasMin = false;
            
            foreach (var next in _source.Expands(current.Step, current.Level, visited.Add))
            {
#if DEBUG
                Console.WriteLine($"{current.Step}\t{current.Level} -> {next.Step}\t{next.Level}");
#endif
                next.Previous = current;

                var t = Search(next, bound, visited);

                if (t.Flag == RecursionFlag.Found) return t;
                if (t.Flag == RecursionFlag.NotFound) continue;
                if (!hasMin || _source.NodeComparer.Compare(t.Node, min) < 0)
                {
                    min = t.Node;
                    hasMin = true;
                }
            }
            return new RecursionState<TStep, TResult>(hasMin ? RecursionFlag.InProgress : RecursionFlag.NotFound, min);
        }

        #endregion 
    }
}