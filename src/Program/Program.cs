using System;
using System.Threading;
using Library;
using GameOfLife;

namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear tablero usando BoardImporter y Board
            bool[,] board = Boardimporter.ImportBoard("board.txt");
            Board b = new Board(board.GetLength(1), board.GetLength(0), board); 

            while (true)
            {
                PrintBoard.Show(board, b.width, b.height);  //Para imprimir el tablero en cada vuelta
                
                board= NextMove.GameCore.NextMoveMethod(board); //Para calcular la siguiente generación
                
                Thread.Sleep(300); // Tiempo de espera para que vuelva a hacer el ciclo
            }
        }
    }
}
