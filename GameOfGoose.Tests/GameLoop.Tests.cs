using GameOfGoose.GameRules;
using GameOfGoose.Messengers;

namespace GameOfGoose;

public class GameLoopTests
{
    [Fact]
    public void ShouldCreateGooseListOfSpecificSize()
    {
        // 1. Arrange
        var diceSides = 6;
        var diceAmount = 2;
        var dice = new Dice(diceSides, diceAmount);
        var amountOfPlayers = 5;
        var gameRulesList = new List<GameRule>
        {
            new FirstDiceRollGameRule("", new int[] { 6, 3 }, 26)
        };
        var gameOverPosition = 63;
        var messenger = new ConsoleMessenger();

        // 2. Act
        var gameLoop = new GameLoop(amountOfPlayers, dice, gameRulesList, gameOverPosition, messenger);

        // 3. Assert
        Assert.Equal(amountOfPlayers, gameLoop.GooseList.Count);
    }
}
