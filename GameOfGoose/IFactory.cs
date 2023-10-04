using GameOfGoose.GameRules;

namespace GameOfGoose
{
    internal interface IFactory
    {
        GameRule Create(int position, GameRuleType type);
    }
}