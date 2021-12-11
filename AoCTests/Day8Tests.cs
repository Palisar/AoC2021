namespace AoCTests;

public class Day8Tests
{
    [Fact]
    public void Part1()
    {
        var data = new[] { "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe", "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg", "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb", "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea", "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb", "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe", "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef", "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb", "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce" };
        var actual = Day_08.Part1(data);
        actual.Should().Be(26);
    }

    [Fact]
    public void Part2()
    {
        var data = new[] { "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe", "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg", "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb", "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea", "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb", "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe", "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef", "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb", "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce" };
        var actual = Day_08.Part2(data);
        actual.Should().Be(61229);
    }

    [Fact]
    public void Trial()
    {
        var input = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab";
        var data = input.Split(' ').ToArray();
        Dictionary<string, int> unscram = new();
        foreach (var item in data)
        {
            String.Concat(item.OrderBy(x => x));
        }
    }
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
    [Fact]
    public void CanTranslateInputPatterns()
    {
        var input = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab";
        var data = input.Split(' ').ToArray();

        var actual = Day_08.DecodePatterns(data);

        actual["abcdefg"].Should().Be(8);
        actual["ab"].Should().Be(1);
        actual["abcdef"].Should().Be(9);
        actual["bcdef"].Should().Be(5);
    }

}
