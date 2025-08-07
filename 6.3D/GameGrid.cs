//-This class holds two-dimensional rectangular array-//
using Tetris;
using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid //-Change from internal to public-//
    {
        private readonly int[,] grid;
        public int Rows { get; } //-First dimension is row-//
        public int Columns { get; } //-Second dimension is column-//
        //-The indexer below allows to easy access to the array-//
        //-The indexer directly on a gamegrid object-//
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        //-Constructor take number of rows & columns as parameters-//
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }
        //-Checks if a give cell is inside the gris or not-//
        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }
        //-Checls if a given cell is empty or not-//
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }
        //-Vhecks if a row is full or not-//
        //-If not, return value false. Otherwise is true-//
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }
        //-Checks if a row is empty ot not-//
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }
        //-If a row is empty, clear ir-//
        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }
        //-Then Move rows down-//
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }
        //-Method for clear full rows-//
        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = Rows-1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                     MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}
