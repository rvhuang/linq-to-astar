using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace LinqToAStar.Test
{
    public class RecursiveBestFirstSearchValidityTest
    {
        private readonly IReadOnlyList<Vector2> _path;
        private readonly float _unit;
        private readonly Vector2 _start;
        private readonly Vector2 _goal;

        public RecursiveBestFirstSearchValidityTest()
        {
            var mapData = TestHelper.LoadMapData();

            _start = mapData.Start;
            _goal = mapData.Goal;
            _unit = 1f;

            var queryable = HeuristicSearch.RecursiveBestFirstSearch(_start, _goal, (step, lv) => step.GetFourDirections(_unit));
            var solution = from step in queryable.Except(mapData.Obstacles)
                           where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                           orderby step.GetManhattanDistance(_goal)
                           select step;

            _path = solution.ToList();
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
    }
}