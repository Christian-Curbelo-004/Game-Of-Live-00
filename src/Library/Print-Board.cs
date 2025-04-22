using System;
using System.Text;
using System.Threading;  


namespace Ucu.Poo.GameOfLife
{
    // Creamos la clase tablero
public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool[,] BoardArray { get; set; }
        public int Generation { get; set; }

        public Board(int width, int height, bool[,] boardArray)
        {
            Width = width;
            Height = height;
            BoardArray = boardArray;
            Generation = 0;
        }
    }

    public class Motor
    {
        public Board Step(Board currentBoard)
        {
            currentBoard.Generation++;
            return currentBoard;
        }
    }

    public class BoardRenderer
    {
        public static string PrintBoard(bool[,] board)
        {
            // Diseño del tablero
            StringBuilder sb = new StringBuilder();
            int height = board.GetLength(1);
            int width = board.GetLength(0);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    sb.Append(board[x, y] ? "|X|" : "___");
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }

    public class BoardImporter
    {
        public static bool[,] ImportBoardFromFile()
        {
            bool[,] board = new bool[10, 5];
            
            // Agregamos celdas
            board[1, 1] = true;
            board[2, 2] = true;
            board[3, 3] = true;
            return board;
        }
    }
}