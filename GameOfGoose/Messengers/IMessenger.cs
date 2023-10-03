namespace GameOfGoose.Messengers;

public interface IMessenger
{
    public void ShowMessage(string message);
    public void WaitForInput(string message);
}
