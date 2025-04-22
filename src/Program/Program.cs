using System;
using System.Threading;
using Library; 

namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Carga del tablero desde archivo - SRP: se delega a una clase experta en esto.
            string filePath = "board.txt";
            bool[,] initialBoard = BoardImporter.ImportBoard(filePath);

            // Se crea el tablero (Board) con los datos iniciales
            Board board = new Board(initialBoard);

            // Se instancia la lógica del juego con ese tablero
            GameCore game = new GameCore(board);

            // Bucle infinito para mostrar el juego
            while (true)
            {
                Console.Clear();
                Console.WriteLine(BoardPrinter.Print(board));
                game.NextGeneration();
                Thread.Sleep(300);
            }
        }
    }
