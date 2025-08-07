//-This class os for Level setting-//
using Tetris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tetris
{
    public static class GameLevel
    {
        public static List<Level> Levels { get; } = new List<Level>()
        {
            new Level(1, 120, 500, 80, "Asset/Background_level_1.jpg"),
            //-1 means Level 1-//
            //-120 means timeLimit-//
            //-500 means speed-//
            //-100 means requiredScore-//
            new Level(2, 100, 550, 90, "Asset/Background_level_2.jpg"),
            //-Can add more level if needed-//
        };
        public static Level GetLevel(int levelNumber)
        {
            return Levels.Find(l => l.LevelNumber == levelNumber);
        }
        public static int MaxLevelNumber => Levels.Count;
    }
}
