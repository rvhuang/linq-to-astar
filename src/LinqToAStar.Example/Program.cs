using System;
using System.Collections.Generic;
using System.Numerics;

namespace LinqToAStar.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new Vector2(5, 5);
            var goal = new Vector2(35, 35);
            var unit = 1;
            var astar = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var queryable = from step in astar.Except(GetObstacles())
                            where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                            orderby step.GetManhattanDistance(goal)
                            select step;

            foreach (var step in queryable)
            {
                Console.WriteLine(step);
            }
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