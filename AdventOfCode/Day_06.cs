using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    if (school[i].daysToSpawn == 0)
                    {
                        school.Add(new Lanternfish());
                    }
                    school[i].Countdown();
                }
            }
            
            return school.Count;
        }

        public static long Part2(int[] inputs)
        {
            SortedDictionary<int, long> largeSchool = PopulateList2(inputs);
            for (int i = 0; i < 32; i++)
            {
                largeSchool[8] += largeSchool[0];
                largeSchool[6] += largeSchool[0];
                largeSchool[0] = 0;

                largeSchool[0] += largeSchool[1];
                largeSchool[7] += largeSchool[1];
                largeSchool[1] = 0;

                largeSchool[1] += largeSchool[2];
                largeSchool[8] += largeSchool[2];
                largeSchool[2] = 0;

                largeSchool[2] += largeSchool[3];
                largeSchool[0] += largeSchool[3];
                largeSchool[3] = 0;

                largeSchool[3] += largeSchool[4];
                largeSchool[1] += largeSchool[4];
                largeSchool[4] = 0;

                largeSchool[4] += largeSchool[5];
                largeSchool[2] += largeSchool[5];
                largeSchool[5] = 0;

                largeSchool[5] += largeSchool[6];
                largeSchool[3] += largeSchool[6];
                largeSchool[6] = 0;

                largeSchool[6] += largeSchool[7];
                largeSchool[4] += largeSchool[7];
                largeSchool[7] = 0;

                largeSchool[7] += largeSchool[8];
                largeSchool[5] += largeSchool[8];
                largeSchool[8] = 0;

            }
            var result = largeSchool.Sum(x => x.Value);
            
            return result;
        }

        public static List<Lanternfish> PopulateList(int[] inputs)
        {
            List<Lanternfish> school = new();
            for (int i = 0;i < inputs.Length; i++)
            {
                school.Add(new Lanternfish { daysToSpawn = inputs[i] });
            }
            return school;
        }
        public static SortedDictionary<int, long> PopulateList2(int[] inputs)
        {
            var school = new SortedDictionary<int, long>
            {
                {0,0 },
                {1,0 },
                {2,0 },
                {3,0 },
                {4,0 },
                {5,0 },
                {6,0 },
                {7,0 },
                {8,0 }
            };
            foreach (var item in inputs)
            {               
               school[item]++;
            }
            return school;
        }

    }
    public class Lanternfish
    {
        public int daysToSpawn { get; set; } = 9;
        public void Countdown()
        {
            if (daysToSpawn == 0)
            {
                daysToSpawn = 6;
            }
            else
                daysToSpawn--;
        }
        
    }
}
