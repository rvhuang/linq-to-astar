using System;
using System.Collections.Generic;
using System.Drawing;

namespace Heuristic.Linq.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new Point(5, 5);
            var goal = new Point(35, 35);
            var boundary = new Rectangle(0, 0, 40, 40);
            var unit = 1;
            var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var solution = from step in queryable.Except(GetObstacles())
                           where boundary.Contains(step)
                           orderby step.GetManhattanDistance(goal)
                           select step;

            foreach (var step in solution)
            {
                Console.WriteLine(step);
            }
        }

        static IEnumerable<Point> GetObstacles()
        {
            yield return new Point(15, 10);
            yield return new Point(16, 10);
            yield return new Point(17, 10);
            yield return new Point(18, 10);
            yield return new Point(19, 10);
            yield return new Point(10, 11);
            yield return new Point(11, 11);
            yield return new Point(12, 11);
            yield return new Point(13, 11);
            yield return new Point(14, 11);
            yield return new Point(15, 11);
        }
    }
}