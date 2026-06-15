namespace tests;

using FluentAssertions;
using src;

public class CaffeineBuzzShould
{
    [Fact]
    public void ReturnMochaMissing_WhenInvoked_GivenIntergerOfOne()
    {
        var result = Kata.CaffeineBuzz(1);
        
        result.Should().Be("mocha_missing!");
    }

    [Theory]
    [InlineData(3)]
    [InlineData(9)]
    public void ReturnJave_WhenInvoked_GivenIntegerDivisibleByThree(int inputInteger)
    {
        var result = Kata.CaffeineBuzz(inputInteger);
        result.Should().Be("Java");
    }

    [Theory]
    [InlineData(12)]
    public void ReturnCoffee_WhenInvoked_GivenIntegerDivisibleByThreeAndFour(int inputInteger)
    {
        var result = Kata.CaffeineBuzz(inputInteger);

        result.Should().Be("CoffeeScript");
    }
    
    [Theory]
    [InlineData(6)]
    [InlineData(18)]
    public void ReturnJavaScript_WhenInvoked_GivenIntegerDivisibleByThree(int inputInteger)
    {
        var result = Kata.CaffeineBuzz(inputInteger);
        result.Should().Be("JavaScript");
    }
}
