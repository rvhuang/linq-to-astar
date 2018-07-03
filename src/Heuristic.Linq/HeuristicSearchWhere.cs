using System;
using System.Collections.Generic;
using System.Linq;

namespace Heuristic.Linq
{
    internal class HeuristicSearchWhere<TFactor, TStep> : HeuristicSearchBase<TFactor, TStep>
    {
        #region Fields

        private readonly Func<TFactor, int, bool> _predicate;

        #endregion

        #region Properties

        internal override Func<TStep, int, IEnumerable<TFactor>> Converter => Convert;

        #endregion

        #region Constructors

        internal HeuristicSearchWhere(HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, int, bool> predicate)
            : base(source)
        {
            _predicate = predicate;
        }

        #endregion

        #region Others

        private IEnumerable<TFactor> Convert(TStep step, int level)
        {
            return Source.Converter(step, level).Where(_predicate);
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