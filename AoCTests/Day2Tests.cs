using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AoCTests
{
    public class Day2Tests
    {
        [Fact]
        public void TestPart1()
        {
            var data = new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
            var actual = Day_02.Part1(data);
            Assert.Equal(150, actual);
        }

        [Fact]
        public void TestPart2()
        {
            var data = new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
            var actual = Day_02.Part2(data);
            Assert.Equal(900, actual);
        }
    }
}
