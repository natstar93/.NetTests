using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class Tuples
    {
        [Fact]
        public void AccessesTupleCorrectly()
        {
            (int, string) myTuple = (4, "four");
            Assert.Equal(4, myTuple.Item1);
            Assert.Equal("four", myTuple.Item2);
        }

        [Fact]
        public void AccessesTupleWithFieldNamesCorrectly()
        {
            (int myInt, string myString) myTuple = (4, "four");
            Assert.Equal(4, myTuple.myInt);
            Assert.Equal("four", myTuple.myString);
        }

        [Fact]
        public void AccessesBigTupleCorrectly()
        {
            var bigTuple = (1, 2, 3, 4, 5, 6, "seven", "eight", "nine", true, 11.1);
            Assert.Equal(2, bigTuple.Item2);
            Assert.Equal("seven", bigTuple.Item7);
            Assert.True(bigTuple.Item10);
            Assert.Equal(11.1, bigTuple.Item11);
        }

        [Fact]
        public void Equality()
        {
            (int myNum, double myOtherNum) tuple1 = (1, 'a');
            (short myNum, long myOtherNum) tuple2 = (1, 'a');
            Assert.Equal(tuple1, tuple2);

            var namedTuple = (Name1: "Nat", Name2: "Steph");
            var namedTuple2 = (Name1: "Steph", Name2: "Nat");
            var namedTuple3 = (Name2: "Steph", Name1: "Nat");

            Assert.NotEqual(namedTuple, namedTuple2);
            Assert.Equal(namedTuple2, namedTuple3);
            Assert.NotEqual(namedTuple, namedTuple3);
        }

    }
}
