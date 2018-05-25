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

        public static readonly ICollection<Vector2> _starts;
        public static readonly ICollection<Vector2> _goals;
        public static readonly ICollection<Vector2> _obstacles;

        static MapDataFixture()
        {
            var mapData = TestHelper.LoadMapData();

            _obstacles = mapData.Obstacles;
            _starts = mapData.Starts;
            _goals = mapData.Goals;
        }
    }

    public class AStarTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Combination of all start-goal pairs 
            var settings = from start in MapDataFixture._starts
                           from goal in MapDataFixture._goals
                           select ValueTuple.Create(start, goal);

            foreach (var setting in settings)
            {
                var start = setting.Item1;
                var goal = setting.Item2;
                var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(MapDataFixture.Unit));
                var solution = from step in queryable.Except(MapDataFixture._obstacles)
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
            // Combination of all start-goal pairs 
            var settings = from start in MapDataFixture._starts
                           from goal in MapDataFixture._goals
                           select ValueTuple.Create(start, goal);

            foreach (var setting in settings)
            {
                var start = setting.Item1;
                var goal = setting.Item2;
                var queryable = HeuristicSearch.BestFirstSearch(start, goal, (step, lv) => step.GetFourDirections(MapDataFixture.Unit));
                var solution = from step in queryable.Except(MapDataFixture._obstacles)
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
            // Combination of all start-goal pairs 
            var settings = from start in MapDataFixture._starts
                           from goal in MapDataFixture._goals
                           select ValueTuple.Create(start, goal);

            foreach (var setting in settings)
            {
                var start = setting.Item1;
                var goal = setting.Item2;
                var queryable = HeuristicSearch.IterativeDeepeningAStar(start, goal, (step, lv) => step.GetFourDirections(MapDataFixture.Unit));
                var solution = from step in queryable.Except(MapDataFixture._obstacles)
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
            // Combination of all start-goal pairs 
            var settings = from start in MapDataFixture._starts
                           from goal in MapDataFixture._goals
                           select ValueTuple.Create(start, goal);

            foreach (var setting in settings)
            {
                var start = setting.Item1;
                var goal = setting.Item2;
                var queryable = HeuristicSearch.RecursiveBestFirstSearch(start, goal, (step, lv) => step.GetFourDirections(MapDataFixture.Unit));
                var solution = from step in queryable.Except(MapDataFixture._obstacles)
                               where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                               orderby step.GetManhattanDistance(goal)
                               select step;

                yield return new object[] { start, goal, solution.ToArray() };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}