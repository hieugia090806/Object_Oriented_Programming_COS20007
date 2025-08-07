using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;

namespace Tetris
{
    public class Level //-Change from internal to public-//
    {
        //-Attributes-//
        public int LevelNumber { get; set; } //-LevelNumber property-//
        public int TimeLimitSeconds { get; set; } //-TimeLimit property-//
        public int Speed { get; set; } //-Speed for dropping block-//
        public int RequiredScore { get; set; } //-Required Score-//
        public string BackgroundImagePath { get; set; } //-ImageBackground-//
        //-Constructor-//
        public Level(int levelNumber, int timeLimit, int speed, int requiredScore, string backgroundImagePath)
        {
            LevelNumber = levelNumber;
            TimeLimitSeconds = timeLimit;
            Speed = speed;
            RequiredScore = requiredScore;
            BackgroundImagePath = backgroundImagePath;
        }
    }
}
