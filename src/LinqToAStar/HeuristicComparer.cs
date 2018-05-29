using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    class HeuristicComparer<TFactor, TStep> : INodeComparer<TFactor, TStep>
    {
        #region Fields

        private readonly Comparison<Node<TFactor, TStep>> _comparisonN;
        private readonly Comparison<TFactor> _comparisonF;

        #endregion

        #region Properties

        public IComparer<Node<TFactor, TStep>> FactorOnlyComparer { get; private set; }

        #endregion

        #region Constructor

        public HeuristicComparer(Func<TFactor, byte> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x.Factor) + x.Level, 0 - keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.ByteComparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x.Factor) + x.Level, keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.ByteComparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        public HeuristicComparer(Func<TFactor, ushort> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x.Factor) + x.Level, 0 - keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.UInt16Comparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x.Factor) + x.Level, keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.UInt16Comparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        public HeuristicComparer(Func<TFactor, uint> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int64Comparer.Compare(0 - keySelector(x.Factor) + x.Level, 0 - keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.UInt32Comparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int64Comparer.Compare(keySelector(x.Factor) + x.Level, keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.UInt32Comparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        public HeuristicComparer(Func<TFactor, ulong> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.UInt64Comparer.Compare(0 - keySelector(x.Factor) + (ulong)x.Level, 0 - keySelector(y.Factor) + (ulong)y.Level);
                _comparisonF = (x, y) => DistanceHelper.UInt64Comparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.UInt64Comparer.Compare(keySelector(x.Factor) + (ulong)x.Level, keySelector(y.Factor) + (ulong)y.Level);
                _comparisonF = (x, y) => DistanceHelper.UInt64Comparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        public HeuristicComparer(Func<TFactor, sbyte> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x.Factor) + x.Level, 0 - keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.SByteComparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x.Factor) + x.Level, keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.SByteComparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        public HeuristicComparer(Func<TFactor, short> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x.Factor) + x.Level, 0 - keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.Int16Comparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x.Factor) + x.Level, keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.Int16Comparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        public HeuristicComparer(Func<TFactor, int> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x.Factor) + x.Level, 0 - keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x.Factor) + x.Level, keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        public HeuristicComparer(Func<TFactor, long> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int64Comparer.Compare(0 - keySelector(x.Factor) + x.Level, 0 - keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.Int64Comparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int64Comparer.Compare(keySelector(x.Factor) + x.Level, keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.Int64Comparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        public HeuristicComparer(Func<TFactor, float> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.SingleComparer.Compare(0 - keySelector(x.Factor) + x.Level, 0 - keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.SingleComparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.SingleComparer.Compare(keySelector(x.Factor) + x.Level, keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.SingleComparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        public HeuristicComparer(Func<TFactor, double> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.DoubleComparer.Compare(0 - keySelector(x.Factor) + x.Level, 0 - keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.DoubleComparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.DoubleComparer.Compare(keySelector(x.Factor) + x.Level, keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.DoubleComparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        public HeuristicComparer(Func<TFactor, decimal> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.DecimalComparer.Compare(0 - keySelector(x.Factor) + x.Level, 0 - keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.DecimalComparer.Compare(keySelector(y), keySelector(x));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.DecimalComparer.Compare(keySelector(x.Factor) + x.Level, keySelector(y.Factor) + y.Level);
                _comparisonF = (x, y) => DistanceHelper.DecimalComparer.Compare(keySelector(x), keySelector(y));
            }
            FactorOnlyComparer = Comparer<Node<TFactor, TStep>>.Create(CompareFactorOnly);
        }

        #endregion

        #region Methods

        public int Compare(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return _comparisonN(x, y);
        }

        public int Compare(TFactor x, TFactor y)
        {
            return _comparisonF(x, y);
        }

        #endregion

        #region Others

        private int CompareFactorOnly(Node<TFactor, TStep> x, Node<TFactor, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return _comparisonF(x.Factor, y.Factor);
        }

        #endregion
    }
}