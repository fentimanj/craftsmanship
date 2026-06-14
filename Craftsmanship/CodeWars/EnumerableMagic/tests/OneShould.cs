namespace tests;

using FluentAssertions;

public class OneShould
{
    [Fact]
    public void ReturnFalse_WhenInvoked_GivenEmptySequenceAndSimpleFunction()
    {
        int[] emptyArray = [];
        bool InputFunction(int valueFromSequence) => valueFromSequence == 1;
        
        bool result = Kata.One(emptyArray, InputFunction);

        result.Should().BeFalse();
    }

    [Fact]
    public void ReturnTrue_WhenInvoked_GivenSingleOneInSequenceAndMatchingFunction()
    {
        int[] inputArray = [1];
        bool InputFunction(int valueFromSequence) => valueFromSequence == 1;
        
        bool result = Kata.One(inputArray, InputFunction);
        result.Should().BeTrue();
    } 
    
    [Fact]
    public void ReturnFalse_WhenInvoked_GivenSingleOneInSequenceAndNonMatchingFunction()
    {
        int[] inputArray = [2];
        bool InputFunction(int valueFromSequence) => valueFromSequence == 1;
        
        bool result = Kata.One(inputArray, InputFunction);
        result.Should().BeFalse();
    }
}