using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    class HeuristicComparer<TResult, TStep> : INodeComparer<TResult, TStep>
    {
        #region Fields
        
        private readonly Comparison<Node<TResult, TStep>> _comparisonN;
        private readonly Comparison<TResult> _comparisonR;

        #endregion

        #region Properties

        public IComparer<Node<TResult, TStep>> ResultOnlyComparer { get; private set; }

        #endregion

        #region Constructor

        public HeuristicComparer(Func<TResult, byte> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x.Result) + x.Level, 0 - keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x.Result) + x.Level, keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.ByteComparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        public HeuristicComparer(Func<TResult, ushort> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x.Result) + x.Level, 0 - keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x.Result) + x.Level, keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.UInt16Comparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        public HeuristicComparer(Func<TResult, uint> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int64Comparer.Compare(0 - keySelector(x.Result) + x.Level, 0 - keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.Int64Comparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int64Comparer.Compare(keySelector(x.Result) + x.Level, keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.UInt32Comparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        public HeuristicComparer(Func<TResult, ulong> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.UInt64Comparer.Compare(0 - keySelector(x.Result) + (ulong)x.Level, 0 - keySelector(y.Result) + (ulong)y.Level);
                _comparisonR = (x, y) => DistanceHelper.UInt64Comparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.UInt64Comparer.Compare(keySelector(x.Result) + (ulong)x.Level, keySelector(y.Result) + (ulong)y.Level);
                _comparisonR = (x, y) => DistanceHelper.UInt64Comparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        public HeuristicComparer(Func<TResult, sbyte> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x.Result) + x.Level, 0 - keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x.Result) + x.Level, keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.SByteComparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        public HeuristicComparer(Func<TResult, short> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x.Result) + x.Level, 0 - keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x.Result) + x.Level, keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.Int16Comparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        public HeuristicComparer(Func<TResult, int> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x.Result) + x.Level, 0 - keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.Int32Comparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x.Result) + x.Level, keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.Int32Comparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        public HeuristicComparer(Func<TResult, long> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.Int64Comparer.Compare(0 - keySelector(x.Result) + x.Level, 0 - keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.Int64Comparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.Int64Comparer.Compare(keySelector(x.Result) + x.Level, keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.Int64Comparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        public HeuristicComparer(Func<TResult, float> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.SingleComparer.Compare(0 - keySelector(x.Result) + x.Level, 0 - keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.SingleComparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.SingleComparer.Compare(keySelector(x.Result) + x.Level, keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.SingleComparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        public HeuristicComparer(Func<TResult, double> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.DoubleComparer.Compare(0 - keySelector(x.Result) + x.Level, 0 - keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.DoubleComparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.DoubleComparer.Compare(keySelector(x.Result) + x.Level, keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.DoubleComparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        public HeuristicComparer(Func<TResult, decimal> keySelector, bool descending)
        {
            if (descending)
            {
                _comparisonN = (x, y) => DistanceHelper.DecimalComparer.Compare(0 - keySelector(x.Result) + x.Level, 0 - keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.DecimalComparer.Compare(0 - keySelector(x), 0 - keySelector(y));
            }
            else
            {
                _comparisonN = (x, y) => DistanceHelper.DecimalComparer.Compare(keySelector(x.Result) + x.Level, keySelector(y.Result) + y.Level);
                _comparisonR = (x, y) => DistanceHelper.DecimalComparer.Compare(keySelector(x), keySelector(y));
            }
            ResultOnlyComparer = Comparer<Node<TResult, TStep>>.Create(CompareResultOnly);
        }

        #endregion

        #region Methods

        public int Compare(Node<TResult, TStep> x, Node<TResult, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return _comparisonN(x, y);
        }

        public int Compare(TResult x, TResult y)
        {
            return _comparisonR(x, y);
        }

        #endregion

        #region Others

        private int CompareResultOnly(Node<TResult, TStep> x, Node<TResult, TStep> y)
        {
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;

            return _comparisonR(x.Result, y.Result);
        }

        #endregion
    }
}