//-This class is for controlling Button image and align with game flow-//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using Tetris;

namespace Tetris
{
    public static class ButtonManager //-Change from internal to public-static-//
    {
        public static Button GetPlayButton(Size size, EventHandler clickHandler)
        {
            const string buttonText = "PLAY"; // Changed from fallbackText to be always used
            Font buttonFont = new Font("Arial", 17, FontStyle.Bold); // Increased font size for better visibility
            Color buttonForeColor = Color.White;
            Color buttonBackColor = Color.FromArgb(76, 175, 80); // This will be the solid green rectangle color

            Button button = new Button
            {
                Size = size, // The size will still be determined by MainMenu.cs
                Text = buttonText, // Always set the text
                Font = buttonFont, // Always set the font
                ForeColor = buttonForeColor, // Always set the text color
                BackColor = buttonBackColor, // Always set the background color to solid green

                FlatStyle = FlatStyle.Flat, // Use FlatStyle for maximum control over asppearance
                // --- CRUCIAL LINES TO ENSURE NO BORDERS OR DEFAULT HIGHLIGHTS ---
                FlatAppearance =
                {
                    BorderSize = 2,               // Absolutely no border!
                    BorderColor = buttonBackColor, // Make the border color match the button color if it shows up
                    MouseOverBackColor = buttonBackColor, // Keep the same color on hover
                    MouseDownBackColor = buttonBackColor, // Keep the same color on click
                    CheckedBackColor = buttonBackColor,   // Keep the same color if checked
                },
                // --- END CRUCIAL BORDER/HIGHLIGHT LINES ---

                Cursor = Cursors.Hand,   // Shows a hand cursor when hovering
                TabStop = false
            };
            
            button.Click += clickHandler;

            return button; // Here's your brand-new Play button!
        }
    }
}
