//-This class is for the IBlock-//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Blocks;

namespace Tetris.Blocks
{
    public class IBlock : Block
    {
        //-Set block Id-//
        public override int Id => 1;
        //-Defines shape for each rotation state-//
        private readonly Position[][] tiles = new Position[][]
        {
            //-new(1,0) means value of row is 1 and column is 0
            new Position[] { new(1,0), new(1,1), new(1,2), new(1,3) }, //-State_1-//
            new Position[] { new(0,2), new(1,2), new(2,2), new(3,2) }, //-State_2-//
        };
        protected override Position[][] Tiles => tiles;
        protected override Position StartOffset => new Position(-1, 3);

    }
}
