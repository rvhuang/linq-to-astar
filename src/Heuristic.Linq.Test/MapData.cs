using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Heuristic.Linq.Test
{
    using Algorithms;
    using System.Diagnostics;

    public static class MapData
    {
        public const float Unit = 1f;

        public static readonly ICollection<Vector2> Starts;
        public static readonly ICollection<Vector2> Goals;
        public static readonly ICollection<Vector2> Obstacles;

        static MapData()
        {
            var mapData = TestHelper.LoadMapData();

            Obstacles = mapData.Obstacles;
            Starts = mapData.Starts;
            Goals = mapData.Goals;
        }

        public static IEnumerable<(Vector2 Start, Vector2 Goal)> GetStartGoalCombinations()
        {
            // Combination of all start-goal pairs 
            return from start in Starts
                   from goal in Goals
                   select ValueTuple.Create(start, goal);
        }
    }

    public abstract class TestData : IEnumerable<object[]>
    {
        public abstract string AlgorithmName { get; }

        public abstract IAlgorithmObserverFactory<Vector2> AlgorithmObserverFactory { get; }

        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var setting in MapData.GetStartGoalCombinations())
            {
                var start = setting.Start;
                var goal = setting.Goal;
                var queryable = HeuristicSearch.Use(AlgorithmName, start, goal, (step, lv) => step.GetFourDirections(MapData.Unit), null, AlgorithmObserverFactory);
                var solution = from step in queryable.Except(MapData.Obstacles)
                               where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                               orderby step.GetManhattanDistance(goal)
                               select step;

                yield return new object[] { start, goal, solution.ToArray() };
            }
        }

        protected static IAlgorithmObserverFactory<Vector2> MockObserverFactory()
        {
            var factory = new Mock<IAlgorithmObserverFactory<Vector2>>();
            var progress = new Mock<IProgress<AlgorithmState<Vector2, Vector2>>>();

            factory.Setup(f => f.Create(It.IsAny<HeuristicSearchBase<Vector2, Vector2>>())).Returns(() => progress.Object);
            progress.Setup(p => p.Report(It.IsAny<AlgorithmState<Vector2, Vector2>>())).Callback<AlgorithmState<Vector2, Vector2>>(s => Debug.WriteLine(s.Node));

            return factory.Object;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class AStarTestData : TestData
    {
        public override string AlgorithmName => nameof(HeuristicSearch.AStar);

        public override IAlgorithmObserverFactory<Vector2> AlgorithmObserverFactory => null;
    }

    public class AStarObserverTestData : TestData
    {
        public override string AlgorithmName => nameof(HeuristicSearch.AStar);

        public override IAlgorithmObserverFactory<Vector2> AlgorithmObserverFactory => MockObserverFactory();
    }

    public class BFSTestData : TestData
    {
        public override string AlgorithmName => nameof(HeuristicSearch.BestFirstSearch);

        public override IAlgorithmObserverFactory<Vector2> AlgorithmObserverFactory => null;
    }

    public class BFSObserverTestData : TestData
    {
        public override string AlgorithmName => nameof(HeuristicSearch.BestFirstSearch);

        public override IAlgorithmObserverFactory<Vector2> AlgorithmObserverFactory => MockObserverFactory();
    }

    public class IDATestData : TestData
    {
        public override string AlgorithmName => nameof(HeuristicSearch.IterativeDeepeningAStar);

        public override IAlgorithmObserverFactory<Vector2> AlgorithmObserverFactory => null;
    }

    public class IDAObserverTestData : TestData
    {
        public override string AlgorithmName => nameof(HeuristicSearch.IterativeDeepeningAStar);

        public override IAlgorithmObserverFactory<Vector2> AlgorithmObserverFactory => MockObserverFactory();
    }

    public class RBFSTestData : TestData
    {
        public override string AlgorithmName => nameof(HeuristicSearch.RecursiveBestFirstSearch);

        public override IAlgorithmObserverFactory<Vector2> AlgorithmObserverFactory => null;
    }

    public class RBFSObserverTestData : TestData
    {
        public override string AlgorithmName => nameof(HeuristicSearch.RecursiveBestFirstSearch);

        public override IAlgorithmObserverFactory<Vector2> AlgorithmObserverFactory => MockObserverFactory();
    }
}