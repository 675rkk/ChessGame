using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Queen : ChessPiece
    {
        public Queen(PieceColor color, PiecePosition position) : base(PieceType.Queen, color, position) { }

        public override List<PiecePosition> ValidMoves(ChessBoard board)
        {
            var moves = new List<PiecePosition>();
            moves.AddRange(new Rook(Color, Position).ValidMoves(board));
            moves.AddRange(new Bishop(Color, Position).ValidMoves(board));
            return moves;
        }
    }
}
