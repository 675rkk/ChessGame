using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Pawn : ChessPiece
    {
        public Pawn(PieceColor color, PiecePosition position) : base(PieceType.Pawn, color, position) { }
        public override List<PiecePosition> ValidMoves(ChessBoard board)
        {
            List<PiecePosition> moves = new List<PiecePosition>();
            int direction = (Color == PieceColor.White ? -1 : 1);
            int newRow = Position.Row + direction;
            if (newRow >= 0 && newRow <= 7)
            {
                moves.Add(new PiecePosition(newRow, Position.Column));
                if (Color == PieceColor.White && Position.Row == 6)
                {
                    moves.Add(new PiecePosition(newRow - 1, Position.Column));
                }
                else if (Color == PieceColor.Black && Position.Row == 1)
                {
                    moves.Add(new PiecePosition(newRow + 1, Position.Column));
                }
            }
            return moves;
        }
    }
}
