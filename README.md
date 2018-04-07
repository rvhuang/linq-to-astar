# LINQ To A\*

**LINQ To A\*** is an experimental project aimed to incorporate LINQ expressions into A\* as well as other heuristic search algorithms.

We love LINQ because it is the most elegant and beautiful thing in .NET world. Exploring the possibility of collaboration between heuristic search algorithms and LINQ expressions is what we are trying to do in the project.

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

// The shortest path found by A* algorithm.
foreach (var step in queryable)
{
    Console.WriteLine(step);
}
```

The LINQ expression consists of following elements:

* The `Except()` expression eliminates invalid steps during the process.
* The `where` clause sets up the boundary, but can also be used for checking invalid steps.
* The `orderby` clause serves as *_h(n)_* (aka **Heuristic**) that estimates the cost of the cheapest path from n to the goal.
* If path is found, the enumeration returns each step in deferred execution. Otherwise, no step is returned.

## Supported Algorithms

|Algorithm|Method|Status|
|----------|----------|----------|
|A\*|`HeuristicSearch.AStar<TStep>()`|Done|
|Best First|--|To be implemented|
|Recursive Best First Search|--|To be implemented|
|Iterative Deepening A\*|--|To be implemented|

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