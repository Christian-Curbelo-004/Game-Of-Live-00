<<<<<<< HEAD
﻿
=======
﻿using System;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 10;  // Tablero de 10 columnas
            int height = 5;  // Tablero de 5 filas
            bool[,] board = new bool[width, height];

            // Patrón "Glider"
            board[1, 0] = true;
            board[2, 1] = true;
            board[0, 2] = true;
            board[1, 2] = true;
            board[2, 2] = true;

            int generation = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Generación: {generation++}\n");

                // Imprimir el tablero
                PrintBoard(board, width, height);

                // Actualizar las celdas del tablero
                UpdateBoardInPlace(board, width, height);

                // Pausa para simular un "tiempo real"
                Thread.Sleep(300);
            }
        }

        static void PrintBoard(bool[,] board, int width, int height)
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

        static void UpdateBoardInPlace(bool[,] board, int width, int height)
        {
            int[,] neighborCount = new int[width, height];

            // Paso 1: contar vecinos vivos
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (!board[x, y]) continue;

                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (dx == 0 && dy == 0) continue;

                            int nx = x + dx;
                            int ny = y + dy;

                            if (nx >= 0 && nx < width && ny >= 0 && ny < height)
                            {
                                neighborCount[nx, ny]++;
                            }
                        }
                    }
                }
            }

            // Paso 2: actualizar el tablero en función de los vecinos
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int neighbors = neighborCount[x, y];

                    if (board[x, y])
                    {
                        board[x, y] = neighbors == 2 || neighbors == 3;
                    }
                    else
                    {
                        board[x, y] = neighbors == 3;
                    }
                }
            }
        }
    }
}
>>>>>>> Print-Board
