using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class Program
    {
        private enum Shapekind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            //Set window size and title
            Window window = new Window("ShapeDrawing_Task 4.1P", 800, 600);
            Drawing myDrawing = new Drawing();
            Shapekind kindToAdd = Shapekind.Circle; //Default shape to add
            //Main loop
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                //Change background color when space key is pressed
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }
                //When lift-clicked mouse, it will draw rectangle as the default shape
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    switch (kindToAdd)
                    {
                        case Shapekind.Circle:
                            newShape = new MyCircle();
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                            break;
                        case Shapekind.Line:
                            newShape = new MyLine();
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                            break;
                        default:
                            newShape = new MyRectangle();
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                            break;
                    }
                    myDrawing.AddShape(newShape);
                }
                //Change to draw rectangle if press R key
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = Shapekind.Rectangle;
                }
                //Change to draw crcle if press C key
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = Shapekind.Circle;
                }
                //Change to draw line if press L key
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = Shapekind.Line;
                }
                //Displat border for all shapes with right-clicked mouse
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }
                //Changing colors of rectangles when pressing B key
                if (SplashKit.KeyTyped(KeyCode.BKey))
                {
                    foreach (Shape s in myDrawing.Shapes)
                    {
                        s.Color = SplashKit.RandomRGBColor(255);
                    }
                }
                //Delete selected shapes when pressing Delete or Backspace key
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }
                myDrawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
