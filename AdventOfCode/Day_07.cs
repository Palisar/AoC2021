using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day_07 : BaseDay
    {

        private readonly string _input;
        private readonly int[] _numbers;

        public Day_07()
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
        public static int Part1(int[] numbers)
        {
            var result = int.MaxValue;
            
            for (int j = 0; j < numbers.Max(); j++)
            {
                var fuelTotal = 0;
                for (int i = 0; i < numbers.Length; i++)
                    fuelTotal += Math.Abs(numbers[i] - j);
                
                if (fuelTotal < result)
                     result = fuelTotal;                
            }

            return result;
        }

        public static int Part2(int[] numbers)
        {
            var result = int.MaxValue;
            
            for (int j = 0; j < numbers.Max(); j++)
            {
                var fuelTotal = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    int tempCheck = Math.Abs(numbers[i] - j);
                    fuelTotal += (tempCheck * (tempCheck +1 ))/ 2;
                }

                if (fuelTotal < result)
                    result = fuelTotal;
            }

            return result;
        }
    }
}
