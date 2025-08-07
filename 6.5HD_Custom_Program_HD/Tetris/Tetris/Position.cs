//-The Position class defines a single coordinate (row/column)-//
//-Handles equality comparison for positions-//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;
//-Namespace-//
namespace Tetris
{
    public class Position //-Change from internal to public-//
    {
        //-Attributes-//
        public int Row { get; set; }
        public int Column { get; set; }
        //-Constructoe-//
        public Position(int row, int column)
        {
            Row = row; 
            Column = column;
        }
        //-Method_1: Checks if the position object is equal tp another object
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (!(obj is Position))
            {
                return false;
            }
            Position position = (Position)obj;
            return (this.Row == position.Row && this.Column == position.Column);
        }
        //-Method_2-//
        public override int GetHashCode()
        {
            // Combines the hash codes of Row and Column to create a unique hash for this Position.
            return System.HashCode.Combine(Row, Column);
        }
    }
}
