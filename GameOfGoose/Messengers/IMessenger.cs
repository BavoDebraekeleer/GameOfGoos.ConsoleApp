namespace GameOfGoose.Messengers;

public interface IMessenger
{
    public void ShowMessage(string message);
    public string? GetUserInput(string message);
}
