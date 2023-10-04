using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameOfGoose.GameRules;

namespace GameOfGoose
{
    public class HangoverTest
    {
        [Theory]
        [InlineData(15, 6)]
        [InlineData(15, 7)]
        public void WhenHungover_ThenDiceThrowIsHalved(int expected, int diceRoll)
        {
            // Arrange
            var goose = new Goose();
            goose.IsHungover = true;
            goose.Position = 12;

            // Act
            goose.MovePlayer(diceRoll);

            // Assert
            Assert.Equal(expected, goose.Position);
        }
    }
}
