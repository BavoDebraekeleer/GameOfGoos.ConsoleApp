namespace GameOfGoose.GameRules;

public class GooseSpaceGameRule : GameRule
{
    public override string Message { get; set; }

    private int[] _gooseSpacePositions;

    public GooseSpaceGameRule(string message, int[] gooseSpaces)
    {
        Message = message;
        _gooseSpacePositions = gooseSpaces;
    }
    public override void DoRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll)
    {
        foreach (var gooseSpacePosition in _gooseSpacePositions)
        {
            if (gooseList[currentGoose].PositionToGo == gooseSpacePosition)
            {
                gooseList[currentGoose].PositionToGo += diceRoll.Sum();

                while (OccupiedSpaceCheck(gooseList, currentGoose, diceRoll));
            }
        }
    }

    public bool OccupiedSpaceCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll)
    {
        foreach (var goose in gooseList)
        {
            if (goose.Position == gooseList[currentGoose].PositionToGo)
            {
                gooseList[currentGoose].PositionToGo += diceRoll.Sum();
                return true;
            }
        }
        return false;
    }
}
