using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Heuristic.Linq.Example.PathFinding
{
    class Program
    {
        const int MapWidth = 25;
        const int MapHeight = 25;
        const int Unit = 1;

        const char ObstacleSymbol = 'X';
        const char StartSymbol = 'S';
        const char GoalSymbol = 'G';
        const char SpaceSymbol = ' ';
        const char PathSymbol = '*';

        static void Main(string[] args)
        {
            var boundary = new Rectangle(0, 0, MapWidth, MapWidth);
            var presentation = new char[MapHeight][];

            while (true)
            {
                var queryable = default(HeuristicSearchBase<Point, Point>);
                var solution = default(HeuristicSearchBase<Point, Point>);
                var counter = 0;
                var mapData = LoadMapData();

                for (var y = 0; y < MapHeight; y++)
                {
                    if (presentation[y] == null)
                        presentation[y] = new char[MapWidth];

                    for (var x = 0; x < MapWidth; x++)
                    {
                        var point = new Point(x, y);

                        if (mapData.Obstacles.Contains(point))
                            presentation[y][x] = ObstacleSymbol;
                        else if (point == mapData.Start)
                            presentation[y][x] = StartSymbol;
                        else if (point.Equals(mapData.Goal))
                            presentation[y][x] = GoalSymbol;
                        else
                            presentation[y][x] = SpaceSymbol;
                    }
                }

                Console.WriteLine("A)* Search");
                Console.WriteLine("B)est-first Search");
                Console.WriteLine("R)ecursive Best-first Search");
                Console.WriteLine("I)terative Deepening AStar Search");
                Console.Write("Select an algorithm: ");

                // Initial the algorithm.
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        queryable = HeuristicSearch.AStar(mapData.Start, mapData.Goal, GetNextSteps);
                        break;

                    case ConsoleKey.B:
                        queryable = HeuristicSearch.BestFirstSearch(mapData.Start, mapData.Goal, GetNextSteps);
                        break;

                    case ConsoleKey.I:
                        queryable = HeuristicSearch.IterativeDeepeningAStar(mapData.Start, mapData.Goal, GetNextSteps);
                        break;

                    case ConsoleKey.R:
                        queryable = HeuristicSearch.RecursiveBestFirstSearch(mapData.Start, mapData.Goal, GetNextSteps);
                        break;

                    default: continue;
                }

                Console.WriteLine();
                Console.WriteLine("C)hebyshev Distance Comparer");
                Console.WriteLine("E)uclidean Distance Comparer");
                Console.WriteLine("M)anhattan Distance Comparer");
                Console.Write("Select comparer: ");

                // Compare two positions and the goal position with selected distance.
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.C:
                        solution = from step in queryable.Except(mapData.Obstacles)
                                   where boundary.Contains(step)
                                   orderby step.GetChebyshevDistance(mapData.Goal)
                                   select step;
                        break;

                    case ConsoleKey.E:
                        solution = from step in queryable.Except(mapData.Obstacles)
                                   where boundary.Contains(step)
                                   orderby step.GetEuclideanDistance(mapData.Goal)
                                   select step;
                        break;

                    case ConsoleKey.M:
                        solution = from step in queryable.Except(mapData.Obstacles)
                                   where boundary.Contains(step)
                                   orderby step.GetManhattanDistance(mapData.Goal)
                                   select step;
                        break;

                    default: continue;
                }
                Console.WriteLine();

                foreach (var step in solution)
                {
                    if (step != mapData.Start && step != mapData.Goal)
                        presentation[(int)step.Y][(int)step.X] = PathSymbol;

                    counter++;
                }

                Array.ForEach(presentation, row => Console.WriteLine(string.Join(" ", row)));
                Console.WriteLine("Total steps: {0}", counter);
            }
        }

        public static IEnumerable<Point> GetNextSteps(Point current, int level)
        {
            return current.GetFourDirections(Unit);
        }

        public static (Point Start, Point Goal, ISet<Point> Obstacles) LoadMapData()
        {
            var from = default(Point);
            var goal = default(Point);
            var obstacles = new HashSet<Point>();
            var mapData = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MapData.txt"));

            for (int y = 0; y < mapData.Length; y++)
            {
                for (var x = 0; x < mapData[y].Length; x++)
                {
                    switch (mapData[y][x])
                    {
                        case StartSymbol:
                            from = new Point(x, y);
                            break;

                        case GoalSymbol:
                            goal = new Point(x, y);
                            break;

                        case ObstacleSymbol:
                            obstacles.Add(new Point(x, y));
                            break;
                    }
                }
            }
            return (from, goal, obstacles);
        }
    }
}