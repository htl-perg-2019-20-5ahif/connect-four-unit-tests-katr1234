using System;

namespace ConnectFour.Logic
{
    public class Board
    {
        /// <summary>
        /// [Column, Row]
        /// </summary>
        private readonly byte[,] GameBoard = new byte[7,6];

        /// <summary>
        /// Player is 1 or 2
        /// </summary>
        internal int Player = 2;


        public byte[,] GetGameBoard()
        {
            return this.GameBoard;
        }

        public void AddStone(byte column)
        {
            if (column > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }

            for (int row = 0; row < 6; row++)
            {
                var cell = GameBoard[column, row];

                if (cell == 0)
                {
                    Player = (Player + 1) % 2;
                    GameBoard[column, row] = (byte)(Player + 1);
                    return;
                }
            }

            throw new InvalidOperationException("Column is full");
        }


        public bool CheckIfOnePlayerHasWon()
        {
            if (CheckDiagonal())
            {
                return true;
            }
            if (CheckVertical())
            {
                return true;
            }
            if (CheckHoricontal())
            {
                return true;
            }
            return false;
        }

        public int GetOldPlayer()
        {
            if (Player == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public bool CheckIfBoardIsFull()
        {
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    if (GameBoard[i, j] == 0)
                    {
                        return false;
                    }
                }
            }    
            return true;
        }

        public bool CheckHoricontal()
        {
            for (int j = 0; j < 6 - 3; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (this.GameBoard[i, j] == this.GetOldPlayer() && this.GameBoard[i, j + 1] == this.GetOldPlayer() && this.GameBoard[i, j + 2] == this.GetOldPlayer() && this.GameBoard[i, j + 3] == this.GetOldPlayer())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckVertical()
        {
            for (int i = 0; i < 7 - 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (this.GameBoard[i, j] == this.GetOldPlayer() && this.GameBoard[i + 1, j] == this.GetOldPlayer() && this.GameBoard[i + 2, j] == this.GetOldPlayer() && this.GameBoard[i + 3, j] == this.GetOldPlayer())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckDiagonal()
        {
            for (int i = 3; i < 7; i++)
            {
                for (int j = 0; j < 6 - 3; j++)
                {
                    if (this.GameBoard[i, j] == this.GetOldPlayer() && this.GameBoard[i - 1, j + 1] == this.GetOldPlayer() && this.GameBoard[i - 2, j + 2] == this.GetOldPlayer() && this.GameBoard[i - 3, j + 3] == this.GetOldPlayer())
                        return true;
                }
            }

            for (int i = 3; i < 7; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (this.GameBoard[i, j] == this.GetOldPlayer() && this.GameBoard[i - 1, j - 1] == this.GetOldPlayer() && this.GameBoard[i - 2, j - 2] == this.GetOldPlayer() && this.GameBoard[i - 3, j - 3] == this.GetOldPlayer())
                        return true;
                }
            }
            return false;
        }
    }
}
