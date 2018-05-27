using System.Collections.Generic;
using System.Numerics;

namespace LinqToAStar.Test
{
    public class PathToBeTested
    {
        public Vector2 Start { get; private set; }

        public Vector2 Goal { get; private set; }

        public IReadOnlyList<Vector2> Steps { get; private set; }

        public PathToBeTested(Vector2 start, Vector2 goal, IReadOnlyList<Vector2> steps)
        {
            Start = start;
            Goal = goal;
            Steps = steps;
        }
    }
}