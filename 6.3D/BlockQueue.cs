//-This class is responsible for generating next block in game-//
using Tetris;
using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;

using System;
namespace Tetris
{
    public class BlockQueue
    {
        //-Block array with an instance of 7 blocks that will recycle-//
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };
        //-Random object-//
        private readonly Random random = new Random();
        //-Property-//s
        public Block NextBlock { get; private set;}

        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }

    }
}
