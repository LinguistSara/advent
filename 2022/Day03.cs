using System.Collections.Generic;
using System.Linq;

namespace Advent.y2022
{
    public class Day03 : Day
    {
        public Day03() : base(3, 2022)
        {
            
        }

        public override long Part1(List<string> input)
        {
            return input
                .Select(row => row.Chunk(row.Length/2))
                .Select(CommonItemsPriority).Sum();
        }
        public override long Part2(List<string> input)
        {
            return input
                .Chunk(3)
                .Select(CommonItemsPriority)
                .Sum();
        }

        private int CommonItemsPriority(IEnumerable<IEnumerable<char>> items)
        {
            return items.First()
            .Where(item => items.All(comp => comp.Contains(item)))
            .Select(item => item > 'a' ? item - 'a' + 1 : item - 'A' + 27)
            .First();
        }
    }
}
