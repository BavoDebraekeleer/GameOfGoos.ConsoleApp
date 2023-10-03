namespace GameOfGoose.GameRules;

/// <summary>
/// Base class for the individual game rules.
/// </summary>
public abstract class GameRule
{
    /// <summary>
    /// Message to display when DoGameRuleCheck returns true.
    /// </summary>
    public abstract string Message { get; set; }

    /// <summary>
    /// Checks if the GameRule applies for the current turn.
    /// If the GameRule applies, the logic gets executed and returns true.
    /// If not, returns false.
    /// </summary>
    /// <param name="gooseList">A list of all Goose instances in the current game.</param>
    /// <param name="currentGoose">The index of the Goose who's turn it is.</param>
    /// <param name="diceRoll">The dice roll of the current turn.</param>
    /// <returns></returns>
    public abstract bool DoGameRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll);
}
