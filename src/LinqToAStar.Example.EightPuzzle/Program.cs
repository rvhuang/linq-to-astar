using System;
using System.Drawing;

namespace LinqToAStar.Example.EightPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // http://www.8puzzle.com/images/8_puzzle_start_state_a.png
                var initial = new BoardState(new[]
                {
                    new Point(1, 2), // empty square 
                    new Point(0, 1), // square 1
                    new Point(0, 0), // square 2
                    new Point(2, 0), // square 3
                    new Point(2, 1), // square 4
                    new Point(2, 2), // square 5
                    new Point(1, 1), // square 6
                    new Point(0, 2), // square 7
                    new Point(1, 0), // square 8
                });

                // http://www.8puzzle.com/images/8_puzzle_goal_state_a.png
                var goal = new BoardState(new[]
                {
                    new Point(1, 1), // empty square 
                    new Point(0, 0), // square 1
                    new Point(1, 0), // square 2
                    new Point(2, 0), // square 3
                    new Point(2, 1), // square 4
                    new Point(2, 2), // square 5
                    new Point(1, 2), // square 6
                    new Point(0, 2), // square 7
                    new Point(0, 1), // square 8
                });

                Console.WriteLine("A)* Search");
                Console.WriteLine("B)est-first Search");
                Console.WriteLine("I)terative Deepening AStar Search");
                Console.WriteLine("R)ecursive Best-first Search");
                Console.Write("Select an algorithm: ");

                var queryable = default(HeuristicSearchBase<BoardState, BoardState>);

                // Initialize the algorithm with the callback that gets all valid moves.
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        queryable = HeuristicSearch.AStar(initial, goal, (board, lv) => board.GetNextSteps());
                        break;

                    case ConsoleKey.B:
                        queryable = HeuristicSearch.BestFirstSearch(initial, goal, (board, lv) => board.GetNextSteps());
                        break;

                    case ConsoleKey.I:
                        queryable = HeuristicSearch.IterativeDeepeningAStar(initial, goal, (board, lv) => board.GetNextSteps());
                        break;

                    case ConsoleKey.R:
                        queryable = HeuristicSearch.RecursiveBestFirstSearch(initial, goal, (board, lv) => board.GetNextSteps());
                        break;

                    default: continue;
                }

                Console.WriteLine();

                // GetSumOfDistances() calculates the sum of Manhattan distance 
                // between each of square and its goal.
                // -------------------------------------------------
                var solution = from board in queryable
                               orderby board.GetSumOfDistances(goal)
                               select board;
                // -------------------------------------------------
                // Print out the solution.
                foreach (var board in solution)
                    Console.WriteLine(board);
            }
        }
    }
}
