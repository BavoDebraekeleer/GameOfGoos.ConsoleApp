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
    public override bool DoGameRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll)
    {
        foreach (var gooseSpacePosition in _gooseSpacePositions)
        {
            if (gooseList[currentGoose].PositionToGo == gooseSpacePosition)
            {
                int diceRollTotal = diceRoll.Sum();
                gooseList[currentGoose].PositionToGo += diceRollTotal;
                Message += $" Gets to move forward again by {diceRollTotal}.";

                while (OccupiedSpaceCheck(gooseList, currentGoose, diceRollTotal)) ;
                return true;
            }
        }
        return false;
    }

    private bool OccupiedSpaceCheck(List<Goose> gooseList, int currentGoose, int diceRollTotal)
    {
        foreach (var goose in gooseList)
        {
            if (goose.Position == gooseList[currentGoose].PositionToGo)
            {
                gooseList[currentGoose].PositionToGo += diceRollTotal;
                Message += $" Space occupied by another goose. Move forward again by {diceRollTotal}.";
                return true;
            }
        }
        return false;
    }
}
