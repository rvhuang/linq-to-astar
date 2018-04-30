using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqToAStar.Core
{
    internal static class AStar
    {
        #region Override

        public static IEnumerable<TResult> Run<TResult, TStep>(HeuristicSearchBase<TResult, TStep> source)
        {
            var open = new List<Node<TStep, TResult>>(source.ConvertToNodes(source.From, 0));

            if (open.Count == 0)
                return Enumerable.Empty<TResult>();

            open.Sort(source.NodeComparer);

            var closed = new HashSet<TStep>(source.StepComparer);
            var sortAt = 0;

            while (open.Count > 0)
            {
                var current = open[sortAt];
                var hasNext = false;

                if (source.StepComparer.Equals(current.Step, source.To))
                    return current.TraceBack();

                sortAt++; // open.RemoveAt(0);
                closed.Add(current.Step);

                foreach (var next in source.Expands(current.Step, current.Level))
                {
                    if (closed.Contains(next.Step)) continue;
                    if (open.Find(step => source.StepComparer.Equals(next.Step, step.Step)) == null)
                    {
                        Debug.WriteLine($"{current.Step}\t{current.Level} -> {next.Step}\t{next.Level}");

                        next.Previous = current;
                        open.Add(next);
                        hasNext = true;
                    }
                }
                if (hasNext)
                    open.Sort(sortAt, open.Count - sortAt, source.NodeComparer);
            }
            return Enumerable.Empty<TResult>();
        }

        #endregion
    }
}