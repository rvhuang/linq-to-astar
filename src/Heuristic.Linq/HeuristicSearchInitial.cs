using System;
using System.Collections.Generic;
using System.Linq;

namespace Heuristic.Linq
{
    internal class HeuristicSearchInitial<TStep> : HeuristicSearchBase<TStep, TStep>
    {
        #region Fields

        public static readonly Func<TStep, int, IEnumerable<TStep>> EmptyConverter = (s, t) => Enumerable.Repeat(s, 1);

        #endregion

        #region Constructors

        internal HeuristicSearchInitial(string algorithmName, TStep from, TStep to, IEqualityComparer<TStep> comparer, Func<TStep, int, IEnumerable<TStep>> expander)
            : base(algorithmName, from, to, comparer, null, EmptyConverter, expander)
        {
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return string.Join(" -> ", Source == null ? "(Initial)" : Source.ToString(), base.ToString());
        }

        #endregion
    }
}