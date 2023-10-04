namespace GameOfGoose.Messengers;

public class ConsoleMessenger : IMessenger
{
    private readonly TextWriter _textWriter;

    public ConsoleMessenger() : this(Console.Out) { }
    public ConsoleMessenger(TextWriter textWriter)
    {
        _textWriter = textWriter;
    }
    public void ShowMessage(string message)
    {
        _textWriter.WriteLine(message);
    }

    public string? GetUserInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}
