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
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Standard 
            Console.CursorVisible = false;

            Program program = new Program();
            int n = 8;
            program.printBoard(n);



        }


        public void printBoard(int n)
        {
            string blackTile = "◼︎";
            string whiteTile = "◻︎";
            bool[,] board = RenderBoard(n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j])
                    {
                        Console.Write(" " + blackTile + " ");
                    }
                    else
                    {
                        Console.Write(" " + whiteTile + " ");
                    }
                }
                Console.WriteLine(); 
            }

        }

        public bool[,] RenderBoard(int n)
        {

            /* Matrix with col/row size of N, since board is either black/white I just made it boolean. 
             * I would probably use integers on a more complicated version, but since this is a simpler version 
             * I think its smarter to use bytes for memory. 
             * */


            bool[,] board = new bool[n, n]; 

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
            for(int rows = 0; rows < n; rows++)
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
        

        /*
         * This method has the responsibility to take in user input (board size) and validate the number
         * @returns int number
         */
        public int ReadInput()
        {
            int n; // will get an assigned value further down in method if validation is correct
            int min = 3;
            int max = 50;

            while(true)
            {
                Console.WriteLine("Welcome to Chas Chess 3.0! Please choose the size of your board (3-50)");
                string i = Console.ReadLine(); // console always returns string so we will need to convert it to integer with TryParse 
                
                if (int.TryParse(i, out n)) 
                {
                    if (n >= min && n <= max)
                    {
                        return n;
                    }
                    else
                    {
                        Console.WriteLine($"Board dimensions need to be between {min} and {max}");
                    }
                }
                else
                {
                    Console.WriteLine($"The input is incorrect! Needs to be a number between {min} and {max}");
                }


            }

        }

        public void StartGame()
        {
                        

        }

    }
}

          