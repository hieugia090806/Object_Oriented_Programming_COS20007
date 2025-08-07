using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Tetris
{
    public static class AssetManager //-Change from internal to public static
    {
        //-Attributes-//
        private static readonly Dictionary<int, Image> _blockImages = new Dictionary<int, Image>();
        private static readonly Dictionary<int, Image> _tileImages = new Dictionary<int, Image>();
        private static readonly Dictionary<string, Image> _backgroundImages = new Dictionary<string, Image>();
        //-Constructor-//
        static AssetManager()
        {
            LoadAssets();
        }
        //-Methods-//
        public static void LoadAssets()
        {
            //-Clear existing assets if called multiple times-//
            _blockImages.Clear();
            _tileImages.Clear();
            _backgroundImages.Clear();
            //-Load Block Image-//
            _blockImages.Add(1, LoadImage("Block-I.png"));
            _blockImages.Add(2, LoadImage("Block-J.png"));
            _blockImages.Add(3, LoadImage("Block-J.png"));
            _blockImages.Add(4, LoadImage("Block-O.png"));
            _blockImages.Add(5, LoadImage("Block-S.png")); 
            _blockImages.Add(6, LoadImage("Block-T.png"));
            _blockImages.Add(7, LoadImage("Block-Z.png")); 
            //-Load tile images-//
            _tileImages.Add(0, LoadImage("TileEmpty.png"));
            _tileImages.Add(1, LoadImage("TileCyan.png")); 
            _tileImages.Add(2, LoadImage("TileBlue.png")); 
            _tileImages.Add(3, LoadImage("TileOrange.png")); 
            _tileImages.Add(4, LoadImage("TileYellow.png")); 
            _tileImages.Add(5, LoadImage("TileGreen.png")); 
            _tileImages.Add(6, LoadImage("TilePurple.png")); 
            _tileImages.Add(7, LoadImage("TileRed.png"));
            //-Load background images-//s
            _backgroundImages.Add("Background.png", LoadImage("Background.png"));
            _backgroundImages.Add("Background_level_1.jpg", LoadImage("Background_level_1.jpg")); 
            _backgroundImages.Add("Background_level_2.jpg", LoadImage("Background_level_2.jpg"));
            _backgroundImages.Add("Internal_background.jpg", LoadImage("Internal_background.jpg"));

        }
        private static Image LoadImage(string fileName)
        {
            string assetPath = Path.Combine(Application.StartupPath, "D:\\University\\May_2025\\COS20007_Object_Oriented_Programming\\Weekly_exercises\\6.3D_Custom_Program\\Tetris\\Tetris\\Asset", fileName);
            try
            {
                if (File.Exists(assetPath))
                { 
                    return new Bitmap(assetPath);
                }
                else
                        {
                            MessageBox.Show($"Asset file not found: {assetPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading asset '{fileName}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; 
            }
        }
        //-Get Block Images-//
        public static Image GetBlockImage(int blockId)
        {
            if (_blockImages.TryGetValue(blockId, out Image image))
            {
                return image;
            }
            else if (_blockImages.TryGetValue(0, out image))
            {
                return image;
            }
            return null;
        }
        //-Get Tile Image-//
        public static Image GetTileImage(int tileId)
        {
            if (_tileImages.TryGetValue(tileId, out Image image))
            {
                return image;
            }
            else if (_tileImages.TryGetValue(0, out image))
            {
                return image;
            }
            return null;
        }

        //-Get background image-//
        public static Image GetBackgroundImage(string fileName)
        {
            string actualFileName = Path.GetFileName(fileName);
            if (_backgroundImages.TryGetValue(actualFileName, out Image image))
            {
                return image;
            }
            MessageBox.Show($"Background image '{fileName}' not found in AssetManager.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
}
