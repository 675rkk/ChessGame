using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Bishop : ChessPiece
    {
        public Bishop(PieceColor color, PiecePosition position) : base(PieceType.Bishop, color, position) { }

        public override List<PiecePosition> ValidMoves(ChessBoard board)
        {
            List<PiecePosition> moves = new List<PiecePosition>();
            for (int pos = 0; pos < 8; pos++)
            {
                moves.Add(new PiecePosition(Position.Row + pos, Position.Column + pos));
                moves.Add(new PiecePosition(Position.Row - pos, Position.Column - pos));
                moves.Add(new PiecePosition(Position.Row + pos, Position.Column - pos));
                moves.Add(new PiecePosition(Position.Row - pos, Position.Column + pos));
            }
            return moves;
        }
    }
}
