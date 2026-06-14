namespace tests;

using FluentAssertions;
using src;

public class OneShould
{
    [Fact]
    public void ReturnFalse_WhenInvoked_GivenEmptySequenceAndSimpleFunction()
    {
        int[] emptyArray = [];

        bool InputFunction(int valueFromSequence)
        {
            return valueFromSequence == 1;
        }

        var result = Kata.One(emptyArray, InputFunction);

        result.Should().BeFalse();
    }

    [Fact]
    public void ReturnTrue_WhenInvoked_GivenSingleOneInSequenceAndMatchingFunction()
    {
        int[] inputArray = [1];

        bool InputFunction(int valueFromSequence)
        {
            return valueFromSequence == 1;
        }

        var result = Kata.One(inputArray, InputFunction);
        result.Should().BeTrue();
    }

    [Fact]
    public void ReturnFalse_WhenInvoked_GivenSingleOneInSequenceAndNonMatchingFunction()
    {
        int[] inputArray = [2];

        bool InputFunction(int valueFromSequence)
        {
            return valueFromSequence == 1;
        }

        var result = Kata.One(inputArray, InputFunction);
        result.Should().BeFalse();
    }

    [Fact]
    public void ReturnFalse_WhenInvoked_GivenDuplicatedOneInSequenceAndMatchingFunction()
    {
        int[] inputArray = [1, 1];

        bool InputFunction(int valueFromSequence)
        {
            return valueFromSequence == 1;
        }

        var result = Kata.One(inputArray, InputFunction);
        result.Should().BeFalse();
    }

    [Fact]
    public void BasicTest1FromKata()
    {
        int[] inputArray = [1, 2, 3, 4, 5];
        var inputFunction = new Func<int, bool>(v => v < 2);

        var result = Kata.One(inputArray, inputFunction);
        result.Should().BeTrue();
    }

    [Fact]
    public void BasicTest2FromKata()
    {
        int[] inputArray = [1, 2, 3, 4, 5];
        var inputFunction = new Func<int, bool>(v => v % 2 != 0);

        var result = Kata.One(inputArray, inputFunction);
        result.Should().BeFalse();
    }

    [Fact]
    public void BasicTest3FromKata()
    {
        int[] inputArray = [1, 2, 3, 4, 5];
        var inputFunction = new Func<int, bool>(v => v > 5);

        var result = Kata.One(inputArray, inputFunction);
        result.Should().BeFalse();
    }
}