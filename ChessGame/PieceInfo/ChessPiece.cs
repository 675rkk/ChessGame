using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public abstract class ChessPiece
    {
        public PieceType Type { get; set; }
        public PieceColor Color { get; set; }
        public PiecePosition Position { get; set; }
        protected ChessPiece(PieceType type, PieceColor color, PiecePosition position)
        {
            Type = type;
            Color = color;
            Position = position;
        }

        public abstract List<PiecePosition> ValidMoves(ChessBoard board);
    }
}
