using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    internal class DefaultComparer<TStep, TResult> : ComparerBase<TStep, TResult> 
    { 
        #region Constructors

        public DefaultComparer()
            : base(false)
        { 
        }

        #endregion
 
        #region To be implemented

        protected override int OnCompare(Node<TStep, TResult> x, Node<TStep, TResult> y)
        {
            var result = Compare(x.Result, y.Result);

            if (result != 0)
                return result;

            return DistanceHelper.Int32Comparer.Compare(x.Level, y.Level);
        }
 
        #endregion
    }
}