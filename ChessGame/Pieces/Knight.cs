using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Knight : ChessPiece
    {
        public Knight(PieceColor color, PiecePosition position) : base(PieceType.Knight, color, position) { }

        public override List<PiecePosition> ValidMoves(ChessBoard board)
        {
            List<PiecePosition> moves = new List<PiecePosition>();
            int[] rows = { -2, -1, 1, 2, 2, 1, -2, -2 };
            int[] cols = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int pos = 0; pos < 8; pos++)
            {
                int newRow = Position.Row + rows[pos];
                int newCol = Position.Column + cols[pos];
                if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                {
                    moves.Add(new PiecePosition(newRow, newCol));
                }
            }
            return moves;
        }
    }
}
