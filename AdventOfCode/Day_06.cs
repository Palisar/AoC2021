using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AdventOfCode
{
    public class Day_06 : BaseDay
    {

        private readonly string _input;
        private readonly int[] _numbers;

        public Day_06()
        {
            _input = File.ReadLines(InputFilePath).First();
            _numbers = _input.Split(',').Select(int.Parse).ToArray();
        }

        public override ValueTask<string> Solve_1()
        {
            return ValueTask.FromResult(Part1(_numbers).ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            return ValueTask.FromResult(Part2(_numbers).ToString());
        }

        public static int Part1(int[] inputs)
        {
            List<Lanternfish> school = PopulateList(inputs);
            for (int day = 0; day < 80; day++)
            {
                for (int i = 0; i < school.Count; i++)
                {
                    if (school[i].DaysToSpawn == 0)
                    {
                        school.Add(new Lanternfish());
                    }
                    school[i].Countdown();
                }
            }

            return school.Count;
        }
        
        public static long Part2(int[] input)
        {
            long[] currentDay = new long[9];
            foreach (var item in input)
            {
                currentDay[item]++;
            }
            for (int day = 0; day < 256; day++)
            {
                long[] nextDay = new long[9];
                for (int i = 0;i < currentDay.Length; i++)
                {
                    if (i == 0)
                    {
                        nextDay[6] += currentDay[i];
                        nextDay[8] += currentDay[i];
                    }
                    else
                    {
                        nextDay[i-1] += currentDay[i];
                    }
                }
                currentDay = nextDay;
            }

            return currentDay.Sum();
        }
       
        //public static SortedDictionary<int, long> NextDay(SortedDictionary<int, long> currentDay, int dayOfWeek)
        //{
        //    var nextDay = new SortedDictionary<int, long>(currentDay);
        //    switch (dayOfWeek)
        //    {
        //        case 0:
        //            nextDay[8] += nextDay[dayOfWeek];
        //            nextDay[6] += nextDay[dayOfWeek];
        //            nextDay[0] = 0;
        //            break;
        //        case 1:
        //            nextDay[0] += nextDay[dayOfWeek];
        //            nextDay[7] += nextDay[dayOfWeek];
        //            nextDay[1] = 0;
        //            break;
        //        case 2:
        //            nextDay[1] += nextDay[dayOfWeek];
        //            nextDay[8] += nextDay[dayOfWeek];
        //            nextDay[2] = 0;
        //            break;
        //        case 3:
        //            nextDay[2] += nextDay[dayOfWeek];
        //            nextDay[0] += nextDay[dayOfWeek];
        //            nextDay[3] = 0;
        //            break;
        //        case 4:
        //            nextDay[3] += nextDay[dayOfWeek];
        //            nextDay[1] += nextDay[dayOfWeek];
        //            nextDay[4] = 0;
        //            break;
        //        case 5:
        //            nextDay[4] += nextDay[dayOfWeek];
        //            nextDay[2] += nextDay[dayOfWeek];
        //            nextDay[5] = 0;
        //            break;
        //        case 6:
        //            nextDay[5] += nextDay[dayOfWeek];
        //            nextDay[3] += nextDay[dayOfWeek];
        //            nextDay[6] = 0;
        //            break;
        //        case 7:
        //            nextDay[6] += nextDay[dayOfWeek];
        //            nextDay[4] += nextDay[dayOfWeek];
        //            nextDay[7] = 0;
        //            break;
        //        case 8:
        //            nextDay[7] += nextDay[dayOfWeek];
        //            nextDay[5] += nextDay[dayOfWeek];
        //            nextDay[8] = 0;
        //            break;
        //    }
        //    return nextDay;
        //}

            
        public static List<Lanternfish> PopulateList(int[] inputs)
        {
            List<Lanternfish> school = new();
            for (int i = 0;i < inputs.Length; i++)
            {
                school.Add(new Lanternfish { DaysToSpawn = inputs[i] });
            }
            return school;
        }

        //public static SortedDictionary<int, long> PopulateList2(int[] inputs)
        //{
        //    var school = new SortedDictionary<int, long>
        //    {
        //        {0,0 },
        //        {1,0 },
        //        {2,0 },
        //        {3,0 },
        //        {4,0 },
        //        {5,0 },
        //        {6,0 },
        //        {7,0 },
        //        {8,0 },

        //    };
        //    foreach (var item in inputs)
        //    {               
        //       school[item]++;
        //    }
        //    return school;
        //}
    }
    public class Lanternfish
    {
        public int DaysToSpawn { get; set; } = 9;
        public void Countdown()
        {
            if (DaysToSpawn == 0)
            {
                DaysToSpawn = 6;
            }
            else
                DaysToSpawn--;
        }
    }
}
