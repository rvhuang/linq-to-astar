using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar
{
    internal class HeuristicSearchInitial<TStep> : HeuristicSearchBase<TStep, TStep>
    {
        #region Fields

        public static readonly Func<TStep, int, IEnumerable<TStep>> EmptyConverter = (s, t) => Enumerable.Repeat(s, 1);

        private readonly string _algorithmName = string.Empty;

        #endregion

        #region Properties

        public override string AlgorithmName => _algorithmName;

        #endregion

        #region Constructors
        
        internal HeuristicSearchInitial(string algorithmName, TStep from, TStep to, IEqualityComparer<TStep> comparer, Func<TStep, int, IEnumerable<TStep>> expander) 
            : base(from, to, comparer, EmptyConverter, expander)
        {
            _algorithmName = algorithmName;
        }

        #endregion
    }
}