namespace GameOfGoose;

/// <summary>
/// Specific amount of dice in a dice roll with specific number of up counting faces.
/// Can perform a dice roll with all dice at once.
/// </summary>
public class Dice
{
    private int _sides;
    private int _amount;
    private Random _random = new Random();

    public Dice (int sides, int amount)
    {
        _sides = sides;
        _amount = amount;
    }

    public int[] RollDice()
    {
        int[] diceRoll = new int[_amount];

        for (int i = 0; i < _amount; i++)
        {
            diceRoll[i] = _random.Next(_sides) + 1;
        }

        return diceRoll;
    }
}
