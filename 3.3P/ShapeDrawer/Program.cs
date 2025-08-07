using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            //Step 14
            Drawing myDrawing = new Drawing();
            //Creativity
            Shape LastCreatedShape = null;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(SplashKit.ColorYellow());

                //Step 15.1: 
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = new Shape(50);
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    myDrawing.AddShape(newShape);
                    //Creativity
                    LastCreatedShape = newShape;
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }
                //Step 15.2: 
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    //ColorLemonChiffon is a light yellow color
                    myDrawing.Background = SplashKit.ColorLemonChiffon(); //Change background color to yellow
                }
                //Press C to change the color
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    if (myDrawing.ActiveShape != null)
                    {
                        myDrawing.ActiveShape.Color = SplashKit.RandomColor(); //Change the color of the active shape to a random color
                    }
                }
                //Step 23 Delete a shape
                //Creativity points: Delete a second shape but the first one sill remains
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    if (myDrawing.ActiveShape != null)
                    {
                        myDrawing.RemoveShape(myDrawing.ActiveShape);
                        //Creativity
                        if (myDrawing.ActiveShape == LastCreatedShape)
                        {
                            LastCreatedShape = null;
                        }
                    }
                    //Creativity
                    else if (LastCreatedShape != null)
                    {
                        myDrawing.RemoveShape(LastCreatedShape);
                        LastCreatedShape = null;
                    }
                }
                //Step 15.3: 
                myDrawing.Draw();
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);

            window.Close();
        }
    }
}