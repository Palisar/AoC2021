using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AoCTests
{
    public class Day6Tests
    {
        [Fact]
        public void Part1()
        {
            var data = new[] { 3, 4, 3, 1, 2 };
            var actual = Day_06.Part1(data);
            Assert.Equal(5934, actual);
        }
        [Fact]
        public void Part2()
        {
            var data = new[] { 3, 4, 3, 1, 2 };
            var actual = Day_06.Part2(data);
            Assert.Equal(26984457539, actual);
        }
        [Fact]
        public void Populate2Test()
        {
            var data = new[] { 3, 4,  0, 3, 0, 1, 2 , 5,  2 , 4 };
            var actual = Day_06.PopulateList2(data);
            Assert.Equal(new SortedDictionary<int, long> { { 0, 2 }, { 1, 1 }, { 2, 2 }, { 3, 2 }, { 4, 2 }, { 5, 1 }, { 6, 0 },{ 7, 0 },{ 8, 0 } }, actual);
        }
    }
}
