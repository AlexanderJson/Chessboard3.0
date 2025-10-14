using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard3._0.poco
{
    public class Tile
    {
        public int Value { get; set; }
        public string ChessSymbol { get; set; } = string.Empty;

        public (int x, int y) LegalMoves { get; set; }


    }


}

