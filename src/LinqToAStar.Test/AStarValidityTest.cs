using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace LinqToAStar.Example
{
    public class AStarValidityTest
    {
        private readonly IReadOnlyList<Vector2> _path;
        private readonly float _unit;
        private readonly Vector2 _start;
        private readonly Vector2 _goal;

        public AStarValidityTest()
        {
            var start = new Vector2(5, 35);
            var goal = new Vector2(35, 5);
            var unit = 1f;
            var astar = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var queryable = from step in astar.Except(GetObstacles())
                            where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                            orderby step.GetManhattanDistance(goal)
                            select step;

            _path = queryable.ToList();
            _unit = unit;
            _start = start;
            _goal = goal;
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