using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Rook : ChessPiece
    {
        public Rook(PieceColor color, PiecePosition position) : base(PieceType.Rook, color, position) { }

        public override List<PiecePosition> ValidMoves(ChessBoard board)
        {
            var moves = new List<PiecePosition>();
            for (int i = 0; i < 8; i++)
            {
                if (i != Position.Row) moves.Add(new PiecePosition(i, Position.Column));
                if (i != Position.Column) moves.Add(new PiecePosition(Position.Row, i));
            }
            return moves;
        }
    }
}
