namespace GameOfGoose;

public class DiceTests
{
    [Fact]
    public void ShouldReturnArrayWithTwoInts()
    {
        // 1. Arrange
        var diceSides = 6;
        var diceAmount = 2;
        var dice = new Dice(diceSides, diceAmount);

        // 2. Act
        var result = dice.RollDice();

        // 3. Assert
        Assert.Equal(diceAmount, result.Length);
        Assert.True(result[0] > 0 && result[0] <= diceSides);
    }
}
