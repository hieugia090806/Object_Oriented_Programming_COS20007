//-This class is for the MainMenu interface-//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Tetris;

namespace Tetris
{
    public class MainMenu
    {
        //-Attributes-//
        private Form parentForm;
        private Panel mainMenuPanel; 
        private Label titleLabel;
        private Button playButton;
        private Image internalBackgroundImage; 

        public event EventHandler PlayButtonClicked;

        public MainMenu(Form form, Image backgroundImage = null)
        {
            parentForm = form;
            internalBackgroundImage = backgroundImage; 
            InitializeControls();
            CenterElements(); 
        }

        //-Method-//
        private void InitializeControls()
        {
            mainMenuPanel = new Panel
            {
                Visible = false, 
                BackColor = Color.Transparent, 
                BorderStyle = BorderStyle.None 
            };
            mainMenuPanel.Paint += MainMenuPanel_Paint;
            parentForm.Controls.Add(mainMenuPanel); 

            titleLabel = new Label
            {
                Text = "Welcome to the\nTetris Game",
                Font = new Font("Arial", 25, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter, 
                AutoSize = false, 
                BackColor = Color.Transparent 
            };
            mainMenuPanel.Controls.Add(titleLabel);

            playButton = ButtonManager.GetPlayButton(
                size: new Size(10, 5),
                clickHandler: (s, e) => PlayButtonClicked?.Invoke(this, EventArgs.Empty)
            );
            mainMenuPanel.Controls.Add(playButton);
            mainMenuPanel.BringToFront();
        }
        private void MainMenuPanel_Paint(object sender, PaintEventArgs e)
        {
            if (internalBackgroundImage != null)
            {
                e.Graphics.DrawImage(internalBackgroundImage, 0, 0, mainMenuPanel.Width, mainMenuPanel.Height);
            }

            // 2. Then, draw the semi-transparent black overlay on top of the image
            // The alpha value (180) controls the transparency (0 = fully transparent, 255 = fully opaque).
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(180, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(brush, 0, 0, mainMenuPanel.Width, mainMenuPanel.Height);
            }
        }

        /// <summary>
        /// Calculates and sets the position and size of the main menu elements to be centered.
        /// This method should be called upon initialization and whenever the parent form resizes.
        /// </summary>
        public void CenterElements()
        {
            // Define the desired size of the main menu panel (the faded black rectangle)
            // 30% of parent form's width, 85% of parent form's height
            int panelWidth = (int)(parentForm.ClientSize.Width * 0.4);
            int panelHeight = (int)(parentForm.ClientSize.Height * 0.85);

            // Calculate the panel's location to center it on the parent form
            int panelX = (parentForm.ClientSize.Width - panelWidth) / 2;
            int panelY = (parentForm.ClientSize.Height - panelHeight) / 2;

            mainMenuPanel.Location = new Point(panelX, panelY);
            mainMenuPanel.Size = new Size(panelWidth, panelHeight);

            // Center the Title Label within the mainMenuPanel
            // The label needs enough width to wrap text if necessary
            titleLabel.Size = new Size(panelWidth - 40, (int)(panelHeight * 0.3)); // 40px padding (20px left, 20px right)
            titleLabel.Location = new Point(20, (int)(panelHeight * 0.2)); // 20px left padding, 20% down from top of panel

            int playButtonWidth = (int)(panelWidth * 0.45); // Adjust this percentage if needed
            int playButtonHeight = (int)(panelHeight * 0.10); // Adjust this percentage if needed

            playButton.Size = new Size(playButtonWidth, playButtonHeight); // Set the button's new, dynamic size

            // Position the Play button: centered horizontally, and below the title with some padding.
            playButton.Location = new Point((panelWidth - playButton.Width) / 2, titleLabel.Bottom + (int)(panelHeight * 0.05)); // Add padding relative to panel height
        }

        /// <summary>
        /// Sets the visibility of the main menu.
        /// </summary>
        /// <param name="visible">True to show the menu, false to hide it.</param>
        public void SetVisibility(bool visible)
        {
            mainMenuPanel.Visible = visible;
            // Invalidate the parent form to ensure it redraws when the menu hides/shows,
            // revealing/concealing the background image.
            parentForm.Invalidate();
        }
    }
}