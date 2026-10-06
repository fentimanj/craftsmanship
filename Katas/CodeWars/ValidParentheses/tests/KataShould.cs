namespace tests;

using FluentAssertions;
using src;

public class KataShould
{
    [Theory]
    [InlineData("(", false)]
    [InlineData("()", true)]
    [InlineData("()()", true)]
    [InlineData("()()()", true)]
    [InlineData("(())", true)]
    [InlineData("((()))", true)]
    public void ReturnFalse_WhenValidParenthesesInvoked_GivenOneBracket(string input, bool expected)
    {
        Kata.ValidParentheses(input).Should().Be(expected);
    }


    [Fact]
    public void TestValidParentheses()
    {
        this.DoTest(true, "()");
        this.DoTest(true, "((()))");
        this.DoTest(true, "()()()");
        this.DoTest(true, "(()())()");
        this.DoTest(true, "()(())((()))(())()");
    }

    [Fact]
    public void TestInvalidParentheses()
    {
        this.DoTest(false, ")(");
        this.DoTest(false, "()()(");
        this.DoTest(false, "((())");
        this.DoTest(false, "())(()");
        this.DoTest(false, ")()");
        this.DoTest(false, ")");
    }

    [Fact]
    public void TestEmptyString()
    {
        this.DoTest(true, "");
    }


    private void DoTest(bool expected, string str)
    {
        Kata.ValidParentheses(str).Should().Be(expected);
    }
}