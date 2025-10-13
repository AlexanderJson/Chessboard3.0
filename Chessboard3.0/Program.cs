using Chessboard3._0.poco;

namespace Chessboard3._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // UTF8 är standard encoding, tillåter svenska karaktär, emojis etc
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int x;
            int y;



            int[,] triangle = new int[8,8];



        }
        static void DrawUI(int x)
        {
            Tile tile = new Tile();
            //todo Exception senare?
            if(x >= 0 || x <= 999)  Console.WriteLine("Dimensionerna är för stora eller små!") ;

            // bräda måste vara fyrkant
            var y = x;

            Tile[,] board = new Tile[x,y];



        }

        static void movementRules()
        {


            var steps = 0;


            
            // initiellt x, y
            var y = 0;
            var x = 0;
            // fånga in pjäsen position
            int startPosition = y + x;


            var nx = x + steps;
            var yx = x + steps;

            int dx = Math.Abs()



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