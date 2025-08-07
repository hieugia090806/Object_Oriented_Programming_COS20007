//-The Block class is the abstract base for all Tetris blocks-//
//defining common properties (ID, rotations, offset) and behavious for movement and rotation-//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;
//-Namespace-//
namespace Tetris.Blocks
{
    public abstract class Block //-Change from internal to public abstract-//
    {
        //-Attributes-//
        public abstract int Id { get; }
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public int RotationState { get; set; }
        //-Current vertical position of the block's top-left corner on the grid
        public int RowOffset { get; set; }
        //-Current horizontal position of the block's top-left corner on the grid
        public int ColumnOffset { get; set; }
        //-Constructor-//
        public Block()
        {
            RotationState = 0;
            RowOffset = StartOffset.Row;
            ColumnOffset = StartOffset.Column;
        }
        //-Methods-//
        //-Method_1: Returns the positions of the block's individual tiles on the grid-//
        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[RotationState])
            {
                yield return new Position(p.Row + RowOffset, p.Column + ColumnOffset);
            }
        }
        //-Method_2: Rotates he block clockwise-//
        public void RotateClockwise()
        {
            RotationState = (RotationState + 1) % Tiles.Length;
        }
        //-Method_3: Rotate the block counter-clockwise-//
        public void RotateCounterClockwise()
        {
            RotationState = (RotationState + Tiles.Length - 1) % Tiles.Length;
        }
        //-Method_4: Moves the block by a given row and column amount-//
        public void Move(int rows, int columns)
        {
            RowOffset += rows;
            ColumnOffset += columns;
        }
        //-Method_5: Resets the blocks position and rotation state-//
        public void Reset()
        {
            RotationState = 0;
            RowOffset = StartOffset.Row;
            ColumnOffset = StartOffset.Column;
        }
    }
}
