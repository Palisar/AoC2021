using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace AoCTests
{
    public class Day6Tests
    {
        [Fact]
        public void Part1()
        {
            var data = new[] { 3, 4, 3, 1, 2 };
            var actual = Day_06.Part1(data);
            Assert.Equal(5934, actual);
        }
        [Fact]
        public void Part2()
        {
            var data = new[] { 3, 4, 3, 1, 2 };
            var actual = Day_06.Part2(data);
            actual.Should().Be(26984457539);
        }
        //[Fact]
        //public void Populate2Test()
        //{
        //    var data = new[] { 3, 4,  0, 3, 0, 1, 2 , 5,  2 , 4 };
        //    var actual = Day_06.PopulateList2(data);
        //    Assert.Equal(new SortedDictionary<int, long> { { 0, 2 }, { 1, 1 }, { 2, 2 }, { 3, 2 }, { 4, 2 }, { 5, 1 }, { 6, 0 },{ 7, 0 },{ 8, 0 } }, actual);
        //}
        //[Fact]
        //public void Populate2Sanity()
        //{
        //    var data = new[] { 0 , 1, 2, 3,4,5 };
        //    var dict = new SortedDictionary<int, long>
        //    {
        //        [0] = 1,
        //        [1] = 1,
        //        [2] = 1,
        //        [3] = 1,
        //        [4] = 1,
        //        [5] = 1,
        //        [6] = 0,
        //        [7] = 0,
        //        [8] = 0
        //    };
        //    var actual = Day_06.PopulateList2(data);
        //    actual.Should().BeEquivalentTo(dict);
        //}
        //[Fact]
        //public void NextDaySanityTest()
        //{
        //    var data = new SortedDictionary<int, long>
        //    {
        //        [0] = 1,
        //        [1] = 0,
        //        [2] = 0,
        //        [3] = 0,
        //        [4] = 0,
        //        [5] = 0,
        //        [6] = 0,
        //        [7] = 0,
        //        [8] = 0
        //    };
        //    var actual = Day_06.NextDay(data, 0);
        //    actual.Should().BeEquivalentTo(new SortedDictionary<int, long> 
        //    {
        //        { 0,0 },
        //        { 1,0 },
        //        { 2,0 },
        //        { 3,0 },
        //        { 4,0 },
        //        { 5,0 },
        //        { 6,1 },
        //        { 7,0 },
        //        { 8,1 }
        //    });
        //}

        [Fact]
        public void NextDaySanityTestDay6()
        {
            var data = new[] { 0 };
            var actual = Day_06.Part2(data);
            Assert.Equal(3, actual);
        }

        [Fact]
        public void NextDaySanityTestDay3()
        {
            var data = new[] { 0 , 1, 2, 3, 4, 5};
            var actual = Day_06.Part2(data);
            Assert.Equal(10, actual);
        }
    }
}
