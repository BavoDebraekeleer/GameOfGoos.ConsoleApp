using GameOfGoose.GameRules;

namespace GameOfGoose;

public class GameLoop
{
    public List<Goose> GooseList = new List<Goose>();
    public List<GameRule> _gameRulesList;
    private Dice _dice;

    private int _currentGoose;
    private int _turn;
    private int _gameOverPosition;
    private bool _isGameOver;

    public GameLoop(int amountOfPlayers, Dice dice, List<GameRule> rulesList, int gameOverPosition)
    {
        for (int i = 0; i < amountOfPlayers; i++)
        {
            GooseList.Add(new Goose());
        }
        _dice = dice;
        _gameRulesList = rulesList;
    }

    public void RulesSetup()
    {
        // RulesList.Add(new Rule());
    }

    public void Play()
    {
        while (!_isGameOver)
        {
            _turn++;

            Console.WriteLine($"Press Space to start turn {_turn}.");
            Console.ReadLine();

            if (GooseList[_currentGoose].isSkip)
            {
                GooseList[_currentGoose].isSkip = false;
                Console.WriteLine($"Goose {_currentGoose + 1} has to skip this turn.");
            }
            else if (GooseList[_currentGoose].isStuck)
            {
                Console.WriteLine($"Goose {_currentGoose + 1} is still stuck.");
            }
            else
            {
                var diceRoll = _dice.RollDice();
                GooseList[_currentGoose].PositionToGo = diceRoll.Sum();

                foreach (var rule in _gameRulesList)
                {
                    rule.DoRuleCheck(GooseList, _currentGoose, diceRoll);
                    Console.WriteLine(rule.Message);
                }

                // All Goose positions may need to update, e.g. OccupiedSpaceGameRule.
                for (var i = 0; i < GooseList.Count; i++)
                {
                    if (GooseList[i].Position != GooseList[i].PositionToGo)
                    {
                        GooseList[i].GoToPosition();
                        Console.WriteLine($"Goose {i + 1} moved to space {GooseList[i].Position}.");
                    }
                }
            }
            _currentGoose++;
            if (_currentGoose == GooseList.Count)
            {
                _currentGoose = 0;
            }
            
            if (GooseList[_currentGoose].Position == _gameOverPosition)
            {
                _isGameOver = true;
                Console.WriteLine("Game Over!");
                Console.WriteLine($"Goose {_currentGoose + 1} won the game in {_turn} turns.")
            }
        }
    }
}
