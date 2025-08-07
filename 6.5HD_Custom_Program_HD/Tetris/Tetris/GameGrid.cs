//-This class holds two dimensional array-//s
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;
//-Namespace-//
namespace Tetris
{
    public class GameGrid //-Change from internal to public
    {
        //-Attributes (Properties)-//
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }
        //-Constructor-//
        public GameGrid(int rows, int columns)
        {
            Rows = rows; 
            Columns = columns;
            grid = new int[Rows, Columns];
        }
        //-Methods-//
        //-Method_1: Checks if a given row and column are within the grids boundaries-//
        //-This method is extremely crucial for preventing "out of bounds" errors when checking block position-//
        public bool IsInside(int r, int c)
        {
            return r>=0 && r < Rows && c>=0 && c < Columns;
            //-r>0 ensures the row is not above the top boundary-//
            //-r<Rows ensures the row is not below the bottom boundary-//
            //-c>=0 ensures the column is not to the right of the rightmost boundary-//
            //-c<Columns ensures the column is not to the right of the rightmost boundary-//
        }
        //-Method_2: Checks a specific cell ar (r,c) is empty or not-/
        public bool IsEmpty(int r, int c)
        {
            return grid[r,c] == 0;
        }
        //-Method_3: Takes the integer value ID of the block occupying the cell ar (r,c)
        public int GetValue(int r, int c)
        {
            return grid[r, c];
        }
        public void SetValue(int r, int c, int value)
        {
            grid[r, c] = value;
        }
        //-Method_4: Checks if a row is full or not-//
        public bool IsRowFull(int r)
        {
            for (int c = 0; c <Columns; c++)
            {
                if (grid[r,c] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        //-ethod_5: Clears a full row and moves rows above down
        public void ClearRow(int r)
        {
            //-First, clear a full row-//
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
            //-Second, shifts rows above down-//
            for (int row = r - 1; row >= 0; row--)
            {
                for (int c = 0; c < Columns; c++)
                {
                    //-Move the cell's value from current row to row below
                    grid[row + 1, c] = grid[r, c];
                    //-Delete the orginal cell-//
                    grid[r, c] = 0;
                }
            }
        }
        //-Method_6: Scan from top to bottom, then cleared any full rows-//
        public int ClearFullRows()
        {
            int ClearedRows = 0;
            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    ClearedRows++;
                }
            }
            return ClearedRows;
        }
        // NEW METHOD: Clears the entire grid by setting all cells to 0 (empty).
        public void Clear()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    grid[r, c] = 0; // Set all cells to empty
                }
            }
        }
    }
}
