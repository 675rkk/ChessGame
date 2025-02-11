using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class PiecePosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public PiecePosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            if (obj is PiecePosition pos)
            {
                return this.Row == pos.Row && this.Column == pos.Column;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Row, Column).GetHashCode();
        }
    }
}