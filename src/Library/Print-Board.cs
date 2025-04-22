using System;
using System.Text;
using System.Threading;

namespace PrintBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 10;
            int height = 5;
            bool[,] board = new bool[width, height];

            // Estado inicial
            board[1, 1] = true;
            board[2, 2] = true;
            board[3, 3] = true;

            int generation = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Generación: {generation++}\n");

                PrintBoard(board, width, height);

                Thread.Sleep(500); // Pausa antes de la próxima generación

                board = NextGeneration(board, width, height);
            }
        }

        static void PrintBoard(bool[,] board, int width, int height)
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    sb.Append(board[x, y] ? "|X|" : "___");
                }
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }

        static bool[,] NextGeneration(bool[,] board, int width, int height)
        {
            bool[,] newBoard = new bool[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int liveNeighbors = CountLiveNeighbors(board, x, y, width, height);

                    if (board[x, y])
                    {
                        newBoard[x, y] = liveNeighbors == 2 || liveNeighbors == 3;
                    }
                    else
                    {
                        newBoard[x, y] = liveNeighbors == 3;
                    }
                }
            }

            return newBoard;
        }

        static int CountLiveNeighbors(bool[,] board, int x, int y, int width, int height)
        {
            int count = 0;

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue;

                    int nx = x + dx;
                    int ny = y + dy;

                    if (nx >= 0 && nx < width && ny >= 0 && ny < height)
                    {
                        if (board[nx, ny]) count++;
                    }
                }
            }

            return count;
        }
    }
}
