using System;
using System.Threading;  

namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Carga el tablero
            bool[,] board = BoardImporter.ImportBoardFromFile();

            // Creamos objeto Board con el tablero cargado
            Board b = new Board(width: board.GetLength(0), height: board.GetLength(1), board);

            
            Motor m = new Motor();

            while (true)
            {
                // Limpia la consola
                Console.Clear();

                // Estado actual del tablero
                Console.WriteLine("Generación: " + b.Generation);
                Console.WriteLine(BoardRenderer.PrintBoard(b.BoardArray));

                // Avanza el tablero a la siguiente generación
                b = m.Step(b);

                // Espera unos segundos para mostrar la proxima generación
                Thread.Sleep(500);
            }
        }
    }
}
