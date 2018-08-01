using System;
using System.Drawing;
using System.Linq;
using Xunit;

namespace Heuristic.Linq.Test
{

    public class ExceptionTest
    {
        private readonly Point start = new Point(2, 2);
        private readonly Point goal = new Point(18, 18);
        private readonly Rectangle boundary = new Rectangle(0, 0, 20, 20);
        private const int unit = 1;

        [Fact]
        public void AStarWithoutOrderByTest()
        {
            var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var obstacles = new[] { new Point(5, 5), new Point(6, 6), new Point(7, 7), new Point(8, 8), new Point(9, 9) };
            var solution = from step in queryable
                           from obstacle in obstacles
                           where step != obstacle
                           select step;
            var actual = solution.ToList();

            Assert.Equal(actual.First(), queryable.From);
            Assert.Equal(actual.Last(), queryable.To);
        }

        [Fact]
        public void IDAStarWithoutOrderByTest()
        {
            var queryable = HeuristicSearch.IterativeDeepeningAStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var obstacles = new[] { new Point(5, 5), new Point(6, 6), new Point(7, 7), new Point(8, 8), new Point(9, 9) };
            var solution = from step in queryable
                           from obstacle in obstacles
                           where step != obstacle
                           select step;
            var exception = Assert.Throws<InvalidOperationException>(() => solution.ToList());

            Assert.StartsWith("Unable to evaluate steps.", exception.Message);
        }

        [Fact]
        public void BFSWithoutOrderByTest()
        {
            var queryable = HeuristicSearch.BestFirstSearch(start, goal, (step, lv) => step.GetFourDirections(unit));
            var obstacles = new[] { new Point(5, 5), new Point(6, 6), new Point(7, 7), new Point(8, 8), new Point(9, 9) };
            var solution = from step in queryable
                           from obstacle in obstacles
                           where step != obstacle
                           select step;

            var exception = Assert.Throws<InvalidOperationException>(() => solution.ToList());

            Assert.StartsWith("Unable to evaluate steps.", exception.Message);
        }

        [Fact]
        public void RBFSWithoutOrderByTest()
        {
            var queryable = HeuristicSearch.RecursiveBestFirstSearch(start, goal, (step, lv) => step.GetFourDirections(unit));
            var obstacles = new[] { new Point(5, 5), new Point(6, 6), new Point(7, 7), new Point(8, 8), new Point(9, 9) };
            var solution = from step in queryable
                           from obstacle in obstacles
                           where step != obstacle
                           select step;

            var exception = Assert.Throws<InvalidOperationException>(() => solution.ToList());

            Assert.StartsWith("Unable to evaluate steps.", exception.Message);
        }
    }
}