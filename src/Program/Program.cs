using System;
using System.Text;
using System.Threading;


class Program
{
    static void Main(string[] args)
    {
        // Se carga el tablero desde el archivo de texto
        bool[,] board = BoardImporter.ImportBoard(boardPath);

        // Se crea un objeto tablero a partir del tablero leído
        Board a = new Board(width: board.GetLength(1), height: board.GetLength(0), board);

        // Se inicializa el motor del juego
        GameCore g = new GameCore(g);

        while (true)
        {
            // Limpia la consola
            Console.Clear();

            // Imprime el tablero actual
            Console.WriteLine(BoardPrinter.PrintBoard(a.Board3));

            // Avanza todo el tablero a la siguiente generación
            g.NextStep();

            // Espera 0.3 segundos antes de la siguiente iteración
            Thread.Sleep(millisecondsTimeout: 300);
        }
    }
}