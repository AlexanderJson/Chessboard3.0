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




        }


        public void RenderBoard(int n)
        {

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
            Console.WriteLine("Welcome to Chas Chess 3.0! Please choose the size of your board (3-50)");
            string i = Console.ReadLine();
            if (int.TryParse(i, out int number))
            {

            }


        }

    }
}

          