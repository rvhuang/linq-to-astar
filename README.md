# LINQ to A\*

[![Build Status](https://travis-ci.org/rvhuang/linq-to-astar.svg?branch=master)](https://travis-ci.org/rvhuang/linq-to-astar)

**LINQ to A\*** is an experimental project aimed to incorporate LINQ expressions into [A\*](https://en.wikipedia.org/wiki/A*_search_algorithm) as well as other heuristic search algorithms. The goal is to improve human-readability and maintainability of conditions that are applied to the algorithm.

Unlike traditional implementations, all supported algorithms in the project are generic. The API can be used to solve any problem as long as the algorithm is applicable.

## Example

Snippet below shows the LINQ expression used to find shortest path between two positions.

```csharp
// The path to be found between two positions.
var start = new Vector2(5, 5);
var goal = new Vector2(35, 35);
var unit = 1;

// The initialization of A* algorithm
// with the factory that gets possible steps from current step.
var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));

// See description below.
var solution = from step in queryable.Except(GetObstacles())
               where step.X >= 0 && step.Y >= 0 && step.X <= 40 && step.Y <= 40
               orderby step.GetManhattanDistance(goal)
               select step;

// Each step of the shortest path found by A* algorithm.
foreach (var step in solution)
{
    Console.WriteLine(step);
}
```

The LINQ expression consists of following clauses:

* The `Except()` eliminates invalid steps during the process.
* The `where` clause sets up the boundary, but can also be used for checking invalid steps.
* The `orderby` clause serves as *h(n)* (aka [Heuristic](https://en.wikipedia.org/wiki/Heuristic)) that estimates the cost of the cheapest path from *n* to the goal.

If path is found, the enumeration returns each step in deferred execution. Otherwise, no step is returned.

Complete executable example can be found in [path finding](src/LinqToAStar.Example.PathFinding/) example project (more example projects will be added in future).

## Supported Algorithms

|Algorithm|Factory Method|Status|
|----------|----------|----------|
|[A\*](https://en.wikipedia.org/wiki/A*_search_algorithm)|`AStar<TStep>()`|Done|
|[Best-first Search](https://en.wikipedia.org/wiki/Best-first_search)|`BestFirstSearch<TStep>()`|Done|
|[Recursive Best-first Search](http://cs.gettysburg.edu/~tneller/papers/talks/RBFS_Example.htm)|`RecursiveBestFirstSearch<TStep>()`|Done|
|[Iterative Deepening A\*](https://en.wikipedia.org/wiki/Iterative_deepening_A*)|`IterativeDeepeningAStar<TStep>()`|Done|

## Supported LINQ Expressions

|Expression|Status|
|----------|----------|
|`Select()`|Done|
|`SelectMany()`|Done|
|`Where()`|Done|
|`OrderBy()`|Done|
|`OrderByDescending()`|Done|
|`ThenBy()`|Done|
|`ThenByDescending()`|Done|
|`Except()`|Done|
|`Contains()`|To be implemented|

## Roadmap

|Milestone|Release Date (NuGet)|
|----------|----------|
|1.0.0 Preview|Q2 2018|
|1.0.0|Q3 2018|

## Platform

The project targets .NET Standard 2.0 currently.

## Dependencies

* [System.Numerics.Vectors](https://www.nuget.org/packages/System.Numerics.Vectors/) (>= 4.4.0)
* [System.Drawing.Primitives](https://www.nuget.org/packages/System.Drawing.Primitives/) (to be supported)

## License

The project is licensed under MIT. Feel free to copy and use in your algorithm homework (grades not guaranteed).
