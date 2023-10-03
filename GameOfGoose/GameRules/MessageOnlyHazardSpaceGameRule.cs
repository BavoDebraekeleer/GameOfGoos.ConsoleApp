namespace GameOfGoose.GameRules;

public class MessageOnlyHazardSpaceGameRule : GameRule, IHazardSpaceGameRule
{
    public override string Message { get; set; }
    public string Name { get; set; }
    public int HazardSpacePosition { get; set; }

    public MessageOnlyHazardSpaceGameRule(string message, string name, int hazardSpacePosition)
    {
        Message = $"Landed on Hazard Space: {name}. {message}";
        Name = name;
        HazardSpacePosition = hazardSpacePosition;
    }

    public override bool DoGameRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll)
    {
        if (gooseList[currentGoose].PositionToGo == HazardSpacePosition)
        {
            return true;
        }
        return false;
    }
}
