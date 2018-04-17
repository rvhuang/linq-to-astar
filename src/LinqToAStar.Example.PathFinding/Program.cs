using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace LinqToAStar.Example.PathFinding
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
            var queryable = default(HeuristicSearchBase<Vector2, Vector2>);
            var distance = default(Func<Vector2, Vector2, float>);
            var presentation = new char[MapHeight][];

            while (true)
            {
                var mapData = LoadMapData();

                for (var y = 0; y < MapHeight; y++)
                {
                    if (presentation[y] == null)
                        presentation[y] = new char[MapWidth];

                    for (var x = 0; x < MapWidth; x++)
                    {
                        var point = new Vector2(x, y);

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
                        distance = VectorExtensions.GetChebyshevDistance;
                        break;

                    case ConsoleKey.E:
                        distance = Vector2.Distance;
                        break;

                    case ConsoleKey.M:
                        distance = VectorExtensions.GetManhattanDistance;
                        break;

                    default: continue;
                }
                Console.WriteLine();

                var solution = from step in queryable.Except(mapData.Obstacles)
                               where step.X >= 0 && step.Y >= 0 && step.X < MapWidth && step.Y < MapHeight
                               orderby distance(step, mapData.Goal)
                               select step;
                var counter = 0;

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

        public static IEnumerable<Vector2> GetNextSteps(Vector2 current, int level)
        {
            return current.GetFourDirections(Unit);
        }

        public static (Vector2 Start, Vector2 Goal, ISet<Vector2> Obstacles) LoadMapData()
        {
            var from = default(Vector2);
            var goal = default(Vector2);
            var obstacles = new HashSet<Vector2>();
            var mapData = File.ReadAllLines("MapData.txt");

            for (int y = 0; y < mapData.Length; y++)
            {
                for (var x = 0; x < mapData[y].Length; x++)
                {
                    switch (mapData[y][x])
                    {
                        case StartSymbol:
                            from = new Vector2(x, y);
                            break;

                        case GoalSymbol:
                            goal = new Vector2(x, y);
                            break;

                        case ObstacleSymbol:
                            obstacles.Add(new Vector2(x, y));
                            break;
                    }
                }
            }
            return (from, goal, obstacles);
        }
    }
}