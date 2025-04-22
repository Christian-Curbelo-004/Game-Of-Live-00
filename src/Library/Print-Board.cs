using System;
using System.Text;

namespace GameOfLife
{
    public class PrintBoard
    {
        public static void Show(bool[,] board, int width, int height)
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    sb.Append(board[x, y] ? "|X|" : " . ");
                }
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
