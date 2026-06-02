namespace tests;

using FluentAssertions;
using src;

public class KataShould
{
    [Fact]
    public void ReturnFalse_WhenValidParenthesesInvoked_GivenOneBracket()
    {
        var input = "(";

        Kata.ValidParentheses(input).Should().BeFalse();
    }

    [Fact]
    public void ReturnTrue_WhenValidParenthesesInvoked_GivenOpenAndCloseBrackets()
    {
        var input = "()";

        Kata.ValidParentheses(input).Should().BeTrue();
    }

    /*
    [Fact]
    public void TestValidParentheses()
    {
        DoTest(true, "()");
        DoTest(true, "((()))");
        DoTest(true, "()()()");
        DoTest(true, "(()())()");
        DoTest(true, "()(())((()))(())()");
    }

    [Fact]
    public void TestInvalidParentheses()
    {
        DoTest(false, ")(");
        DoTest(false, "()()(");
        DoTest(false, "((())");
        DoTest(false, "())(()");
        DoTest(false, ")()");
        DoTest(false, ")");
    }

    [Fact]
    public void TestEmptyString()
    {
        DoTest(true, "");
    }

    private void DoTest(bool expected, string str)
    {
        Kata.ValidParentheses(str).Should().Be(expected);
    }
    */
}