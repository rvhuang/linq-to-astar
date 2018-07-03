# LINQ to A\*

[![Build Status](https://travis-ci.org/rvhuang/linq-to-astar.svg?branch=master)](https://travis-ci.org/rvhuang/linq-to-astar) [![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/rvhuang/linq-to-astar/blob/master/LICENSE) 
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/linq-to-astar.svg)](https://www.nuget.org/packages/linq-to-astar/)

**LINQ to A\*** is an experimental library aimed to incorporate LINQ expressions into [A\*](https://en.wikipedia.org/wiki/A*_search_algorithm) as well as other heuristic search algorithms. With the library, LINQ can now be used as query expression to state conditions and fetch shortest path found by the algorithm.

The library defines a set of generic APIs that can be applied to any problem as long as the problem can be solved with the algorithm. By taking advantage of the power of LINQ, the library is not only about re-implementing in C#, but also giving new ability and flexibility to the algorithms.

**All feedbacks are greatly appreciated** as the experiment is growing rapidly.

## Why LINQ

* Great human-readability and maintainability of algorithm using.
* Structural, object-oriented, consice programming model for various heuristic algorithms.
* Easy to learn and use.
* **Looking cool**. (very important!)

## Example

Snippet below shows the LINQ expression used to find shortest path between `start` and `goal` on a 40 \* 40 map. The example utilizes types defined in [System.Drawing.Primitives](https://www.nuget.org/packages/System.Drawing.Primitives/). 

```csharp
// The path to be found between two positions.
var start = new Point(5, 5);
var goal = new Point(35, 35);
var boundary = new Rectangle(0, 0, 40, 40);
var unit = 1;

// The initialization of A* algorithm
// with the factory that gets possible steps from current step.
var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));

// See description below.
var solution = from step in queryable.Except(GetObstacles()) // 1.
               where boundary.Contains(step)                 // 2.
               orderby step.GetManhattanDistance(goal)       // 3.
               select step;

// Each step of the shortest path found by A* algorithm.
foreach (var step in solution)
{
    Console.WriteLine(step);
}
```

The LINQ expression consists of following clauses:

1. The `Except()` eliminates invalid steps during the process.
2. The `where` clause sets up the boundary but can also be used for checking invalid steps.
3. The `orderby` clause serves as *h(n)* (aka [Heuristic](https://en.wikipedia.org/wiki/Heuristic)) that estimates the cost of the cheapest path from *n* (current step) to the goal.

If path is found, the enumeration returns each step in deferred execution. Otherwise, no step is returned.

See [Expression Examples](docs/Expression-Examples.md) for more examples.

### Console Examples

* [Pathfinding](src/LinqToAStar.Example.PathFinding/) 
* [Solving 8-Puzzle](src/LinqToAStar.Example.EightPuzzle/)

### Playground

Check out [Pathfinding Lab](https://pathfinding-lab.azurewebsites.net/) and try it out.

## Supported Algorithms

|Algorithm|Factory Method|
|----------|----------|
|[A\*](https://en.wikipedia.org/wiki/A*_search_algorithm)|`AStar<TStep>()`|
|[Best-first Search](https://en.wikipedia.org/wiki/Best-first_search)|`BestFirstSearch<TStep>()`|
|[Recursive Best-first Search](http://cs.gettysburg.edu/~tneller/papers/talks/RBFS_Example.htm)|`RecursiveBestFirstSearch<TStep>()`|
|[Iterative Deepening A\*](https://en.wikipedia.org/wiki/Iterative_deepening_A*)|`IterativeDeepeningAStar<TStep>()`|

### User-defined Algorithm

You are able to implement and use your customized algorithm with following steps:

1. Create a type that implements `IAlgorithm` interface.
2. Register the type and name of the algorithm with `HeuristicSearch.Register<TAlgorithm>()`.
3. Apply LINQ expressions to your algorithm by calling `HeuristicSearch.Use()` method.

```csharp
// MyAlgorithmClass has to implement IAlgorithm interface.
HeuristicSearch.Register<MyAlgorithmClass>("MyAlgorithm");

var queryable = HeuristicSearch.Use("MyAlgorithm", start, goal, getFourDirections);
var solution = from step in queryable.Except(GetObstacles())
               where boundary.Contains(step)
               orderby step.GetManhattanDistance(goal)
               select step;
```

## Supported LINQ Clauses and Operations

### Transformation

* `Select()`
* `SelectMany()`

### Condition

* `Where()`
* `Except()`
* `Contains()`

### Heuristic Function 

* `OrderBy()` - serves as heuristic function.
* `OrderByDescending()` - serves as reverse heuristic function.
* `ThenBy()` - serves as heuristic function but will only be referred when previous one evaluates two nodes as equal.
* `ThenByDescending()` - serves as reverse heuristic function but will only be referred when previous one evaluates two nodes as equal.

### Operation

* `Reverse()` - inverts the order of solution from `start` -> `goal` to `goal` -> `start`.
* `ToArray()` - provides optimized performance better than `Enumerable.ToArray<T>()`.
* `ToList()` - provides optimized performance better than `Enumerable.ToList<T>()`.

### In Development

* `Intersect()` - planning
* `Join()` - evaluating, may be canceled

## Roadmap

|Milestone|Release Date (NuGet)|
|----------|----------|
|1.0.0 Preview|Q2 2018|
|1.0.0|Q3 2018|

## Platform and Dependencies

* [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/api/?view=netstandard-2.0)
* [System.Numerics.Vectors](https://www.nuget.org/packages/System.Numerics.Vectors/) (>= 4.4.0)
* [System.Drawing.Primitives](https://www.nuget.org/packages/System.Drawing.Primitives/) (>= 4.3.0)

## License

The MIT License (MIT)

Copyright © Robert Vandenberg Huang ([rvh.omni@gmail.com](mailto:rvh.omni@gmail.com))

Feel free to copy, modify and use in your computer science homework (grades not guaranteed).
