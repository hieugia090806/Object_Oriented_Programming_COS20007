//This class stores a row and a column-//
using Tetris;
using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tetris
{
    public class Position
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

    }
}
