namespace AoCTests;

public class Day9Tests
{
    [Fact]
    public void Part1()
    {
        var data = new[,]
        {
            {2,1,9,9,9,4,3,2,1,0},
            {3,9,8,7,8,9,4,9,2,1},
            {9,8,5,6,7,8,9,8,9,2},
            {8,7,6,7,8,9,6,7,8,9},
            {9,8,9,9,9,6,5,6,7,8}
        };
          
        var actual = Day_09.Part1(data);
        actual.Should().Be(15);
    }
    
    [Fact]
    public void Part2()
    {

    }
}
