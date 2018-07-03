using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Heuristic.Linq.Test
{
    static class TestHelper
    {
        const char ObstacleSymbol = 'X';
        const char StartSymbol = 'S';
        const char GoalSymbol = 'G';

        public static (List<Vector2> Starts, List<Vector2> Goals, HashSet<Vector2> Obstacles) LoadMapData()
        {
            var froms = new List<Vector2>();
            var goals = new List<Vector2>();
            var obstacles = new HashSet<Vector2>();
            var mapData = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MapData.txt"));

            for (int y = 0; y < mapData.Length; y++)
            {
                for (var x = 0; x < mapData[y].Length; x++)
                {
                    switch (mapData[y][x])
                    {
                        case StartSymbol:
                            froms.Add(new Vector2(x, y));
                            break;

                        case GoalSymbol:
                            goals.Add(new Vector2(x, y));
                            break;

                        case ObstacleSymbol:
                            obstacles.Add(new Vector2(x, y));
                            break;
                    }
                }
            }
            return (froms, goals, obstacles);
        }
    }
}