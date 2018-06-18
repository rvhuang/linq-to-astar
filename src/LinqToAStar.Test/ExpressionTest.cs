using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Xunit;

namespace LinqToAStar.Test
{
    public class ExpressionTest
    {
        private readonly Point start = new Point(2, 2);
        private readonly Point goal = new Point(18, 18);
        private readonly Rectangle boundary = new Rectangle(0, 0, 20, 20);        
        private const int unit = 1;

        [Fact]
        public void LetTest()
        {
            var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var solution = from step in queryable.Contains(boundary.GetAvailablePoints(unit))
                           let m = step.GetManhattanDistance(goal)
                           let e = step.GetChebyshevDistance(goal)
                           orderby m, e
                           select step;
            var actual = solution.ToArray();

            Assert.Equal(actual.First(), queryable.From);
            Assert.Equal(actual.Last(), queryable.To);
        }

        [Fact]
        public void ContainsTest()
        {
            var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var solution = from step in queryable.Contains(boundary.GetAvailablePoints(unit))
                           orderby step.GetManhattanDistance(goal)
                           select step;
            var actual = solution.ToArray();

            Assert.Equal(actual.First(), queryable.From);
            Assert.Equal(actual.Last(), queryable.To);
        }

        [Fact]
        public void ReverseFromInsideTest()
        {
            var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var solution = from step in queryable.Reverse()
                           where boundary.Contains(step)
                           orderby step.GetManhattanDistance(goal)
                           select step;
            var actual = solution.ToArray();

            Assert.Equal(actual.First(), queryable.To);
            Assert.Equal(actual.Last(), queryable.From);
        }

        [Fact]
        public void ReverseFromOutsideTest()
        {
            var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var solution = from step in queryable
                           where boundary.Contains(step)
                           orderby step.GetManhattanDistance(goal)
                           select step;
            var actual = solution.Reverse().ToArray();

            Assert.Equal(actual.First(), queryable.To);
            Assert.Equal(actual.Last(), queryable.From);
        }

        [Fact]
        public void OrderByThenByComparerTest()
        {
            var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var solution = from step in queryable
                           where boundary.Contains(step)
                           orderby step.GetManhattanDistance(goal), step.GetEuclideanDistance(goal)
                           select step;
            var actual = solution.ToArray();

            Assert.IsType<CombinedComparer<Point, Point>>(solution.NodeComparer);
            Assert.Equal(actual.First(), queryable.From);
            Assert.Equal(actual.Last(), queryable.To);
        }
    }
}