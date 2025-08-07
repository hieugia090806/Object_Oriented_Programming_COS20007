//-This class os for SBlock-//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Blocks
{
    public class SBlock : Block
    {
        //-Set block Id-//
        public override int Id => 5;
        //-Defines shape for each rotation state-//
        private readonly Position[][] tiles = new Position[][]
        {
            //-new(1,0) means value of row is 1 and column is 0
            new Position[] { new(0,1), new(0,2), new(1,0), new(1,1) }, //-State_1-//
            new Position[] { new(0,1), new(1,1), new(1,2), new(2,2) }, //-State_2-//
            new Position[] { new(1,1), new(1,2), new(2,0), new(2,1) }, //-State_3-//
            new Position[] { new(0,0), new(1,0), new(1,1), new(2,1) }, //-State_4-//
            


        };
        protected override Position[][] Tiles => tiles;
        protected override Position StartOffset => new Position(0, 3);
    }
}
