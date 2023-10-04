using GameOfGoose.GameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfGoose
{
    public enum GameRuleType { Hangover, Goose, Stuck }
    internal class Factory : IFactory
    {
        public GameRule Create(int position, GameRuleType type)
        {
            //switch (type)
            //{
            //    case GameRuleType.Hangover:
            //        return new HangoverGameRule(position);

            //    case GameRuleType.Goose:
            //        return new GooseSpaceGameRule(position);
            //}
            
            // Not part of Factory, just placeholder to satisfy the compiler.
            return new FirstDiceRollGameRule("", new int[] { 6, 3 }, 26);
        }
    }
}
