namespace GameOfGoose.GameRules;

/// <summary>
/// Game Rule to check if the PositionToGo space is occupied by another Goose.
/// If the other Goose isStuck (set by a Hazard space) it is released here.
/// In this case the current Goose will be set to isStuck by the Hazard space Game Rule.
/// If the other Goose is not stuck, their positions are swapped.
/// </summary>
public class OccupiedSpaceGameRule : GameRule
{
    public override string Message { get; set; }

    public OccupiedSpaceGameRule(string message)
    {
        Message = message;
    }
    public override bool DoGameRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll)
    {
        var isStuckFoundOnPositionToGo = false;
        var gooseOnPositionToGo = new Dictionary<int, bool>(); // <index, isStuck>

        // Goes over all Goose instances to check:
        // 1. If there is a already another Goose on the current turn's Goose's PositionToGo.
        // 2. If there is a stuck Goose on that position.
        for (int i = 0; i < gooseList.Count; i++)
        {
            if (gooseList[i].Position == gooseList[currentGoose].PositionToGo)
            {
                if (gooseList[i].isStuck)
                {
                    isStuckFoundOnPositionToGo = true;
                    gooseOnPositionToGo.Add(i, true);
                }
                else
                {
                    gooseOnPositionToGo.Add(i, false);
                }
            }
        }

        // If there is a stuck Goose, this Goose should get released,
        // without another Goose, that might have been released on another Goose's turn,
        // their position getting swapped with the current Goose.
        if (gooseOnPositionToGo is not null && gooseOnPositionToGo.Count is not 0)
        {
            if (isStuckFoundOnPositionToGo) // gooseOnPositionToGo.ContainsKey(true) should also work, but less readable.
            {
                var index = gooseOnPositionToGo.FirstOrDefault(x => x.Value == true).Key;
                gooseList[index].isStuck = false;
            }
            else
            {
                var index = gooseOnPositionToGo.FirstOrDefault(x => x.Value == false).Key;
                gooseList[index].PositionToGo = gooseList[currentGoose].Position;
            }
            return true;
        }
        return false;
    }
}
