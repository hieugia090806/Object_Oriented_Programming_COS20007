using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Tetris;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private MainMenu mainMenu;
        private GameState currentGameState; //Needed to mange game flow-//
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            this.Resize += Form1_Resize;
        }
        private void InitializeGame()
        {
            this.ClientSize = new Size(1000, 850); //-1000 in width and 850 in height-//
            this.Text = "Tetris Game"; //-Set the title for the window game-//
            //-Upload the game icon-//
            try
            {
                string iconPath = Path.Combine(Application.StartupPath, "D:\\University\\May_2025\\COS20007_Object_Oriented_Programming\\Weekly_exercises\\6.3D_Custom_Program\\Tetris\\Tetris\\Asset", "Icon.ico");
                if (File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath); // This line loads and sets the icon
                }
                else
                {
                    Console.WriteLine($"Icon file not found at: {iconPath}");
                    // Optionally set a default icon or display an error to the user
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading icon: {ex.Message}");
            }
            //-Upload background image-//
            try
            {
                this.BackgroundImage = AssetManager.GetBackgroundImage("Background.png");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Main Menu background: {ex.Message}", "Background Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error loading Main Menu background: {ex.Message}");
            }
            //-Upload background image inside the rectangle-//
            Image MenuInternalBgImage = null;

            try
            {
                MenuInternalBgImage = AssetManager.GetBackgroundImage("Internal_background.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Main Menu internal background: {ex.Message}", "Internal Background Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error loading Main Menu internal background: {ex.Message}");
            }
            //-Main Menu-//
            mainMenu = new MainMenu(this, MenuInternalBgImage);
            mainMenu.PlayButtonClicked += MainMenu_PlayButtonClicked;

            currentGameState = GameState.MainMenu;
            mainMenu.SetVisibility(true);

        }
        //-Methods for handling event-//
        private void MainMenu_PlayButtonClicked(object sender, EventArgs e)
        {
            currentGameState = GameState.Playing;
            mainMenu.SetVisibility(false); // Hide the main menu
            Console.WriteLine("Game Started!");
            this.Invalidate(); // Redraw the form to show game content
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Re-center the MainMenu elements when the form resizes
            if (mainMenu != null)
            {
                mainMenu.CenterElements();
            }
            this.Invalidate(); // Invalidate to ensure everything redraws correctly
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Call the base class OnPaint to draw the form's BackgroundImage first

            // You would draw your game elements here based on the currentGameState
            switch (currentGameState)
            {
                case GameState.MainMenu:
                    // MainMenu handles its own drawing, so nothing extra needed here for the menu itself.
                    break;
                case GameState.Playing:
                    // Example: Draw game-specific elements when playing
                    // e.Graphics.DrawString("Playing Game!", Font, Brushes.White, 10, 10);
                    break;
                    // Add cases for Paused, GameOver, etc.
            }
        }
    }
}