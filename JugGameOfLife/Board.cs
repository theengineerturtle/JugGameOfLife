using System;
using System.Collections.Generic;
using System.Text;

namespace JugGameOfLife
{
    public class Board
    {
        private bool[,] board;

        public Board(int row, int col)
        {
            board = new bool[row, col];
        }


        public bool GetCellValue(int row, int col)
        {
            return board[row, col];
        }

        public void SetCellValue(bool status, int row, int col)
        {
            board[row, col] = status;
        }

        public int getNeighborCounts(int row, int col)
        {
            int count = 0;


            bool isOnHorizantalCorner = row==0 || row==this.board.GetLength(0)-1;
            bool isOnVerticalCorner = col==0  || col==this.board.GetLength(1)-1;


            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i == row && j == col) continue;

                    if((isOnHorizantalCorner 
                        || isOnVerticalCorner)
                        && 
                        (
                        (j<0 || j>=this.board.GetLength(1))
                        ||
                        (i<0 || i>= this.board.GetLength(0))
                        )
                       )
                    {
                        continue;
                    }


                    if (board[i, j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
