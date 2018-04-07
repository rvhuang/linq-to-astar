# LINQ to A\*

**LINQ to A\*** is an experimental project aimed to incorporate LINQ expressions into A\* as well as other heuristic search algorithms.

## How It Works

Snippet below shows the LINQ expression used to find shortest path between two positions.

```csharp
// The path to be found between two positions.
var start = new Vector2(5, 5);
var goal = new Vector2(35, 35);

// The factory that gets next steps from current step.
var astar = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(1));

// See description below.
var queryable = from step in astar.Except(GetObstacles())
                where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
                orderby step.GetManhattanDistance(goal)
                select step;

// Each step of the shortest path found by A* algorithm.
foreach (var step in queryable)
{
    Console.WriteLine(step);
}
```

The LINQ expression consists of following clauses:

* The `Except()` eliminates invalid steps during the process.
* The `where` clause sets up the boundary, but can also be used for checking invalid steps.
* The `orderby` clause serves as *h(n)* (aka [Heuristic](https://en.wikipedia.org/wiki/Heuristic)) that estimates the cost of the cheapest path from *n* to the goal.

If path is found, the enumeration returns each step in deferred execution. Otherwise, no step is returned.

## Supported Algorithms

|Algorithm|Method|Status|
|----------|----------|----------|
|A\*|`HeuristicSearch.AStar<TStep>()`|Done|
|Best First|`BestFirst<TStep>()`|To be implemented|
|Recursive Best First Search|`RecursiveBestFirstSearch<TStep>()`|To be implemented|
|Iterative Deepening A\*|`IterativeDeepeningAStar<TStep>()`|To be implemented|

## Supported LINQ Expressions

|Expression|Status|
|----------|----------|
|`Select()`|Done|
|`SelectMany()`|Done|
|`Where()`|Done|
|`OrderBy()`|Done|
|`OrderByDescending()`|Done|
|`ThenBy()`|To be implemented|
|`ThenByDescending()`|To be implemented|
|`Except()`|Done|
|`Contains()`|To be implemented|

## Platform

The project targets .NET Standard 2.0 currently.

## Dependencies

[System.Numerics.Vectors](https://www.nuget.org/packages/System.Numerics.Vectors/)

## License

The project is licensed under MIT. Feel free to copy and use in your algorithm homework (grades not guaranteed).
