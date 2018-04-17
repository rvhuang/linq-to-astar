using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace LinqToAStar.Test
{
    static class TestHelper
    {
        const char ObstacleSymbol = 'X';
        const char StartSymbol = 'S';
        const char GoalSymbol = 'G';

        public static (Vector2 Start, Vector2 Goal, ISet<Vector2> Obstacles) LoadMapData()
        {
            var from = default(Vector2);
            var goal = default(Vector2);
            var obstacles = new HashSet<Vector2>();
            var mapData = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MapData.txt"));

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