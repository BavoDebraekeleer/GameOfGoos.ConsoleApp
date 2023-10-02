namespace GameOfGoose.GameRules;

public class SkipTurnHazardSpaceGameRule : GameRule, IHazardSpaceGameRule
{
    public override string Message { get; set; }
    public string Name { get; set; }
    public int HazardSpacePosition { get; set; }

    public SkipTurnHazardSpaceGameRule(string message, string name, int hazardSpacePosition)
    {
        Message = message;
        Name = name;
        HazardSpacePosition = hazardSpacePosition;
    }

    public override void DoRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll)
    {
        if (gooseList[currentGoose].PositionToGo == HazardSpacePosition)
        {
            gooseList[currentGoose].isSkip = true;
        }
    }
}
