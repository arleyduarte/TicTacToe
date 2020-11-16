using NUnit.Framework;
using TicTacToe;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Tests
{
    [TestFixture()]
    public class GameTests
    {


        [Test()]
        public void CreateGame_ZeroMoves()
        {
            var game = new Game();
            Assert.AreEqual(0, game.MovesCounter);
        }


        [Test()]
        public void MakeInvalidMove_ThrowsException()
        {
            var game = new Game();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                game.MakeMove(0);
            });
        }




        [Test()]
        public void MoveOnTheSameSquare_ThrowsException()
        {
            var game = new Game();
            Assert.Throws<InvalidOperationException>(() =>
            {
                game.MakeMove(1);
                game.MakeMove(1);
            });
        }

        [Test()]
        public void MakeMove_CounterShifts()
        {
            var game = new Game();
            game.MakeMove(1);
            game.MakeMove(2);
            game.MakeMove(3);

            Assert.AreEqual(Game.State.Cross, game.GetState(1));
            Assert.AreEqual(Game.State.Zero, game.GetState(2));
            Assert.AreEqual(Game.State.Cross, game.GetState(3));

        }


        [Test()]
        public void GetWinner_ZeroesWin()
        {
            var game = new Game();

            //2, 5, 8
            MakeMoves(game, 1, 2, 3, 5, 4, 8 );

          Assert.AreEqual(Game.Winner.Zeroes, game.GetWinner());
        }



        private void MakeMoves(Game game, params int[] indexes)
        {
            foreach (var index in indexes)
            {
                game.MakeMove(index);
            }
        }



    }
}