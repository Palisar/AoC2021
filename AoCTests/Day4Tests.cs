using AdventOfCode;
using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AoCTests
{
    public class Day4Tests
    {
        private readonly string[] inputs;
        public Day4Tests()
        {
            inputs = File.ReadAllLines(@"Inputs\04InputTest.txt");
        }
        [Fact]
        public void Part1()
        {
            var inputs = new[] { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };
            var data = new List<int?[,]>
            { new int?[,]

                {   {22, 13, 17, 11,  0},
                    { 8,  2, 23,  4, 24},
                    {21,  9, 14, 16,  7},
                    { 6, 10,  3, 18,  5},
                    { 1, 12, 20, 15, 19}
            },
            {
            new int?[,]
                {   { 3,  15,  0,  2, 22},
                    { 9,  18, 13, 17,  5},
                    { 19,  8,  7, 25, 23},
                    { 20, 11, 10, 24,  4},
                    { 14, 21, 16, 12,  6}
            }
            },
            {
                new int?[,]
                {   {14, 21, 17, 24,  4},
                    {10, 16, 15,  9, 19},
                    {18,  8, 23, 26, 20},
                    {22, 11, 13,  6,  5},
                    { 2,  0, 12,  3,  7}}
            } };
            var actual = Day_04.Part1(inputs, data);
            Assert.Equal(4512, actual);
        }

        [Fact]
        public void Test1BoardHorizontal()
        {
            var inputs = new[] { 22, 13, 17, 11, 0 };
            var board = new List<int?[,]> 
            { new int?[,]
                {   {22, 13, 17, 11,  0},
                    { 8,  2, 23,  4, 24},
                    {21,  9, 14, 16,  7},
                    { 6, 10,  3, 18,  5},
                    { 1, 12, 20, 15, 19}
                }
            };
            var actual = Day_04.Part1(inputs, board);
            Assert.Equal(0, actual);
        }
        [Fact]
        public void Test1BoardVerticalPos0()
        {
            var inputs = new[] { 22, 8, 21, 6, 1 };
            var board = new List<int?[,]> 
            { new int?[,]

                {   {22, 13, 17, 11,  0},
                    { 8,  2, 23,  4, 24},
                    {21,  9, 14, 16,  7},
                    { 6, 10,  3, 18,  5},
                    { 1, 12, 20, 15, 19}
                }
            };
            var actual = Day_04.Part1(inputs, board);
            Assert.Equal(242, actual);
        }

        [Fact]
        public void Test1BoardVerticalPos1()
        {
            var inputs = new[] { 13, 2, 9, 10, 12 };
            var board = new List<int?[,]>
            { new int?[,]

                {   {22, 13, 17, 11,  0},
                    { 8,  2, 23,  4, 24},
                    {21,  9, 14, 16,  7},
                    { 6, 10,  3, 18,  5},
                    { 1, 12, 20, 15, 19}
                }
            };
            var actual = Day_04.Part1(inputs, board);
            Assert.Equal(242, actual);
        }
        [Fact]
        public void Correctly_bingo()
        {
            var board = new int?[,] {
                { 0, 13, 17, 11,  5},
                { null,  null, null,  null, null},
                { 21,  9, 14, 16,  7},
                { 6, 10,  3, 18,  5},
                { 1, 12, 20, 15, 19}
            };

            Assert.True(Day_04.CheckBingo(board));
        }
        //[Fact]
        //public void BoardCreationTest()
        //{
        //    string[] input = {" 1 54 88 45 90",
        //                      "81 78 19  8 40",
        //                      "17 74 69 87 33",
        //                      "9 64 85 50 71",
        //                      "92 38 65 82 41" };

        //}

        [Fact]
        public void Part2()
        {
            {
                var inputs = new[] { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };
                var data = new List<int?[,]>
            { new int?[,]

                {   {22, 13, 17, 11,  0},
                    { 8,  2, 23,  4, 24},
                    {21,  9, 14, 16,  7},
                    { 6, 10,  3, 18,  5},
                    { 1, 12, 20, 15, 19}
            },
            {
            new int?[,]
                {   { 3,  15,  0,  2, 22},
                    { 9,  18, 13, 17,  5},
                    { 19,  8,  7, 25, 23},
                    { 20, 11, 10, 24,  4},
                    { 14, 21, 16, 12,  6}
            }
            },
            {
                new int?[,]
                {   {14, 21, 17, 24,  4},
                    {10, 16, 15,  9, 19},
                    {18,  8, 23, 26, 20},
                    {22, 11, 13,  6,  5},
                    { 2,  0, 12,  3,  7}}
            } };
                var actual = Day_04.Part2(inputs, data);
                Assert.Equal(1924, actual);
            }
        }
    }
}
