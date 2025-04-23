namespace Library;
using System;

public class Board
{
    bool[,] board;

    public int height
    {
        get;
        private set;
    }
    

    public int width
    {
        get;
        private set;
    }
    
    
    public Board(int height, int width, bool [,] board = null)
    {
        this.height = height;
        this.width = width;
        this.board = new bool[width, height];
        if (board !=null )
        {
            for (int i = 0; i < Math.Min(width, board.GetLength(dimension: 0)); i++)
            {
                for (int x = 0; x < Math.Min(height, board.GetLength(dimension: 1)); x++)
                {
                    this.board[i, x] = board[i, x];
                }
            }
             
        }

    }
}