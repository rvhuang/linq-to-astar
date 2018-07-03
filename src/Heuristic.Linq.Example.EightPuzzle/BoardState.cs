using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Heuristic.Linq.Example.EightPuzzle
{
    sealed class BoardState : IEquatable<BoardState>
    {
        #region Fields

        public const int BoardSize = 3;

        private readonly Point[] _positions;

        #endregion

        #region Constructor

        public BoardState(Point[] positions)
        {
            _positions = positions;
        }

        #endregion

        #region Methods

        public IEnumerable<BoardState> GetNextSteps()
        {
            if (_positions[0].X > 0)
                yield return CreateNextStep(-1, 0);

            if (_positions[0].Y > 0)
                yield return CreateNextStep(0, -1);

            if (_positions[0].X + 1 < BoardSize)
                yield return CreateNextStep(1, 0);

            if (_positions[0].Y + 1 < BoardSize)
                yield return CreateNextStep(0, 1);
        }

        private BoardState CreateNextStep(int offsetX, int offsetY)
        {
            var array = _positions.ToArray(); // create a copy first
            var empty = new Point(_positions[0].X + offsetX, _positions[0].Y + offsetY);

            Swap(array, 0, Array.IndexOf(array, empty)); // Swap empty square and target square

            return new BoardState(array);
        }

        public bool Equals(BoardState other)
        {
            if (other == null) return false;

            return _positions.SequenceEqual(other._positions);
        }

        public float GetSumOfDistances(BoardState goal)
        {
            return goal._positions.Zip(_positions, PointExtensions.GetManhattanDistance).Sum();
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            var rows = new int[BoardSize][];
            var sb = new StringBuilder();

            for (var r = 0; r < rows.Length; r++)
                rows[r] = new int[BoardSize];

            for (var i = 0; i < _positions.Length; i++)
            {
                var pos = _positions[i];
                rows[pos.Y][pos.X] = i;
            }

            foreach (var row in rows)
                sb.AppendLine(string.Join("\t", row.Select(c => c == 0 ? "_" : Convert.ToString(c))));

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BoardState);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 27;

                for (var i = 0; i < _positions.Length; i++)
                    hash = (13 * hash) + _positions[i].GetHashCode();

                return hash;
            }
        }

        #endregion

        #region Others

        private static void Swap(Point[] array, int indexA, int indexB)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            var temp = array[indexA];

            array[indexA] = array[indexB];
            array[indexB] = temp;
        }

        #endregion
    }
}
