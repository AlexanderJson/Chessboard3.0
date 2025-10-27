using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard3._0.poco
{
    public class BoardView
    {
       




        // This is a bit overkill, but maybe smart to have if the game would be expanded later on and menu become more complex
        public static void GameMenu(int min, int max)
        {
            Console.WriteLine("Welcome to Chas Chess 3.0");
            Console.WriteLine($"Please select your preferred board dimensions between {min} and {max}");
        }




        /*
         * This method has the responsibility to take in user input (board size) and validate the number
         * @returns int number
         */
        public int ReadInput(int min, int max)
        {
            int n; // will get an assigned value further down in method if validation is correct

            while (true)
            {
                Console.WriteLine("Welcome to Chas Chess 3.0! Please choose the size of your board (3-50)");
                string i = Console.ReadLine(); // console always returns string so we will need to convert it to integer with TryParse 

                if (int.TryParse(i, out n))
                {
                    if (IsInputValid(n, min, max))
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



        public static void printBoard(Board board)
        {
            string blackTile = "◼︎";
            string whiteTile = "◻︎";
            int n = board.Dimensions;

            Console.OutputEncoding = System.Text.Encoding.UTF8;


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board.Tiles[i, j])
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

        private static bool IsInputValid(int n, int min, int max) => n >= min && n <= max;


    }
}
