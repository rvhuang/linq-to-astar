# Contributing 

Contributing rules and guideline are listed below. 

## General

* Please follows [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) in your code.
* Algorithms and supported LINQ clauses must be listed in [README.md](../README.md) file.

## Implementing New Algorithm

1. Add new class to [Core](../src/LinqToAStar/Core) folder with following behaviors:
    * The class must implement `IEnumerable(T)` interface.
    * The solution must be produced in [deferred execution](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/query-execution). That is, the path is returned by `GetEnumerator()` method.
2. Add corresponding `case` section to `HeuristicSearchOrderBy<TResult, TStep>.GetEnumerator()` method.
3. Add corresponding validity test class.
4. Send a pull request which includes algorithm description or reference link (such as [Wiki page](https://en.wikipedia.org/wiki/Main_Page)).

Please refer to [A\*](../src/LinqToAStar/Core/AStar.cs) as example.

Thank you for considering contributing to the project. 
