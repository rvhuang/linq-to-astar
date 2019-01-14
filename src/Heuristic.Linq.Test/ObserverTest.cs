using Moq;
using System;
using System.Drawing;
using System.Linq;
using Xunit;

namespace Heuristic.Linq.Test
{
    using Algorithms;
    using System.Diagnostics;

    public class ObserverTest
    {
        private readonly Point start = new Point(0, 0);
        private readonly Point goal = new Point(10, 10);
        private readonly Rectangle boundary = new Rectangle(0, 0, 20, 20);
        private const int unit = 1;

        [Theory]
        [InlineData(nameof(AStar))]
        [InlineData(nameof(BestFirstSearch))]
        [InlineData(nameof(IterativeDeepeningAStar))]
        [InlineData(nameof(RecursiveBestFirstSearch))]
        public void TestIProgressOnlyCreatedOnce(string algorithmName)
        {
            var factory = new Mock<IAlgorithmObserverFactory<Point>>();
            var progress = new Progress<AlgorithmState<Point, Point>>();

            progress.ProgressChanged += (o, e) => Debug.WriteLine("{0}\t{1} ({2})", e.Node.Step, e.Node.Level, nameof(progress.ProgressChanged));
            factory.Setup(f => f.Create(It.IsAny<HeuristicSearchBase<Point, Point>>())).Returns(() => progress);

            var queryable = HeuristicSearch.Use(algorithmName, start, goal, (step, lv) => step.GetFourDirections(unit), null, factory.Object);
            var obstacles = new[] { new Point(5, 5), new Point(6, 6), new Point(7, 7), new Point(8, 8), new Point(9, 9) };
            var solution = from step in queryable
                           where !obstacles.Contains(step)
                           orderby step.GetManhattanDistance(goal)
                           select step;
            var list = solution.ToList();

            factory.Verify(f => f.Create(It.IsAny<HeuristicSearchBase<Point, Point>>()), Times.Once);
        }

        [Theory]
        [InlineData(nameof(AStar))]
        [InlineData(nameof(BestFirstSearch))]
        [InlineData(nameof(IterativeDeepeningAStar))]
        [InlineData(nameof(RecursiveBestFirstSearch))]
        public void TestLastFlagFound(string algorithmName)
        {
            var factory = new Mock<IAlgorithmObserverFactory<Point>>();
            var progress = new Mock<IProgress<AlgorithmState<Point, Point>>>();
            var actual = default(AlgorithmFlag?);
            var expected = (AlgorithmFlag?)AlgorithmFlag.Found;

            factory.Setup(f => f.Create(It.IsAny<HeuristicSearchBase<Point, Point>>())).Returns(() => progress.Object);
            progress.Setup(p => p.Report(It.IsAny<AlgorithmState<Point, Point>>())).Callback<AlgorithmState<Point, Point>>(s => actual = s.Flag);

            var queryable = HeuristicSearch.Use(algorithmName, start, goal, (step, lv) => step.GetFourDirections(unit), null, factory.Object);
            var obstacles = new[] { new Point(5, 5), new Point(6, 6), new Point(7, 7), new Point(8, 8), new Point(9, 9) };
            var solution = from step in queryable.Except(obstacles)
                           where boundary.Contains(step)
                           orderby step.GetManhattanDistance(goal)
                           select step;

            Assert.NotEmpty(solution);
            Assert.Equal(expected, actual);

            progress.Verify(p => p.Report(It.Is<AlgorithmState<Point, Point>>(s => s.Flag == AlgorithmFlag.InProgress)), Times.AtLeastOnce);
            progress.Verify(p => p.Report(It.Is<AlgorithmState<Point, Point>>(s => s.Flag == expected)), Times.Once);
        }

        [Theory]
        [InlineData(nameof(AStar))]
        [InlineData(nameof(BestFirstSearch))]
        [InlineData(nameof(IterativeDeepeningAStar))]
        [InlineData(nameof(RecursiveBestFirstSearch))]
        public void TestLastFlagNotFound(string algorithmName)
        {
            var factory = new Mock<IAlgorithmObserverFactory<Point>>();
            var progress = new Mock<IProgress<AlgorithmState<Point, Point>>>();
            var actual = default(AlgorithmFlag?);
            var expected = (AlgorithmFlag?)AlgorithmFlag.NotFound;

            factory.Setup(f => f.Create(It.IsAny<HeuristicSearchBase<Point, Point>>())).Returns(() => progress.Object);
            progress.Setup(p => p.Report(It.IsAny<AlgorithmState<Point, Point>>())).Callback<AlgorithmState<Point, Point>>(s => actual = s.Flag);

            var queryable = HeuristicSearch.Use(algorithmName, start, goal, (step, lv) => step.GetFourDirections(unit), null, factory.Object);
            var obstacleX = start.X + (start.X + goal.X) / 2;
            var obstacles = from y in Enumerable.Range(0, boundary.Height + 1)
                            select new Point(obstacleX, y); // Build a wall that cannot be bypassed in the middle of start and goal.
            var solution = from step in queryable.Except(obstacles)
                           where boundary.Contains(step)
                           orderby step.GetManhattanDistance(goal)
                           select step;

            Assert.Empty(solution);
            Assert.Equal(expected, actual);

            progress.Verify(p => p.Report(It.Is<AlgorithmState<Point, Point>>(s => s.Flag == AlgorithmFlag.InProgress)), Times.AtLeastOnce);
            progress.Verify(p => p.Report(It.Is<AlgorithmState<Point, Point>>(s => s.Flag == expected)), Times.Once);
        }
    }
}