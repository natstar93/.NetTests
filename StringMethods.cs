using System;
using Xunit;

namespace XUnitTestProject
{
    public class StringMethods
    {
        [Fact]
        public void StartsWith()
        {
            string name = "Natalie";
            Assert.StartsWith("N", name);
            // Not happy if I try and do Assert.True(name.StartsWith("N"));
        }

        [Fact]
        public void IsNullOrEmpty()
        {
            Assert.True(String.IsNullOrEmpty(""));
            Assert.True(String.IsNullOrEmpty(null));
            Assert.False(String.IsNullOrEmpty("Hey Nat"));
        }

        [Fact]
        public void TrimMethods()
        {
            string trimmableString = "   in the middle   ";
            Assert.Equal("in the middle", trimmableString.Trim());
            Assert.Equal("in the middle   ", trimmableString.TrimStart());
            Assert.Equal("   in the middle", trimmableString.TrimEnd());
        }

        [Fact]
        public void CopyTo()
        {
            char[] destination = { 'o', 'l', 'd', ' ', 't', 'h', 'i', 'n', 'g' };
            string str = "new";
            str.CopyTo(0, destination, 0, 3);
            char[] expected = { 'n', 'e', 'w', ' ', 't', 'h', 'i', 'n', 'g' };
            Assert.Equal(expected, destination);
            Assert.Equal("new thing", String.Join("", expected));
        }

        [Fact]
        public void Insert()
        {
            string originalString = "natstar learning C#";
            string expectedString = "natstar is learning C#";
            string actualString = originalString.Insert(8, "is ");
            Assert.Equal(expectedString, actualString);
        }

        [Fact]
        public void Compare()
        {
            string firstName = "Natalie";
            string lastName = "Akam";
            Assert.Equal(1, String.Compare(firstName, lastName));
            Assert.Equal(-1, String.Compare(lastName, firstName));
            Assert.Equal(0, String.Compare(firstName, firstName));
        }
    }
}
    