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

/*

Complete the function which takes a non-zero integer as its argument.
   
   If the integer is divisible by 3, return the string "Java".
   
   If the integer is divisible by 3 and divisible by 4, return the string "Coffee"
   
   If one of the condition above is true and the integer is even, add "Script" to the end of the string.
   
   If none of the condition is true, return the string "mocha_missing!"
   
   Examples
   
   1   -->  "mocha_missing!"
   3   -->  "Java"
   6   -->  "JavaScript"
   12  -->  "CoffeeScript"

*/