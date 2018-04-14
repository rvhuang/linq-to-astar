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
                var t = Search(bound, bound, new RecursionState<TResult, TStep>(_source));

                if (t.Flag == RecursionFlag.Found) 
                    return t.Node.TracesBack().GetEnumerator();
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

        private RecursionResult<TStep, TResult> Search(Node<TStep, TResult> node, Node<TStep, TResult> bound, RecursionState<TResult, TStep> state)
        {
            if (_source.NodeComparer.Compare(node, bound) > 0)
                return new RecursionResult<TStep, TResult>(RecursionFlag.InProgress, node);

            if (_source.Comparer.Equals(node.Step, _source.To)) 
                return new RecursionResult<TStep, TResult>(RecursionFlag.Found, node); 

            var min = default(Node<TStep, TResult>);
            var hasMin = false;
            
            foreach (var next in _source.Expands(node.Step, node.Level, state.Visited.Add))
            {
                next.Previous = node;

                var t = Search(next, bound, state);

                if (t.Flag == RecursionFlag.Found) return t;
                if (t.Flag == RecursionFlag.NotFound) continue;
                if (!hasMin || _source.NodeComparer.Compare(t.Node, min) < 0)
                {
                    min = t.Node;
                    hasMin = true;
                }
            }
            return new RecursionResult<TStep, TResult>(hasMin ? RecursionFlag.InProgress : RecursionFlag.NotFound, min);
        }

        #endregion 
    }
}