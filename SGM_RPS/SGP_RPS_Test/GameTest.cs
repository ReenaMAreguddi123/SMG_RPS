using System;
using System.Globalization;
using SGM_RPS.Interfaces;
using SGM_RPS.Models;
using SGM_RPS.Services;
using Xunit;

namespace SGP_RPS_Test
{
    public class GameTest
    {
        [Fact]
        public void RoundResult_Player_Won_Rock_Crushes_Scissors()
        {
            //Arrange
            IGame game = new Game();
            var playerChoice = Choice.Rock;
            var systemChoice = Choice.Scissors;

            //Act
            var result = game.RoundResult(playerChoice, systemChoice);

            //Assert
            Assert.True(result == Result.PlayerWon);
        }

        [Fact]
        public void RoundResult_System_Won_Scissors_Cuts_Paper()
        {
            //Arrange
            IGame game = new Game();
            var playerChoice = Choice.Paper;
            var systemChoice = Choice.Scissors;

            //Act
            var result = game.RoundResult(playerChoice, systemChoice);

            //Assert
            Assert.True(result == Result.SystemWon);
        }

        [Fact]
        public void RoundResult_Player_Won_Paper_Covers_Rock()
        {
            //Arrange
            IGame game = new Game();
            var playerChoice = Choice.Paper;
            var systemChoice = Choice.Rock;

            //Act
            var result = game.RoundResult(playerChoice, systemChoice);

            //Assert
            Assert.True(result == Result.PlayerWon);
        }

        [Fact]
        public void RoundResult_Draw()
        {
            //Arrange
            IGame game = new Game();
            var playerChoice = Choice.Paper;
            var systemChoice = Choice.Paper;

            //Act
            var result = game.RoundResult(playerChoice, systemChoice);

            //Assert
            Assert.True(result == Result.Draw);
        }

        [Fact]
        public void FinalResult()
        {

            #region Draw

            //Arrange
            IGame game = new Game();
            var playerChoice = Choice.Paper;
            var systemChoice = Choice.Paper;

            //Act
            var result = game.RoundResult(playerChoice, systemChoice);

            //Assert
            Assert.True(result == Result.Draw);

            #endregion

            #region Player Won

            //Arrange
            playerChoice = Choice.Paper;
            systemChoice = Choice.Rock;

            //Act
            result = game.RoundResult(playerChoice, systemChoice);

            //Assert
            Assert.True(result == Result.PlayerWon);

            //Arrange
            playerChoice = Choice.Rock;
            systemChoice = Choice.Scissors;

            //Act
            result = game.RoundResult(playerChoice, systemChoice);

            //Assert
            Assert.True(result == Result.PlayerWon);

            #endregion

            #region System won

            //Arrange
            playerChoice = Choice.Paper;
            systemChoice = Choice.Scissors;

            //Act
            result = game.RoundResult(playerChoice, systemChoice);

            //Assert
            Assert.True(result == Result.SystemWon);

            #endregion

            //Act
            var finalResult = game.FinalResult();
            var mostUsedMove = game.MostUsedMove();

            //Assert
            Assert.True(finalResult == Result.PlayerWon);
            Assert.True(mostUsedMove == Choice.Paper);

        }
    }
}
