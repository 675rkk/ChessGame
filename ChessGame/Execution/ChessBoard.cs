using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class ChessBoard
    {
        public ChessPiece[,] Board { get; set; }

        public ChessBoard()
        {
            Board = new ChessPiece[8, 8];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                Board[1, row] = new Pawn(PieceColor.Black, new PiecePosition(1, row));
                Board[6, row] = new Pawn(PieceColor.White, new PiecePosition(6, row));
            }
            Board[0, 0] = new Rook(PieceColor.Black, new PiecePosition(0, 0));
            Board[0, 1] = new Knight(PieceColor.Black, new PiecePosition(0, 1));
            Board[0, 2] = new Bishop(PieceColor.Black, new PiecePosition(0, 2));
            Board[0, 3] = new Queen(PieceColor.Black, new PiecePosition(0, 3));
            Board[0, 4] = new King(PieceColor.Black, new PiecePosition(0, 4));
            Board[0, 5] = new Bishop(PieceColor.Black, new PiecePosition(0, 5));
            Board[0, 6] = new Knight(PieceColor.Black, new PiecePosition(0, 6));
            Board[0, 7] = new Rook(PieceColor.Black, new PiecePosition(0, 7));

            Board[7, 0] = new Rook(PieceColor.White, new PiecePosition(7, 0));
            Board[7, 1] = new Knight(PieceColor.White, new PiecePosition(7, 1));
            Board[7, 2] = new Bishop(PieceColor.White, new PiecePosition(7, 2));
            Board[7, 3] = new Queen(PieceColor.White, new PiecePosition(7, 3));
            Board[7, 4] = new King(PieceColor.White, new PiecePosition(7, 4));
            Board[7, 5] = new Bishop(PieceColor.White, new PiecePosition(7, 5));
            Board[7, 6] = new Knight(PieceColor.White, new PiecePosition(7, 6));
            Board[7, 7] = new Rook(PieceColor.White, new PiecePosition(7, 7));
        }

        public ChessPiece GetPiece(PiecePosition position)
        {
            return Board[position.Row, position.Column];
        }

        public bool ValidMove(PiecePosition start, PiecePosition end)
        {
            ChessPiece piece = GetPiece(start);
            if (piece == null) return false;

            List<PiecePosition> valid = piece.ValidMoves(this);
            return valid.Contains(end);
        }

        public bool MovePiece(PiecePosition start, PiecePosition end)
        {
            ChessPiece piece = GetPiece(start);
            if (ValidMove(start, end))
            {
                if (end.Row >= 0 && end.Row < 8 && end.Column >= 0 && end.Column < 8)
                {
                    Board[end.Row, end.Column] = piece;
                    Board[start.Row, start.Column] = null;
                    piece.Position = end;
                    return true;
                }
            }
            return false;
        }
    }
}
