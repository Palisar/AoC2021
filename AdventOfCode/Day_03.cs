using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AdventOfCode;
public class Day_03 : BaseDay
{
    private readonly string _input;
    private readonly string[] _report;
    
    public Day_03()
    {
        _input = File.ReadAllText(InputFilePath);
        _report = _input.Split("\n").ToArray();
    }
    public override ValueTask<string> Solve_1()
    {
        return ValueTask.FromResult(Part1(_report).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return ValueTask.FromResult(Part2(_report).ToString());
    }
    public static int Part1(string[] report)
    {
        int[] counter = new int[12];
        StringBuilder gamma = new();
        StringBuilder epsilon = new();
        foreach (var item in report)
        {
            for (int i = 0; i < 12; i++)
            {
                if (item[i] == '1')
                {
                    counter[i]++;
                }
            }
        }

        for (int i = 0; i < 12; i++)
        {
            if (counter[i] < report.Length / 2)
            {
                gamma.Append('0');
                epsilon.Append('1');
            }
            else
            {
                gamma.Append('1');
                epsilon.Append('0');
            }
        }
        
        var result = Convert.ToInt32(gamma.ToString(), 2) * Convert.ToInt32(epsilon.ToString(), 2);
        return result;
    }
    public static int Part2(string[] _report)
    {

        return 0;
    }   
}
