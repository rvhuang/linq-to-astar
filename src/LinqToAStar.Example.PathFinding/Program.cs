using System;
using System.Collections.Generic;
using System.Numerics;
using System.IO;

namespace LinqToAStar.Example.PathFinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static (Vector2, Vector2, ISet<Vector2>) LoadMapData()
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
                        case 'F':
                            from = new Vector2(x, y);
                            break;

                        case 'G':
                            goal = new Vector2(x, y);
                            break;

                        case 'X':
                            obstacles.Add(new Vector2(x, y));
                            break;
                    }
                }
            }
            return (from, goal, obstacles);
        }
    }
}
