using AdventOfCode;
using Xunit;

namespace AoCTests
{
    public class Day1Tests
    {
        [Fact]
        public void TestPart1()
        {
            var data = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263, };
            var actual = Day_01.Part1(data);
            Assert.Equal(7, actual);
        }

        [Fact]
        public void TestPart2()
        {
            var data = new[] { 607, 618, 618, 617, 647, 716, 769, 792, };
            var actual = Day_01.Part2(data);
            Assert.Equal(5, actual);
        }
    }
}