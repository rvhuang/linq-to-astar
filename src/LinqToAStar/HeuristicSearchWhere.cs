using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToAStar
{
    internal class HeuristicSearchWhere<TResult, TStep> : HeuristicSearchBase<TResult, TStep>
    {
        #region Fields

        private readonly Func<TResult, int, bool> _predicate;

        #endregion

        #region Properties

        internal override Func<TStep, int, IEnumerable<TResult>> Converter => Convert; 

        #endregion

        #region Constructors

        internal HeuristicSearchWhere(HeuristicSearchBase<TResult, TStep> source,  Func<TResult, int, bool> predicate) 
            : base(source)
        {
            _predicate = predicate;
        }

        #endregion

        #region Overrides

        public override IEnumerator<TResult> GetEnumerator()
        {
            return Source.AsEnumerable().Where(_predicate).GetEnumerator();
        }

        #endregion

        #region Others

        private IEnumerable<TResult> Convert(TStep step, int level)
        { 
            return Source.Converter(step, level).Where(_predicate);
        }

        #endregion
    }
}