//-This class is for GameBoard-//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Blocks;
// Removed unused using directives:
// using System.DirectoryServices.ActiveDirectory;
// using System.Security.Cryptography;

namespace Tetris
{
    public class BoardGame //-Change form internal to public-//
    {
        //-Attrivutes-//
        public GameGrid GameGrid { get; }
        public Block CurrentBlock { get; private set; } //-This code line is for the block currently falling-//
        public Block NextBlock { get; private set; } //-This code line is for showing random net block-//
        public Block HeldBlock { get; private set; } //This code line is for showing held blockk-//
        public bool CanHold { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }
        private Block[] blocks;
        private Random random = new Random();
        //-Constructor-//
        public BoardGame(int rows, int columns)
        {
            GameGrid = new GameGrid(rows, columns);
            Score = 0;
            GameOver = false;
            CanHold = true;
            blocks = new Block[]
            {
                new IBlock(),
                new JBlock(),
                new LBlock(),
                new OBlock(),
                new SBlock(),
                new TBlock(),
                new ZBlock(),
            };
            CurrentBlock = GetRandomBlock();
            NextBlock = GetRandomBlock();
        }
        //-Methods-//
        //-Method_1: Create random block-//
        private Block GetRandomBlock()
        {
            Block blockType = blocks[random.Next(blocks.Length)];

            if (blockType is IBlock)
            {
                return new IBlock();
            }
            else if (blockType is JBlock)
            {
                return new JBlock();
            }
            else if (blockType is LBlock)
            {
                return new LBlock();
            }
            else if (blockType is OBlock)
            {
                return new OBlock();
            }
            else if (blockType is SBlock)
            {
                return new SBlock();
            }
            else if (blockType is ZBlock)
            {
                return new ZBlock();
            }
            else if (blockType is TBlock) // TBlock was out of order, but functionality is fine.
            {
                return new TBlock();
            }
            else
            {
                return null;
            }
        }
        //-Method_2: Checks if a block position is valid (with bounds and not colliding)
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsInside(p.Row, p.Column) || !GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }
        
        
        //-Method_3: Place block-//
        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid.SetValue(p.Row, p.Column, CurrentBlock.Id);
            }
            if (CurrentBlock.RowOffset <= 0)
            {
                GameOver = true;
            }
            else
            {
                Score += GameGrid.ClearFullRows() * 5;
                CurrentBlock = NextBlock;
                NextBlock = GetRandomBlock();
                CanHold = true;
            }
        }
        //-Method_4: Move block down-//
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);
            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }
        //-Method_5: Move Block left-//
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        //-Method_6: Move Block Right-//
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits()) // Corrected: Check if it *doesn't* fit
            {
                CurrentBlock.Move(0, -1);
            }
        }
        //-Method_7: Rotate current block clockwise-//
        public void RotateBlockClockwise()
        {
            CurrentBlock.RotateClockwise();
            if (!BlockFits())
            {
                CurrentBlock.RotateCounterClockwise();
            }
        }
        //-Method_8: Rotate current block counter-clockwise-//
        public void RotateBlockCounterClockwise()
        {
            CurrentBlock.RotateCounterClockwise();
            if (!BlockFits())
            {
                CurrentBlock.RotateClockwise();
            }
        }
        //-Method_9-//
        public void HardDrop()
        {
            int dropRows = DropDistance();
            CurrentBlock.Move(dropRows, 0);
            PlaceBlock();
        }
        //-Method_10-//
        private int DropDistance()
        {
            int drop = 0;
            while (true)
            {
                CurrentBlock.Move(1, 0);
                if (!BlockFits())
                {
                    CurrentBlock.Move(-1, 0);
                    break;
                }
                drop++;
            }
            return drop;
        }
        //-Method_11-//
        public void HoldBlock()
        {
            if (!CanHold) return;
            CurrentBlock.Reset();

            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = NextBlock;
                NextBlock = GetRandomBlock();
            }
            else
            {
                Block temp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = temp;
            }
            CanHold = false;
        }
        //-Method_12: Game Restart-//
        public void Restart()
        {
            // GameGrid is read-only, so we call a Clear method on the existing object
            GameGrid.Clear(); // This assumes you've added a Clear() method to GameGrid.cs
            Score = 0;
            GameOver = false;
            CanHold = true;
            CurrentBlock = GetRandomBlock();
            NextBlock = GetRandomBlock();
            HeldBlock = null; // Clear held block
        }
    }
}