namespace GameOfGoose;

/// <summary>
/// Goose holds the current position of a Goose and if the next turn should be skipped.
/// </summary>
public class Goose
{
    /// <summary>
    /// The current position of the Goose.
    /// </summary>
    public int Position { get; set; }
    
    /// <summary>
    /// The future position of the Goose to be used in GameRule checks.
    /// After check have finished the GoToPosition method should be called.
    /// </summary>
    public int PositionToGo { get; set; }
    
    /// <summary>
    /// If the Goose has to skip a turn, this bool should be set to true.
    /// </summary>
    public bool isSkip {  get; set; }

    /// <summary>
    /// If the Goose gets stuck at a Hazard space, this bool should be set to true.
    /// </summary>
    public bool isStuck { get; set; }

    /// <summary>
    /// Set the Goose's position to the PositionToGo after all GameRule checks have completed.
    /// Animations of the Goose moving spaces can be triggered here.
    /// </summary>
    public void GoToPosition()
    {
        Position = PositionToGo;
    }
}
