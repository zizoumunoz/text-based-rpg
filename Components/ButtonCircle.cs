using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace VGP133_Final_Assignment.Components
{
    public class ButtonCircle
    {
        public ButtonCircle(float radius, int xCoordinate, int yCoordinate)
        {
            _radius = radius;
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
        }

        public void Update()
        {
            _isMouseColliding = Raylib.CheckCollisionPointCircle(Raylib.GetMousePosition(), new Vector2(_xCoordinate, _yCoordinate), _radius);
            _isPressed = (_isMouseColliding && Raylib.IsMouseButtonPressed(MouseButton.Left));
        }

        public void Render()
        {
            Raylib.DrawCircle(_xCoordinate, _yCoordinate, _radius, new Color(0, 0, 0, 0));
        }

        private float _radius;
        private int _xCoordinate;
        private int _yCoordinate;
        private bool _isMouseColliding;
        private bool _isPressed = false;

        public float Radius { get => _radius; set => _radius = value; }
        public int XCoordinate { get => _xCoordinate; set => _xCoordinate = value; }
        public int YCoordinate { get => _yCoordinate; set => _yCoordinate = value; }
        public bool IsPressed { get => _isPressed; set => _isPressed = value; }
    }
}
