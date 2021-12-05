namespace AdventOfCode;

public class Day_02 : BaseDay
{
    private readonly string _input;
    private readonly string[] _movements;
   

    public Day_02()
    {
        _input = File.ReadAllText(InputFilePath);
        _movements = _input.Split("\n").ToArray();
    }
    public override ValueTask<string> Solve_1()
    {
        return ValueTask.FromResult(Part1(_movements).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return ValueTask.FromResult(Part2(_movements).ToString());
    }
    public static int Part1(string[] movements)
    {
        var depth = 0;
        var horizontalPos = 0;
        foreach (var movement in movements)
        {
            var values = movement.Split(' ').ToList();
            var change = int.Parse(values[1]);
            switch (values[0])
            {
                case "forward":
                    horizontalPos += change;
                        break;
                case "up":
                    depth += change;
                    break;
                case "down":
                    depth -= change;
                    break;
            }
        }
        return Math.Abs(depth) * horizontalPos;
    }
    public static int Part2(string[] movements)
    {
        var depth = 0;
        var horizontalPos = 0;
        var aim = 0;
        foreach (var movement in movements)
        {
            var values = movement.Split(' ').ToList();
            var change = int.Parse(values[1]);
            switch (values[0])
            {
                case "forward":
                    horizontalPos += change;
                    depth += aim * change;
                    break;
                case "up":
                    aim -= change;
                    break;
                case "down":
                    aim += change;
                    break;
            }
        }
        return Math.Abs(depth) * horizontalPos;
    }
}
