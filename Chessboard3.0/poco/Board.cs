using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard3._0.poco
{
    public class Board
    {
        public int Dimensions { get; set; }
        public bool[,] Tiles { get; private set; }

        // Since these are set by developer, I just made them constant values without getter/setter
        public const int min = 3;
        public const int max = 50;

        public const string blackTile = "◼︎";
        public const string  whiteTile = "◻︎";

        public (string BlackTile, string WhiteTile) TileSymbols { get; private set; } = (blackTile, whiteTile); // tuple, this is if we want to change how the tiles look in future


        public Board(int n)
        {
            Dimensions = n;
            Tiles = RenderBoard(n);
        }



        private static bool IsInputValid(int n) => n >= min && n <= max;

        private bool[,] RenderBoard(int n)
        {
            bool[,] board = new bool[n, n];
            var invalidInput = "Invalid input! Must be between " + min + " or " + max;
            /* Matrix with col/row size of N, since board is either black/white I just made it boolean. 
             * I would probably use integers on a more complicated version, but since this is a simpler version 
             * I think its smarter to use bytes for memory. 
             * */

            if (!IsInputValid(n))
            {
                Console.WriteLine(invalidInput);
                return new bool[0, 0];  // returns empty list if input is incorrect, so when making the console writelines we will check if the returned board = empty or not
            }

            /* My idea to place black/white tiles:
             * Lets say:  " N = 4 ". 
             * 
             * x x x x
             * x x x x
             * x x x x
             * x x x x
             * 
             * 
             * Then the first index in our matrix would be column 1 and row 1. 
             * Now the problem is that when iterating a matrix, it will count row and then column, which 
             * means that when reaching row 2 col 1 it will count this as the first index again, but in the second row. 
             * So to keep track I decided to take row + column. So even and uneven numbers will be swapped but that doesnt really matter.
             * 
             * Example: 
             * 
             * Row 1 + Col 1 = 2 (even number)
             * Row 1 + Col 2 = 3 (uneven number)
             * Row 1 + Col 3 = 4 (even number)
             * Row 1 + Col 4 = 5 (uneven number)
             * Row 2 + Col 5 = 6 (uneven number)
             * 
             * This will work no matter how large the board is, because we are really just checking two states. 
             * 
             * Now we need to alert when a index is even/uneven. And since all even numbers är divisible by 2 while uneven are never, 
             * we can just check if the current index in divisible by 2 or not. 
             * 
             * */


            // We iterate all the rows until we reach the last value of N. 
            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    // So basically: if rows + cols can be divided by 2 then that index = true, otherwise flasee
                    board[rows, cols] = ((rows + cols) % 2 == 0);
                }
            }

            // then we return the whole board, I dont print it here, because I want to keep UI functionality in one place 
            return board;
        }


        
    }
}
