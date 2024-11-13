using System;
using System.IO;
using Xunit;

public class ProgramTests
{
    [Theory]
    [InlineData("123", true)]
    [InlineData("0", false)]
    [InlineData("-123", false)]
    [InlineData("abc", false)]
    [InlineData("", false)]
    public void Test_IsPositiveInteger(string input, bool expected)
    {
        Assert.Equal(expected, Program.IsPositiveInteger(input));
    }

    [Fact]
    public void Test_GenerateLuckyNumbers_CountMatchesExpectedForLimit10()
    {
        int count = 0;
        Program.GenerateLuckyNumbers("", "10", ref count);
        Assert.Equal(2, count); // "4" and "7" are the valid lucky numbers within the limit of 10
    }

    [Fact]
    public void Test_GenerateLuckyNumbers_CountMatchesExpectedForLimit50()
    {
        int count = 0;
        Program.GenerateLuckyNumbers("", "50", ref count);
        Assert.Equal(6, count); // "4", "7", "44", "47", "74", and "77" are valid
    }

    [Fact]
    public void Test_GenerateLuckyNumbers_CountMatchesExpectedForLimit100()
    {
        int count = 0;
        Program.GenerateLuckyNumbers("", "100", ref count);
        Assert.Equal(14, count); // Includes all valid lucky numbers up to 100
    }

    [Fact]
    public void Test_GenerateLuckyNumbers_NoLuckyNumbersWhenLimitIs3()
    {
        int count = 0;
        Program.GenerateLuckyNumbers("", "3", ref count);
        Assert.Equal(0, count); // No lucky numbers less than or equal to 3
    }

    [Fact]
    public void Test_GenerateLuckyNumbers_CountMatchesForExactLuckyNumberLimit()
    {
        int count = 0;
        Program.GenerateLuckyNumbers("", "47", ref count);
        Assert.Equal(5, count); // "4", "7", "44", "47", "74"
    }
}