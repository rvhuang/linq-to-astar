using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LinqToAStar.Test
{
    public static class MapDataFixture
    {
        public const float Unit = 1f;

        public static readonly ICollection<Vector2> Starts;
        public static readonly ICollection<Vector2> Goals;
        public static readonly ICollection<Vector2> Obstacles;

        static MapDataFixture()
        {
            var mapData = TestHelper.LoadMapData();

            Obstacles = mapData.Obstacles;
            Starts = mapData.Starts;
            Goals = mapData.Goals;
        }

        public static IEnumerable<(Vector2 Start, Vector2 Goal)> GetStartGoalCombinations()
        {
            // Combination of all start-goal pairs 
            return from start in MapDataFixture.Starts
                   from goal in MapDataFixture.Goals
                   select ValueTuple.Create(start, goal);
        }
    }

    public class AStarTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var setting in MapDataFixture.GetStartGoalCombinations())
            {
                var start = setting.Start;
                var goal = setting.Goal;
                var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(MapDataFixture.Unit));
                var solution = from step in queryable.Except(MapDataFixture.Obstacles)
                               where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                               orderby step.GetManhattanDistance(goal)
                               select step;

                yield return new object[] { start, goal, solution.ToArray() };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class BFSTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var setting in MapDataFixture.GetStartGoalCombinations())
            {
                var start = setting.Start;
                var goal = setting.Goal;
                var queryable = HeuristicSearch.BestFirstSearch(start, goal, (step, lv) => step.GetFourDirections(MapDataFixture.Unit));
                var solution = from step in queryable.Except(MapDataFixture.Obstacles)
                               where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                               orderby step.GetManhattanDistance(goal)
                               select step;

                yield return new object[] { start, goal, solution.ToArray() };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class IDATestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var setting in MapDataFixture.GetStartGoalCombinations())
            {
                var start = setting.Start;
                var goal = setting.Goal;
                var queryable = HeuristicSearch.IterativeDeepeningAStar(start, goal, (step, lv) => step.GetFourDirections(MapDataFixture.Unit));
                var solution = from step in queryable.Except(MapDataFixture.Obstacles)
                               where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                               orderby step.GetManhattanDistance(goal)
                               select step;

                yield return new object[] { start, goal, solution.ToArray() };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class RBFSTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var setting in MapDataFixture.GetStartGoalCombinations())
            {
                var start = setting.Start;
                var goal = setting.Goal;
                var queryable = HeuristicSearch.RecursiveBestFirstSearch(start, goal, (step, lv) => step.GetFourDirections(MapDataFixture.Unit));
                var solution = from step in queryable.Except(MapDataFixture.Obstacles)
                               where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                               orderby step.GetManhattanDistance(goal)
                               select step;

                yield return new object[] { start, goal, solution.ToArray() };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}