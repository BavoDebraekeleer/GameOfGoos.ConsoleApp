namespace GameOfGoose.GameRules;

/// <summary>
/// Game Rule for the first dice roll of a Goose.
/// Detected by its position being zero.
/// If the dice roll check is true, the PositionToGo is set.
/// </summary>
public class FirstDiceRollGameRule : GameRule
{
    public override string Message { get; set; }

    private int[] _diceRollToCheck;
    private int _positionToGo;

    public FirstDiceRollGameRule(string message, int[] diceRollToCheck, int positionToGo)
    {
        Message = message;
        _diceRollToCheck = diceRollToCheck;
        Array.Sort(_diceRollToCheck);
        _positionToGo = positionToGo;
    }

    public override bool DoGameRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll)
    {
        if (gooseList[currentGoose].Position == 0)
        {
            Array.Sort(diceRoll);
            if (diceRoll.SequenceEqual(_diceRollToCheck))
            {
                gooseList[currentGoose].PositionToGo = _positionToGo;
                return true;
            }
        }
        return false;
    }
}
