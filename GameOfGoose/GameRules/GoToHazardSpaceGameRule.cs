namespace GameOfGoose.GameRules;

public class GoToHazardSpaceGameRule : GameRule, IHazardSpaceGameRule
{
    public override string Message { get; set; }
    public string Name { get; set; }
    public int HazardSpacePosition { get; set; }

    private int _positionToGo;

    public GoToHazardSpaceGameRule(string message, string name, int hazardSpacePosition, int positionToGo)
    {
        Message = message;
        Name = name;
        HazardSpacePosition = hazardSpacePosition;
        _positionToGo = positionToGo;
    }

    public override void DoRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll)
    {
        if (gooseList[currentGoose].PositionToGo == HazardSpacePosition)
        {
            gooseList[currentGoose].PositionToGo = _positionToGo;
        }
    }
}
