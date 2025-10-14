using Chessboard3._0.poco;
using System;
using System.Data.Common;

namespace Chessboard3._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // UTF8 är standard encoding, tillåter svenska karaktär, emojis etc
            Console.CursorVisible = false;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var wtower = 8;
            var wpawn = 1;
            var btower = -8;
            var bpawn = -1;
            // int[,] board = new int[8, 8];

            int[,] board = new int[8, 8];

            int horizontalMove = 0;
            var whitetowerX = 0;
            var whitetowerY = 7;
            board[7, 0] = wtower;
            board[0, 0] = btower;
            board[1, 0] = bpawn;
            bool ingame = false;



            Console.WriteLine("=== CHESSBOARD 3.0 ===");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Exit");
            Console.Write("Choose: ");


            string choice = Console.ReadLine();
            if( choice.Equals("1")) ingame = true;
            if (choice.Equals("2")) ingame = false;

            int y = 7;
            int x = 0;

            while (ingame)
            {
                Console.Clear();
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (row == y && col == x)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            //Console.WriteLine("♟️");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.CursorVisible = false;

                        Console.Write($"{board[row, col],4}");
                    }
                    Console.WriteLine();
                }



                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                    y--;
                else if (key.Key == ConsoleKey.DownArrow)
                    y++;
                else if (key.Key == ConsoleKey.LeftArrow)
                    x--;
                else if (key.Key == ConsoleKey.RightArrow)
                    x++;
                else if (key.Key == ConsoleKey.Spacebar)
                    Console.WriteLine("SPACE!");
            }





            /**
             * 
             * Tanke: 
             * 
             * ett bräde motsvarar samma dimensioner (x=y)
             * om varje pjästyp har en unik summa , tillräckligt unik
             * kommer den lämna en helt unik version av matrisen för varje möjlig kombo
             * det enda som måste uteslutas är  
             * 
             */





            bool stopPrinting = false;
            for (int row = 7; row >= 0; row--)
                {
                    if (row != 7)
                    {
                        var step = board[row, horizontalMove] += 8;

                    }
                
                        for (int cols = 0; cols < 8; cols++)
                        {
                            for (int rows = 0; rows < 8; rows++)
                            {
                                int cell = board[cols, rows];
                                if (cell < 8)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                     Console.Write($"{board[cols, rows],3}");

                                }
                        else if (cell > 8)
                                {
                                Console.ForegroundColor = ConsoleColor.Red;
                                }
                                 else Console.ForegroundColor = ConsoleColor.Green;

                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("---------------------------------");
                }
        }
    



static void DrawUI(int x)
{
    Tile tile = new Tile();
    //todo Exception senare?
    if (x >= 0 || x <= 999) Console.WriteLine("Dimensionerna är för stora eller små!");

    // bräda måste vara fyrkant
    var y = x;

    Tile[,] board = new Tile[x, y];



}

static void movementRules()
{

    // Kollisionvalidering
    // Svart pjäs är (-) och vit pjäs är (+), tom steg = 0
    // Så om en vit torn (värde 8) försöker fram 5 steg, varav en vit bonde (värde 1) är två steg ifrån
    // kommer det bli 8+0+0+1+0+0 = 9 -> alltså FEL, torn får aldrig bli mer än 8
    // är ddet en svart bonde: 
    // 8+0+0+(-1)+0+0 = 7 -> FÅNGST av
    // (id 1 = bonde, tar då 1 som poäng, återställer torn till 8,
    // kmr göra matten i förväg för möjligt drag
    // och därmed räkna antal möjliga steg tills kollision/fångst )

    //b + a < a
    var whitePiece = 0;
    var blackPiece = 0;
    var emptyPlot = 0;


    var wtower = 8;
    var wpawn = 1;
    var btower = -8;
    var bpawn = -8;

    int[,] board = new int[8, 8];
    board[7, 0] = wtower;
    board[6, 0] = wpawn;
    board[1, 0] = btower;
    board[0, 0] = btower;

    int horizontalMove = 0;
    for (int row = 0; row < board.GetLength(0); row++)
    {
        Console.WriteLine(board[row, horizontalMove]);
    }



    bool validCollisions =
        (blackPiece + whitePiece) > blackPiece ||
        (whitePiece + blackPiece) < whitePiece ||
        (whitePiece + emptyPlot) == whitePiece ||
        (blackPiece + emptyPlot) == blackPiece;

    if (!validCollisions)
    {
        throw new Exception("Annan pjäs i vägen");
    }

    // Start pos
    var startX = 0;
    var startY = 0;

    // Slut pos
    var endX = 0;
    var endY = 0;

    // mäter förändring
    var dx = endX - startX;
    var dy = endY - startY;

    //(Δx, Δy) = (n, 0) ∣∣ (0, n)
    bool validTowerMove = (dx != 0 && dy == 0) || (dx == 0 && dy != 0);

    // ∣Δx∣=∣Δy∣ eller (Δx, Δy) = (n,0) ∣∣ (0,n)
    bool validQueenMove =
        (dx != 0 && dy == 0) ||
        (dx == 0 && dy != 0) ||
        (Math.Abs(dx) == Math.Abs(dy));

    bool validBishopMove = (Math.Abs(dx) == Math.Abs(dy));


}
    }

  
}





/***
 * 
 * Kollisionshantering för pjäser:
 * 
 * Tanke: 
 * vit (a) är plus, svart(b) minus
 * regel: 
 * b + a < a
 *
 * 
 * exempel:
 * vit pjäs = torn (+8)
 * svart pjäs = bonde (-1)
 * 
 * cases: 
 * 
 *  
 * vit torn (8) + svart bonde (-1) = 7
 * b + a < a stämmer! 
 * 
 * vit torn (8) + vit bonde (1) = 9
 * b + a < a stämmer inte! -> kasta fel
 * 
 * 
 * */


/**
 * 
 * Flyttningsregler för pjäser:
 * 
 * 
 * Vi har följande:
 * 
 * 
 * Bonde:
 * (vid första drag): 
 * (Δx, Δy) = (0, +2)
 * (efter första drag):
 *  (Δx, Δy) = (0, +1)
 * (vid fångst)
 *  Δy = (1, ±1) - x blir +- beroende på y
 *
 * Drottning: 
 * ∣Δx∣=∣Δy∣ eller (Δx, Δy) = (n,0) ∣∣ (0,n)
 * 
 * Kung: 
 * Δx2+Δy2≤2 (kvadrerat, varje riktning tillåtet men resultat är mindre än 2)
 * 
 * Löparen:
 * ∣Δx∣=∣Δy∣
 * 
 * Torn: 
 * (Δx, Δy) = (n,0) ∣∣ (0,n)
 * 
 * Springare: 
 * Δy^2 + Δx^2 == 5 (förändring i y i kvadrat + x i kvadrat  ska bli 5=
 * 
 * **/


