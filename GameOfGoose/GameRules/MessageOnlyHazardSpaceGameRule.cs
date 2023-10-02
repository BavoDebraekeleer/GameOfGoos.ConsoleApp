namespace GameOfGoose.GameRules;

public class MessageOnlyHazardSpaceGameRule : GameRule, IHazardSpaceGameRule
{
    public override string Message { get; set; }
    public string Name { get; set; }
    public int HazardSpacePosition { get; set; }

    public MessageOnlyHazardSpaceGameRule(string message, string name, int hazardSpacePosition)
    {
        Message = message;
        Name = name;
        HazardSpacePosition = hazardSpacePosition;
    }

    public override void DoRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll)
    {
        // Nothing to check.
    }
}
