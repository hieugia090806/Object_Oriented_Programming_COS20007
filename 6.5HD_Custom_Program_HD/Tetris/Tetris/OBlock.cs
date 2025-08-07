//-This class is for the OBlock-//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-Namespace-//
namespace Tetris.Blocks
{
    public class OBlock : Block
    {
        //-Set block id-//
        public override int Id => 4;
        //-Defines shape for each rotation state-//
        private readonly Position[][] tiles = new Position[][]
        {
            //-The OBlock is special because it is 2x2 square size so whatever it's rotate, it'e still the same-//
            new Position[] { new(0,0), new(0,1), new(1,0), new(1,1) },
        };
        protected override Position[][] Tiles => tiles;
        protected override Position StartOffset => new Position(0, 4);
    }
}
