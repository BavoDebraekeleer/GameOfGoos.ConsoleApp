using GameOfGoose.GameRules;
using GameOfGoose.Messengers;
using System;

namespace GameOfGoose;

public class GameLoop
{
    public List<Goose> GooseList = new List<Goose>();
    private Dice _dice;
    private List<GameRule> _gameRulesSet;
    private int _gameOverPosition;
    private IMessenger _messenger;

    private int _currentGoose = 0;
    private int _turn = 0;
    private int[] _currentDiceRoll;
    private bool _isGameOver;

    public GameLoop(int amountOfPlayers, Dice dice, List<GameRule> gameRulesSet, int gameOverPosition, IMessenger messenger)
    {
        for (int i = 0; i < amountOfPlayers; i++)
        {
            GooseList.Add(new Goose());
        }
        _dice = dice;
        _currentDiceRoll = _dice.RollDice();
        _gameRulesSet = gameRulesSet;
        _gameOverPosition = gameOverPosition;
        _messenger = messenger;
    }

    public void Play()
    {
        while (!_isGameOver)
        {
            _turn++;
            _messenger.ShowMessage($"----------------------------------");
            // _messenger.GetUserInput($"Press Enter to start turn {_turn}.");
            _messenger.ShowMessage($"Press Enter to start turn {_turn}.");

            if (GooseList[_currentGoose].IsSkip)
            {
                GooseList[_currentGoose].IsSkip = false;
                _messenger.ShowMessage($"Goose {_currentGoose + 1} has to skip this turn.");
            }
            else if (GooseList[_currentGoose].IsStuck)
            {
                _messenger.ShowMessage($"Goose {_currentGoose + 1} is still stuck on space {GooseList[_currentGoose].Position}.");
            }
            else
            {
                _messenger.ShowMessage($"Goose {_currentGoose + 1} is on space {GooseList[_currentGoose].Position}.");

                GetCurrentGooseNewPositionToGo();
                do
                {
                    DoGameRulesSetCheck();
                } while (CheckForGameOverPositionOvershoot());

                UpdateAllGoosePositions();
            }

            CheckIsGameOver();
            SelectNextGoose();
        }
    }

    private void GetCurrentGooseNewPositionToGo()
    {
        _currentDiceRoll = _dice.RollDice();
        var diceRollThrow = _currentDiceRoll.Sum();
        string diceRollText = String.Join(", ", _currentDiceRoll);
        _messenger.ShowMessage($"Goose {_currentGoose + 1} rolls {diceRollText}. Total throw is {diceRollThrow}.");

        GooseList[_currentGoose].PositionToGo += diceRollThrow;
    }

    private bool CheckForGameOverPositionOvershoot()
    {
        var nextPositionToGo = GooseList[_currentGoose].PositionToGo;
        if (nextPositionToGo > _gameOverPosition)
        {
            var overshoot = nextPositionToGo - _gameOverPosition;
            nextPositionToGo = _gameOverPosition - overshoot;
            GooseList[_currentGoose].PositionToGo = nextPositionToGo;

            _messenger.ShowMessage($"Dang it! Overshot the Game Over space {_gameOverPosition} " +
                $"by {overshoot}. You need to move back {overshoot} spaces.");

            return true;
        }
        return false;
    }

    private void DoGameRulesSetCheck()
    {
        foreach (var rule in _gameRulesSet)
        {
            if (rule.DoGameRuleCheck(GooseList, _currentGoose, _currentDiceRoll))
            {
                _messenger.ShowMessage(rule.Message);
            }
        }
    }

    private void UpdateAllGoosePositions()
    {
        // All Goose positions may need to update, e.g. OccupiedSpaceGameRule.
        for (var i = 0; i < GooseList.Count; i++)
        {
            if (GooseList[i].Position != GooseList[i].PositionToGo)
            {
                GooseList[i].GoToPosition();
                _messenger.ShowMessage($"Goose {i + 1} moved to space {GooseList[i].Position}.");
            }
        }
    }
    private void CheckIsGameOver()
    {
        if (GooseList[_currentGoose].Position == _gameOverPosition)
        {
            _isGameOver = true;
            _messenger.ShowMessage("Game Over!");
            _messenger.ShowMessage($"Goose {_currentGoose + 1} won the game in {_turn} turns.");
        }
    }

    private void SelectNextGoose()
    {
        _currentGoose++;
        if (_currentGoose == GooseList.Count)
        {
            _currentGoose = 0;
        }
    }
}
