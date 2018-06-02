using System;
using System.Collections.Generic;
using System.Linq;
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
            var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var solution = from step in queryable.Except(GetObstacles())
                           where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                           let distance = step.GetManhattanDistance(goal)
                           orderby distance
                           select step;

            foreach (var step in solution)
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