using ConnectFour.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour.UI
{
    class Game
    {
        Board board = new Board();


        public void StartGame()
        {
            while(!this.CheckGameEnded())
            {
                try
                {

                    byte col = this.GetInputStone();
                    this.board.AddStone(col);
                    for (int row = 5; row > -1; row--)
                    {
                        for (int column = 0; column < 7; column++)
                        {
                            Console.Write(this.board.GetGameBoard()[column, row]);
                        }
                        Console.WriteLine();
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (this.board.CheckIfOnePlayerHasWon())
            {
                Console.WriteLine("Player " + this.GetPlayer() + "  won!");
            }
            else
            {
                Console.WriteLine("Next one!");
            }
        }
        private bool CheckGameEnded()
        {
            if (this.board.CheckIfOnePlayerHasWon() || this.board.CheckIfBoardIsFull())
            {
                return true;
            }
            return false;
        }

        private int GetPlayer()
        {
            return board.GetOldPlayer();
        }

        private byte GetInputStone()
        {
            string index = "";
            byte parsedIndex;
            do
            {
                Console.Write("Player " + GetPlayer() + ": ");
                index = Console.ReadLine();

            } while (!Byte.TryParse(index, out parsedIndex));
            return parsedIndex;

        }
    }
}
