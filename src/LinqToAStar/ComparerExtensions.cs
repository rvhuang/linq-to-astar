using System;
using System.Collections.Generic;

namespace LinqToAStar
{
    static class ComparerExtensions
    {
        public static T Min<T>(this IComparer<T> comparer, T a, T b)
        {
            if (a == null) return b;
            if (b == null) return a;

            return (comparer != null ? comparer : Comparer<T>.Default).Compare(a, b) < 0 ? a : b;
        }

        public static T Max<T>(this IComparer<T> comparer, T a, T b)
        {
            if (a == null) return b;
            if (b == null) return a;

            return (comparer != null ? comparer : Comparer<T>.Default).Compare(a, b) > 0 ? a : b;
        }

        internal static INodeComparer<TResult, TStep> CreateComparer<TResult, TKey, TStep>(Func<TResult, TKey> keySelector, IComparer<TKey> keyComparer, bool descending)
        {
            if (keyComparer != null) return new NormalComparer<TStep, TResult, TKey>(keySelector, keyComparer, descending);

            var comparer = default(INodeComparer<TResult, TStep>);

            switch (Type.GetTypeCode(typeof(TKey)))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    comparer = new HeuristicComparer<TStep, TResult, TKey>(keySelector, descending);
                    break;

                default:
                    comparer = new NormalComparer<TStep, TResult, TKey>(keySelector, null, descending);
                    break;
            }
            return comparer;
        }
    }
}
