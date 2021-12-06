using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AdventOfCode;
public class Day_03 : BaseDay
{
    private readonly string[] _report;
    public Day_03()
    {
        _report = File.ReadAllLines(InputFilePath);
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

    //public static int Part2(string[] report)
    //{
    //    var oxygenRating = OxygenRater(report);
    //    var co2Rating = CarbonDioxideRater(report);
    //    var result = Convert.ToInt32(oxygenRating.ToString(), 2) * Convert.ToInt32(co2Rating.ToString(), 2);
    //    return result;
    //}

    public static int Part2(string[] report)
    {
        var oxygenRating = Rater(report, b => b < 0);
        var co2Rating = Rater(report, b => b > 0);
        var result = Convert.ToInt32(oxygenRating.ToString(), 2) * Convert.ToInt32(co2Rating.ToString(), 2);
        return result;
    }

    public static string Rater(IEnumerable<string> report, Func<int, bool> predicate)
    {
        var binaryInputs = report.ToArray();
        var index = 0;
        while (binaryInputs.Length > 1)
        {
            var counter = SetCounter(binaryInputs, index);
            var compareTarger = predicate(counter) ? '0':'1';
            binaryInputs = binaryInputs.Where(s => s[index] == compareTarger).ToArray();
            index++;
        }
        return binaryInputs[0];
    }

    public static string OxygenRater(string[] report)
    {
        List<string> inputs = report.ToList();
        
        for (int i = 0; i < inputs[0].Length; i++)
        {
            var counter = SetCounter(inputs, i);
            inputs = RemoveRendunantOxy(inputs, counter, i);

            if (inputs.Count == 1)
                break;
        }
        return inputs[0];
    }

    public static List<string> RemoveRendunantOxy(List<string> oxygenRating, int count, int i)
    {       
        if (count < 0)
        {
            return oxygenRating.Where(x => x.ElementAt(i) == '0').ToList();
        }
        else
        {
            return oxygenRating.Where(x => x.ElementAt(i) == '1').ToList();
        }                 
    }
    public static int SetCounter(IEnumerable<string> report, int i)
    {
        int count = 0;
        foreach(var item in report)
        {
            if (item[i] == '1')
            {
                count++;
            }
            else
            {
                count--;
            }
        }
        return count;
    }
    public static string CarbonDioxideRater(string[] report)
    {
        List<string> inputs = report.ToList();
        for (int i = 0; i <= report[0].Length; i++)
        {
            var counter = SetCounter(inputs, i);            
            inputs = RemoveRendunantCO2(inputs, counter, i);
            
            if (inputs.Count == 1)
                break;
        }
        return inputs[0];
    }
    public static List<string> RemoveRendunantCO2(List<string> oxygenRating, int count, int i)
    {
        if (count < 0)
        {
            return oxygenRating.Where(x => x.ElementAt(i) == '1').ToList();
        }
        else
        {
            return oxygenRating.Where(x => x.ElementAt(i) == '0').ToList();
        }
    }    
}
