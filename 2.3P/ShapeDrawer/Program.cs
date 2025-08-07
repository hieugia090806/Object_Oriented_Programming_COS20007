using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            Shape myShape;
            myShape = new Shape(120); 

            
            myShape.Width = 50;
            myShape.Height = 50;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(SplashKit.ColorWhite()); 

                
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    
                    Point2D mousePoint = SplashKit.MousePosition(); 

                    
                    if (myShape.IsAt(mousePoint))
                    {
                        myShape.Color = SplashKit.RandomColor();
                    }
                    
                    else
                    {
                        
                        myShape.X = (float)SplashKit.MouseX();
                        myShape.Y = (float)SplashKit.MouseY();
                    }
                }

                
                if (SplashKit.KeyTyped(KeyCode.SpaceKey) && myShape.IsAt(SplashKit.MousePosition()))
                {
                    myShape.Color = SplashKit.RandomColor();
                }

               
                myShape.Draw();

                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);

            window.Close();
        }
    }
}