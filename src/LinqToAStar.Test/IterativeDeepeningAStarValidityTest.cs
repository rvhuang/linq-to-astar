using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace LinqToAStar.Test
{
    public class IterativeDeepeningAStarValidityTest
    {
        private readonly IReadOnlyList<Vector2> _path;
        private readonly float _unit = 1f;
        private readonly Vector2 _start = new Vector2(5, 35);
        private readonly Vector2 _goal = new Vector2(35, 5);

        public IterativeDeepeningAStarValidityTest()
        {
            _start = new Vector2(5, 35);
            _goal = new Vector2(35, 5);
            _unit = 1f;

            var astar = HeuristicSearch.IterativeDeepeningAStar(_start, _goal, (step, lv) => step.GetFourDirections(_unit));
            var queryable = from step in astar.Except(GetObstacles())
                            where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                            orderby step.GetManhattanDistance(_goal)
                            select step;

            _path = queryable.ToList();
        }

        [Fact]
        public void StartAndGoalTest()
        {
            Assert.True(_start == _path.First(), "First step is not equal to start.");
            Assert.True(_goal == _path.Last(), "Last step is not equal to goal.");
        }

        [Fact]
        public void PathValidityTest()
        {
            var differences = _path.Skip(1).Select((step, i) => step - _path[i]);

            Assert.True(differences.All(diff => Math.Abs(diff.X) == _unit ^ Math.Abs(diff.Y) == _unit), "One or more invalid steps are found.");
        }

        static IEnumerable<Vector2> GetObstacles()
        {
            yield return new Vector2(15, 10);
            yield return new Vector2(16, 10);
            yield return new Vector2(17, 10);
            yield return new Vector2(18, 10);
            yield return new Vector2(19, 10);
            yield return new Vector2(10, 11);
            yield return new Vector2(11, 11);
            yield return new Vector2(12, 11);
            yield return new Vector2(13, 11);
            yield return new Vector2(14, 11);
            yield return new Vector2(15, 11);
        }
    }
}