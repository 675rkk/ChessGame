using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class King : ChessPiece
    {
        public King(PieceColor color, PiecePosition position) : base(PieceType.King, color, position) { }

        public override List<PiecePosition> ValidMoves(ChessBoard board)
        {
            var moves = new List<PiecePosition>();
            int[] rowMoves = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colMoves = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                int newRow = Position.Row + rowMoves[i];
                int newCol = Position.Column + colMoves[i];
                if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                {
                    moves.Add(new PiecePosition(newRow, newCol));
                }
            }
            return moves;
        }
    }
}
