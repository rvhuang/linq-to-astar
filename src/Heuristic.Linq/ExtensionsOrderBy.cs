using System;
using System.Collections.Generic;

namespace Heuristic.Linq
{
    public static partial class Extensions
    {
        #region OrderBy

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="Single"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="Double"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="Decimal"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="Byte"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="SByte"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="Int16"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="UInt16"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="Int32"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="UInt32"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="Int64"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <see cref="UInt64"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <typeparamref name="TKey"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <typeparam name="TKey">The return type of heuristic function.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TKey, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new NormalComparer<TFactor, TKey, TStep>(keySelector, null, false));
        }

        /// <summary>
        /// Applies heuristic function to current instance. The return type is <typeparamref name="TKey"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TKey">The return type of heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <param name="comparer">The comparer to compare <typeparamref name="TKey"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderBy<TFactor, TKey, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new NormalComparer<TFactor, TKey, TStep>(keySelector, comparer, false));
        }

        #endregion

        #region OrderByDescending

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="Single"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="Double"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="Decimal"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="Byte"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="SByte"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="Int16"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="UInt16"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="Int32"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="UInt32"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="Int64"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <see cref="UInt64"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new HeuristicComparer<TFactor, TStep>(keySelector, true));
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <typeparamref name="TKey"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <typeparam name="TKey">The return type of heuristic function.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TKey, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, TKey> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        /// <summary>
        /// Applies descending heuristic function to current instance. The return type is <typeparamref name="TKey"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TKey">The return type of heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <param name="comparer">The comparer to compare <typeparamref name="TKey"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> OrderByDescending<TFactor, TKey, TStep>(this HeuristicSearchBase<TFactor, TStep> source, Func<TFactor, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return new HeuristicSearchOrderBy<TFactor, TStep>(source, new NormalComparer<TFactor, TKey, TStep>(keySelector, null, true));
        }

        #endregion

        #region ThenBy

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="Single"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="Double"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="Decimal"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="Byte"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="SByte"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="Int16"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="UInt16"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="Int32"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="UInt32"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="Int64"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <see cref="UInt64"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, false);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <typeparamref name="TKey"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <typeparam name="TKey">The return type of heuristic function.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TKey, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, TKey> keySelector)
        {
            return ThenBy(source, keySelector, null);
        }

        /// <summary>
        /// Applies a subsequent heuristic function to current instance. The return type is <typeparamref name="TKey"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TKey">The return type of heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <param name="comparer">The comparer to compare <typeparamref name="TKey"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenBy<TFactor, TKey, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        #endregion

        #region ThenByDescending

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="Single"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, float> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="Double"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, double> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="Decimal"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, decimal> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="Byte"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, byte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="SByte"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, sbyte> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="Int16"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, short> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="UInt16"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, ushort> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="Int32"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, int> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="UInt32"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, uint> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="Int64"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, long> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <see cref="UInt64"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, ulong> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, true);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <typeparamref name="TKey"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <typeparam name="TKey">The return type of heuristic function.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TKey, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, TKey> keySelector)
        {
            return ThenByDescending(source, keySelector, null);
        }

        /// <summary>
        /// Applies a subsequent descending heuristic function to current instance. The return type is <typeparamref name="TKey"/>.
        /// </summary>
        /// <typeparam name="TFactor">The type of factor used to evaluate with heuristic function. The type is projected from <typeparamref name="TStep"/>.</typeparam>
        /// <typeparam name="TKey">The return type of heuristic function.</typeparam>
        /// <typeparam name="TStep">The type of step of the problem.</typeparam>
        /// <param name="source">The current instance.</param>
        /// <param name="keySelector">The heuristic function to estimate and compare <typeparamref name="TFactor"/>.</param>
        /// <param name="comparer">The comparer to compare <typeparamref name="TKey"/>.</param>
        /// <returns>The instance with applied heuristic function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        public static HeuristicSearchOrderBy<TFactor, TStep> ThenByDescending<TFactor, TKey, TStep>(this HeuristicSearchOrderBy<TFactor, TStep> source, Func<TFactor, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.CreateOrderedEnumerable(keySelector, comparer, true);
        }

        #endregion
    }
}