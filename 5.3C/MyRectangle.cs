 using System;
 using System.Collections.Generic;
 using System.Drawing;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using Microsoft.VisualBasic;
using ShapeDrawing;
 using SplashKitSDK;
 namespace ShapeDrawing
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;
        private const int LastDigitStudentID = 0;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public MyRectangle() : this(SplashKitSDK.Color.White, 100, 80, 100, 80)
        {
        }
        public MyRectangle(SplashKitSDK.Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
            if (Selected)
            {
                DrawOutline();
            }
        }
        public override void DrawOutline()
        {
            int Offset = 5 + LastDigitStudentID;
            float OutlineX = X - Offset;
            float OutlineY = Y - Offset;
            int OutlineWidth = _width + (2 * Offset);
            int OutlineHeight = _height + (2 * Offset);
            SplashKit.DrawRectangle(SplashKitSDK.Color.Black, OutlineX, OutlineY, OutlineWidth, OutlineHeight);
        }
        public override bool IsAt(Point2D p)
        {
            return SplashKit.PointInRectangle(p, SplashKit.RectangleFrom(X, Y, Width, Height));
        }
        //Step 6 of task 5.3C
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}