namespace AoCTests;

public class Day7Tests
{
    [Fact] 
    public void Part1()
    {
        var data = new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
        var actual = Day_07.Part1(data);
        actual.Should().Be(37);
    }
    [Fact]
    public void Part2()
    {
        var data = new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
        var actual = Day_07.Part2(data);
        actual.Should().Be(168);
    }
    [Fact]
    public void Part2Sanity()
    {
        var data = new[] { 1 , 3};
        var actual = Day_07.Part2(data);
        actual.Should().Be(2);
    }
}

