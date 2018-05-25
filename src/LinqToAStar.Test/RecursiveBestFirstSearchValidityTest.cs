using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace LinqToAStar.Test
{
    public class RecursiveBestFirstSearchValidityTest
    {
        [Theory]
        [ClassData(typeof(RBFSTestData))]
        public void StartAndGoalTest(Vector2 start, Vector2 goal, IReadOnlyList<Vector2> solution)
        {
            Assert.True(start == solution.First(), "First step is not equal to start.");
            Assert.True(goal == solution.Last(), "Last step is not equal to goal.");
        }

        [Theory]
        [ClassData(typeof(RBFSTestData))]
        public void PathValidityTest(Vector2 start, Vector2 goal, IReadOnlyList<Vector2> solution)
        {
            var differences = solution.Skip(1).Select((step, i) => step - solution[i]);

            Assert.True(differences.All(diff => Math.Abs(diff.X) == MapDataFixture.Unit ^ Math.Abs(diff.Y) == MapDataFixture.Unit), "One or more invalid steps are found.");
        }

        [Theory]
        [ClassData(typeof(RBFSTestData))]
        public void ObstacleTest(Vector2 start, Vector2 goal, IReadOnlyList<Vector2> solution)
        {
            Assert.DoesNotContain(solution, MapDataFixture._obstacles.Contains);
        }
    }
}