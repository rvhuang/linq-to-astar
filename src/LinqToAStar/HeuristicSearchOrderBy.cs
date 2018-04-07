using System.Collections.Generic;

namespace LinqToAStar
{
    using Core;

    internal class HeuristicSearchOrderBy<TResult, TStep> : HeuristicSearchBase<TResult, TStep>
    {
        #region Fields

        private IComparer<Node<TStep, TResult>> _nodeComparer;

        #endregion

        #region Properties

        internal override IComparer<Node<TStep, TResult>> NodeComparer => _nodeComparer;

        #endregion

        #region Constructors

        internal HeuristicSearchOrderBy(HeuristicSearchBase<TResult, TStep> source, IComparer<Node<TStep, TResult>> nodeComparer) 
            : base(source)
        {
            _nodeComparer = nodeComparer;
        }
        
        #endregion

        #region Overrides

        public override IEnumerator<TResult> GetEnumerator()
        {
            switch (AlgorithmName)
            {
                case nameof(AStar<TResult, TStep>): 
                    return new AStar<TResult, TStep>(this).GetEnumerator();
            }
            return base.GetEnumerator();
        }

        #endregion
    }
}