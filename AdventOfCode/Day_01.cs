namespace AdventOfCode;

public class Day_01 : BaseDay
{
    private readonly string _input;
    private readonly int[] _numbers;

    public Day_01()
    {
        _input = File.ReadAllText(InputFilePath);
        _numbers = _input.Split("\n").Select(int.Parse).ToArray();
    }

    public override ValueTask<string> Solve_1()
    {
        return ValueTask.FromResult(Part1(_numbers).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return ValueTask.FromResult(Part2(_numbers).ToString());
    }

    public static int Part1(IEnumerable<int> input)
    {
        var count = 0;
        var previous = int.MaxValue;
        foreach (var i in input)
        {
            if (i > previous)
            {
                count++;
            }
            previous = i;
        }
        return count;
    }

    public static int Part2(int[] input)
    {
        var count = 0;
        var previousSum = int.MaxValue;
        for (var i = 0; i < input.Length - 2; i++)
        {
            var currentSum = input[i] + input[i + 1] + input[i + 2];
            if (currentSum > previousSum) 
                count++;
            previousSum = currentSum;
        }
        return count;
    }
}
