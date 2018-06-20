# Expression Examples

Examples of supported LINQ expressions are listed in this file. All examples use [System.Drawing.Primitives](https://www.nuget.org/packages/System.Drawing.Primitives/) types and share same initial conditions.

```csharp
var start = new Point(2, 2);
var goal = new Point(18, 18);
var boundary = new Rectangle(0, 0, 20, 20); // map size
var unit = 1;
```

## SelectMany

The example belows uses `SelectMany()` clause (nested `from` loops) to eliminate obstacles from available positions.

```csharp
var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
var obstacles = new[] { new Point(5, 5), new Point(6, 6), new Point(7, 7), new Point(8, 8) };
var solution = from step in queryable
               from obstacle in obstacles
               where step != obstacle
               orderby step.GetManhattanDistance(goal)
               select step;
```

## Except

The example uses `Except()` to eliminate obstacles from available positions. The result is equivalent to `SelectMany()` example.

```csharp
var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
var obstacles = new[] { new Point(5, 5), new Point(6, 6), new Point(7, 7), new Point(8, 8) };
var solution = from step in queryable.Except(obstacles)
               where boundary.Contains(step)
               orderby step.GetManhattanDistance(goal)
               select step;
```
Using `Except()` is recommended when there are many positions to be eliminated.

## Contains

The example uses `Contains()` to specify limited positions on the map.

```csharp
var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
var solution = from step in queryable.Contains(boundary.GetAvailablePoints(unit))
               orderby step.GetManhattanDistance(goal)
               select step;
```
Using `Contains()` is recommended when available nodes are limited such as tree or graph traversal.

## Reverse

The example uses `Reverse()` to reverse solution from `start` to `goal` to `goal` to `start`.

```csharp
var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
var solution = from step in queryable.Reverse()
               where boundary.Contains(step)
               orderby step.GetManhattanDistance(goal)
               select step;
```

## OrderBy and ThenBy

The example shows two heuristic functions co-existing in same expression. When `GetManhattanDistance()` method evaluates two positions as same cost, the sequent method `GetEuclideanDistance()` will be referred to evaluate them.

```csharp
var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
var solution = from step in queryable
               where boundary.Contains(step)
               orderby step.GetManhattanDistance(goal), step.GetEuclideanDistance(goal)
               select step;
```
