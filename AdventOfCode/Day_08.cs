namespace AdventOfCode;

public class Day_08 : BaseDay
{

    private readonly string[] _input;

    public Day_08()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        return ValueTask.FromResult(Part1(_input).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return ValueTask.FromResult(Part2(_input).ToString());
    }
    public static int Part1(string[] segments)
    {
        var count = 0;
        foreach (var item in segments)
        {
            var spliter = item.Split('|');
            var output = spliter[1].Split(' ');
            foreach (var digit in output)
            {
                int[] constantDigits = { 2, 4, 7, 3 };
                if (constantDigits.Contains(digit.Length))
                {
                    count++;
                }
            }
        }
        return count;
    }

    //    dddd
    //   e    a
    //   e    a
    //    ffff
    //   g    b
    //   g    b
    //    cccc
    public static Dictionary<string, int> Digit = new Dictionary<string, int>
    {
        { "abcdefg", 8},
        { "cdfbe" , 5},
        { "acdfg" , 2},
        { "abcdf" , 3},
        { "abd" , 7},
        { "abcdef" , 9},
        { "bcdefg" , 6},
        { "abef", 4},
        { "abcdeg", 0},
        { "ab", 1}
    };

    public static int Part2(string[] segments)
    {
        var result = 0;
        foreach (var item in segments)
        {
            StringBuilder sb = new();
            var spliter = item.Split('|');
            var output = spliter[1].Split(' ');

            foreach (var digit in output)
            {
                var ordered = String.Concat(digit.OrderBy(l => l));
                if (Digit.ContainsKey(ordered))
                {
                    sb.Append(Digit[ordered].ToString());
                }
            }
            result += int.Parse(sb.ToString());
            sb.Clear();
        }
        return result;
    }

    public static Dictionary<string, int> Decypher(string input)
    {

        return new();
    }

}
