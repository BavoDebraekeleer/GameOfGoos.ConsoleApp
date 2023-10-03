using GameOfGoose.GameRules;

namespace GameOfGoose;

public class RulesTests
{
    // FirstDiceRollGameRule
    [Fact]
    public void ShouldSetGoosePositionToDependingOnFirstDiceRoll()
    {
        // 1. Arrange
        var diceRollToCheck = new int[]{ 6, 3 };
        var diceRoll = new int[] { 3, 6 };
        var positionToGo = 26;
        var gameRule = new FirstDiceRollGameRule("", diceRollToCheck, positionToGo);
        var gooseList = new List<Goose>
        {
            new Goose(),
        };
        var currentGoose = 0;

        // 2. Act
        gameRule.DoGameRuleCheck(gooseList, currentGoose, diceRoll);
        gooseList[currentGoose].GoToPosition();

        // 3. Assert
        Assert.Equal(positionToGo, gooseList[currentGoose].Position);
    }

    // OccupiedSpaceGameRule
    [Fact]
    public void ShouldSwapGoosePositions()
    {
        // 1. Arrange
        var gameRule = new OccupiedSpaceGameRule("");
        var gooseList = new List<Goose>
        {
            new Goose(),
            new Goose(),
        };
        var currentGoose = 1;
        var diceRoll = new int[] { 5, 5 };

        gooseList[0].Position = 10;
        gooseList[0].PositionToGo = 10;
        gooseList[currentGoose].Position = 0;
        gooseList[currentGoose].PositionToGo = 10;

        // 2. Act
        gameRule.DoGameRuleCheck(gooseList, currentGoose, diceRoll);

        // 3. Assert
        Assert.Equal(0, gooseList[0].PositionToGo);
        Assert.Equal(10, gooseList[currentGoose].PositionToGo);
    }

    [Fact]
    public void ShouldSetGoosePositionsEqualAndUnstuckTheOtherGoose()
    {
        // 1. Arrange
        var gameRule = new OccupiedSpaceGameRule("");
        var gooseList = new List<Goose>
        {
            new Goose(),
            new Goose(),
            new Goose(),
        };
        var currentGoose = 2;
        var diceRoll = new int[] { 5, 5 };

        gooseList[0].isStuck = false;
        gooseList[0].Position = 10;
        gooseList[0].PositionToGo = 10;
        gooseList[1].isStuck = true;
        gooseList[1].Position = 10;
        gooseList[1].PositionToGo = 10;
        gooseList[currentGoose].isStuck = false;
        gooseList[currentGoose].Position = 0;
        gooseList[currentGoose].PositionToGo = 10;

        // 2. Act
        gameRule.DoGameRuleCheck(gooseList, currentGoose, diceRoll);

        // 3. Assert
        Assert.False(gooseList[1].isStuck);
        Assert.Equal(10, gooseList[0].PositionToGo);
        Assert.Equal(10, gooseList[1].PositionToGo);
        Assert.Equal(10, gooseList[currentGoose].PositionToGo);
    }

    // GooseSpaceGameRule
    [Fact]
    public void ShouldLandOnGooseSpaceFollowedTwiceByOccupiedSpace()
    {
        // 1. Arrange
        var gameRule = new GooseSpaceGameRule("", new int[] { 5 });
        var gooseList = new List<Goose>
        {
            new Goose(),
            new Goose(),
            new Goose(),
        };
        var currentGoose = 2;
        var diceRoll = new int[] { 2, 3 };

        gooseList[0].Position = 10;
        gooseList[0].PositionToGo = 10;
        gooseList[1].Position = 15;
        gooseList[1].PositionToGo = 15;
        gooseList[currentGoose].Position = 0;
        gooseList[currentGoose].PositionToGo = 5;

        // 2. Act
        gameRule.DoGameRuleCheck(gooseList, currentGoose, diceRoll);

        // 3. Assert
        Assert.Equal(10, gooseList[0].PositionToGo);
        Assert.Equal(15, gooseList[1].PositionToGo);
        Assert.Equal(20, gooseList[currentGoose].PositionToGo);
    }

    // IHazardSpaceGameRules
    // GoToHazardSpaceGameRule
    [Fact]
    public void ShouldGoToSpecifiedPositionIfLandsOnHazardSpace()
    {
        // 1. Arrange
        var hazardSpaceName = "The Hotel";
        var hazardSpacePosition = 6;
        var positionToGo = 12;
        var gameRule = new GoToHazardSpaceGameRule("", hazardSpaceName, hazardSpacePosition, positionToGo);
        var gooseList = new List<Goose>
        {
            new Goose(),
        };
        var currentGoose = 0;
        gooseList[0].PositionToGo = hazardSpacePosition;
        var diceRoll = new int[] { 3, 3 };

        // 2. Act
        gameRule.DoGameRuleCheck(gooseList, currentGoose, diceRoll);

        // 3. Assert
        Assert.Equal(positionToGo, gooseList[currentGoose].PositionToGo);
    }

    // SkipTurnHazardSpaceGameRule
    [Fact]
    public void ShouldSetSkipTurnIfLandsOnHazardSpace()
    {
        // 1. Arrange
        var hazardSpaceName = "The Hotel";
        var hazardSpacePosition = 19;
        var gameRule = new SkipTurnHazardSpaceGameRule("", hazardSpaceName, hazardSpacePosition);
        var gooseList = new List<Goose>
        {
            new Goose(),
        };
        var currentGoose = 0;
        gooseList[0].PositionToGo = hazardSpacePosition;
        var diceRoll = new int[] { 3, 3 };

        // 2. Act
        gameRule.DoGameRuleCheck(gooseList, currentGoose, diceRoll);

        // 3. Assert
        Assert.True(gooseList[currentGoose].isSkip);
    }

    // StuckHazardSpaceGameRule
    [Fact]
    public void ShouldSetIsStuckIfLandsOnHazardSpace()
    {
        // 1. Arrange
        var hazardSpaceName = "The Well";
        var hazardSpacePosition = 31;
        var gameRule = new StuckHazardSpaceGameRule("", hazardSpaceName, hazardSpacePosition);
        var gooseList = new List<Goose>
        {
            new Goose(),
        };
        var currentGoose = 0;
        gooseList[0].PositionToGo = hazardSpacePosition;
        var diceRoll = new int[] { 3, 3 };

        // 2. Act
        gameRule.DoGameRuleCheck(gooseList, currentGoose, diceRoll);

        // 3. Assert
        Assert.True(gooseList[currentGoose].isStuck);
    }
}
