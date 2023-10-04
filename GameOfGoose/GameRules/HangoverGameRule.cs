using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfGoose.GameRules
{
    public class HangoverGameRule : GameRule
    {
        public override string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool DoGameRuleCheck(List<Goose> gooseList, int currentGoose, int[] diceRoll) // One player, no list
        {
            throw new NotImplementedException();
        }
    }
}
