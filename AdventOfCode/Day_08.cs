namespace AdventOfCode;

public class Day_08 : BaseDay
{

    private readonly string _input;
    private readonly string[] _segments;

    public Day_08()
    {
         _input = File.ReadLines(InputFilePath).First();
        _segments = _input.Split(new[] { '\n' });
    }

    public override ValueTask<string> Solve_1()
    {
        return ValueTask.FromResult(Part1(_segments).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return ValueTask.FromResult(Part2(_numbers).ToString());
    }
    public static int Part1(string[] numbers)
    {
        return 0;
    }

    public static int Part2(int[] numbers)
    {
        return 0;
    }

}
