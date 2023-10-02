namespace GameOfGoose.GameRules;

/// <summary>
/// Base class for the individual game rules.
/// </summary>
public abstract class GameRule
{
    public abstract string Message { get; set; }
    public abstract void DoRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll);
}
