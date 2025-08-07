using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawing
{
    public abstract class Shape //Change from internal to external
    {
        //Set attributes
        private SplashKitSDK.Color _color;
        private float _x;
        private float _y;
        private bool _selected;
        //set attributes adn methods
        public Shape() : this(SplashKitSDK.Color.White)
        {

        }
        public Shape(SplashKitSDK.Color color)
        {
            Color = color;
        }
        public SplashKitSDK.Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
        public abstract bool IsAt(Point2D pt);
        public abstract void Draw();
        public abstract void DrawOutline();
    }
}
