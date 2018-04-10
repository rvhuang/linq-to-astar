using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    using Core;

    internal class HeuristicSearchOrderBy<TResult, TStep> : HeuristicSearchBase<TResult, TStep>
    {
        #region Fields

        private ComparerBase<TStep, TResult> _nodeComparer;

        #endregion

        #region Properties

        internal override ComparerBase<TStep, TResult> NodeComparer => _nodeComparer;

        #endregion

        #region Constructors

        internal HeuristicSearchOrderBy(HeuristicSearchBase<TResult, TStep> source, ComparerBase<TStep, TResult> nodeComparer) 
            : base(source)
        {
            _nodeComparer = nodeComparer;
        }
        
        #endregion

        #region Overrides

        public override IEnumerator<TResult> GetEnumerator()
        {
#if DEBUG
            Console.WriteLine($"Searching path between {From} and {To} with {AlgorithmName}...");
#endif
            switch (AlgorithmName)
            {
                case nameof(AStar<TResult, TStep>): 
                    return new AStar<TResult, TStep>(this).GetEnumerator();

                case nameof(BestFirstSearch<TResult, TStep>): 
                    return new BestFirstSearch<TResult, TStep>(this).GetEnumerator();
            }
            return base.GetEnumerator();
        }

        #endregion
    }
}