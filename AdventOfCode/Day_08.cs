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

    /*
      acedgfb: 8
      cdfbe: 5
      gcdfa: 2
      fbcad: 3
      dab: 7
      cefabd: 9
      cdfgeb: 6
      eafb: 4
      cagedb: 0
      ab: 1
    */
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
            var input = spliter[0].Split(' ');
            var output = spliter[1].Split(' ');
            Dictionary<string, int> DecodedDict = DecodePatterns(input);
            
            foreach (var digit in output)
            {
                var ordered = String.Concat(digit.OrderBy(l => l));
                if (DecodedDict.ContainsKey(ordered))
                {
                    sb.Append(DecodedDict[ordered].ToString());
                }
            }
            result += int.Parse(sb.ToString());
            sb.Clear();
        }
        return result;
    }

    public static Dictionary<string, int> DecodePatterns(string[] input)
    {
        Dictionary<string, int> output = new();

        string one = "";
        string four = "";
        string six = "";
        foreach (var unsorted in input)
        {
            var item = String.Concat(unsorted.OrderBy(l => l));
            switch (item.Length)
            {
                case 2:
                    output.Add(item, 1);
                    one = item;
                    break;
                case 4:
                    output.Add(item, 4);
                    four = item;
                    break;
                case 3:
                    output.Add(item, 7);
                    break;
                case 7:
                    output.Add(item, 8);
                    break;
            }
        }
        var groupOfSix = input.Where(x => x.Length == 6).ToArray();
        var groupOfFive = input.Where(x => x.Length == 5).ToArray();

        foreach (var unsorted in groupOfSix)
        {
            var item = String.Concat(unsorted.OrderBy(l => l));
            if (!item.ContainsAll(one))
            {
                output.Add(item, 6);
                six = item;
            }
            else if (item.ContainsAll(four))
            {
                output.Add(item, 9);
            }
            else
            {
                output.Add(item, 0);
            }

        }

        foreach (var unsorted in groupOfFive)
        {
            var item = String.Concat(unsorted.OrderBy(l => l));
            if (item.ContainsAll(one))
            {
                output.Add(item, 3);
            }
            else if (six.ContainsAll(item))
            {
                output.Add(item, 5);
            }
            else
            {
                output.Add(item, 2);
            }
        }
        return output;
    }

    //be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb
    /*
     */


}

public static class Extension
{
    public static bool ContainsAll(this string input, IEnumerable<char> container)
    {
        foreach (var item in container)
        {
            if (!input.Contains(item))
            {
                return false;
            }
        }
        return true;
    }
}
