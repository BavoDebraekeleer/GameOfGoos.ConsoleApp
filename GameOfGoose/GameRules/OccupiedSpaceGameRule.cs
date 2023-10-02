namespace GameOfGoose.GameRules;

/// <summary>
/// Game Rule to check if the PositionToGo space is occupied by another Goose.
/// If the other Goose isStuck (set by a Hazard space) it is released here.
/// The current Goose will be set to isStuck by the Hazard space Game Rule.
/// If the other Goose is not stuck, their positions are swapped.
/// </summary>
public class OccupiedSpaceGameRule : GameRule
{
    public override string Message { get; set; }

    public OccupiedSpaceGameRule(string message)
    {
        Message = message;
    }
    public override void DoRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll)
    {
        foreach (var goose in gooseList)
        {
            if (goose.Position == gooseList[currentGoose].PositionToGo)
            {
                if (goose.isStuck) // Stuck Goose gets released.
                {
                    goose.isStuck = false;
                    // isStuck of currentGoose will be set by other GameRule.
                }
                else
                {
                    goose.PositionToGo = gooseList[currentGoose].Position;
                }
            }
        }
    }
}
