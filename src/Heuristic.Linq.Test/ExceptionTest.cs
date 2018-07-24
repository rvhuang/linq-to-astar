using System.Drawing;
using System.Linq;
using Xunit;

namespace Heuristic.Linq.Test
{
    using System;
    using Algorithms;

    public class ExceptionTest
    {
        private readonly Point start = new Point(2, 2);
        private readonly Point goal = new Point(18, 18);
        private readonly Rectangle boundary = new Rectangle(0, 0, 20, 20);
        private const int unit = 1;

        [Fact]
        public void InvalidOperationExceptionTest()
        {
            var queryable = HeuristicSearch.AStar(start, goal, (step, lv) => step.GetFourDirections(unit));
            var obstacles = new[] { new Point(5, 5), new Point(6, 6), new Point(7, 7), new Point(8, 8), new Point(9, 9) };
            var solution = from step in queryable
                           from obstacle in obstacles
                           where step != obstacle
                           select step;
            
            var exception = Assert.Throws<InvalidOperationException>(() => solution.First());

            Assert.StartsWith("Unable to evaluate steps.", exception.Message);
        }
    }
}