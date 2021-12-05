using AdventOfCode;
using Xunit;

namespace AoCTests;

public class Day3Tests
{
    [Fact]
    public void Test() { }

    [Fact]
    public void TestPart1()
    {
        var data = new[] { 
            "00100", 
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010" };
        var actual = Day_03.Part1(data);
        Assert.Equal(198, actual);
    }

    [Fact]
    public void TestPart1b()
    {
        var data = new[] { "010", "110", "110" };
        var actual = Day_03.Part1(data);
        Assert.Equal(6, actual);
    }
    [Fact]
    public void TestPart2()
    {
        var data = new[] {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010" };
        var actual = Day_03.Part2(data);
        Assert.Equal(230, actual);
    }
}

