using GameOfGoose.Messengers;

namespace GameOfGoose;

public class MessagesTests
{
    [Fact]
    public void ShouldSendMessageToConsole()
    {
        // 1. Arrange
        var message = "Test";
        var stringWriter = new StringWriter(); // StringWriter inherits from TextWriter, but is specifically for strings.
        var consoleMessenger = new ConsoleMessenger(stringWriter);

        // 2. Act
        consoleMessenger.ShowMessage(message);

        // 3. Assert
        var result = stringWriter.ToString();
        Assert.Equal($"{message}{Environment.NewLine}", result);
    }
}
