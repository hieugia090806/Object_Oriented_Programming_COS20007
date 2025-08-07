using Tetris;
using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Block
    {
        //-Two dimensional position array which contains tile positionss in four rotation states-//
        protected abstract Position[][] Tiles { get; }
        //-A start offset which decides where the block spawns in the grid
        protected abstract Position StartOffset { get; }
        //-Id of blocks-//
        public abstract int Id { get; }
        //-Stores the current rotationstate and current offset-//
        private int rotationState;
        private Position offset;
        //-Constructor-//
        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }
        //-Method returns grid positions occupied by the block factoring in current roation and offset-//
        public IEnumerable<Position> TilesPositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotationCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
