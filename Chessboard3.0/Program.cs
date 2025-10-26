using Chessboard3._0.poco;
using System;
using System.Data.Common;
using System.Security.Cryptography;
namespace Chessboard3._0
{
    public class Program
    {
        private static void Main(string[] args)
        {

            BoardView view = new BoardView();

            int input = view.ReadInput(Board.min, Board.max);

            Board board = new Board(input);

            BoardView.printBoard(board);



        }



    }
}

          