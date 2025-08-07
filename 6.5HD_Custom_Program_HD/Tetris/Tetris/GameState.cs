//-This class is for checking the game state-//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;

namespace Tetris
{
    public enum GameState
    {
        MainMenu, //-Main interface-//
        Playing, //-While playing-//
        Paused, //-When paused-//
        GameOver, //-GameOver-//
        LevelComplete,
    }
}
