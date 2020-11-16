using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Game
    {
        public enum State
        {
            Cross, 
            Zero,
            Unset
        }

        public enum Winner
        {
            Zeroes,
            Crosses,
            Draw
        }

        

        

        public Game()
        {
            for (int i = 0; i < _board.Length; i++)
            {
                _board[i] = State.Unset;
            }
        }


        private readonly State[] _board  = new State[9];
        public double MovesCounter { get; private set; }

        public Winner GetWinner()
        {
            return GetWinner(1, 4, 7, 2,5, 8, 3,6,9,4,5,6,7,8,9, 1,5,9,1,3,5);
        }

        public Winner GetWinner(params  int[] indexes)
        {
            for(int i= 0; i < indexes.Length; i+=3)
            {
                bool same = AreSame(indexes[i], indexes[i + 1], indexes[i + 2]);

                if (same)
                {
                    var state = GetState(indexes[i]);

                    if (state != State.Unset)
                        return state == State.Cross ? Winner.Crosses : Winner.Zeroes;
                }
            }

            return Winner.Draw;
        }

        private bool AreSame(int a, int b, int c)
        {
            return GetState(a) == GetState(b) && GetState(a) == GetState(c);
        }

        public void MakeMove(int index)
        {
            if(index < 1 || index > 9)
                throw new ArgumentOutOfRangeException();


            if(GetState(index) != State.Unset)
                throw  new InvalidOperationException();

            MovesCounter++;

            
            _board[index - 1] = MovesCounter % 2 == 0 ? State.Zero : State.Cross;
        }

        public State GetState(int index)
        {
            return _board[index - 1];
        }
    }
}
