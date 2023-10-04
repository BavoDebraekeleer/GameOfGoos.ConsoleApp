using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfGoose
{
    public class PlayerTest
    {
        [Fact]
        public void WhenPlayerMoveIsCalled_ThenPlayerShouldMoveToExactPosition()
        {
            // Arrange
            var goose = new Goose();

            // Act
            goose.MoveToPosition(35);

            // Assert
            Assert.Equal(35, goose.Position);
        }
    }
}
