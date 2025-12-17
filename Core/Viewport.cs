using Raylib_cs;
using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Interfaces;
using static VGP133_Final_Assignment.Core.ResolutionManager;
using static VGP133_Final_Assignment.Game.GameColors;

namespace VGP133_Final_Assignment.Core
{
    public class Viewport : IDrawable
    {
        public Viewport(Vector2 position, Vector2 dimensions, bool isActive = false)
        {
            _position = position;
            _dimensions = dimensions;
            _closeButton =
                new ButtonRectangle(new Vector2(8,8), position, "button_close", true);
            _body =
                new Rectangle(_position * UIScale, _dimensions * UIScale);
            _isActive = isActive;
        }
        public void Update()
        {
            if (!_isActive) { return; }
            _closeButton.Update();
            if (_closeButton.IsPressed)
            {
                _isActive = false;
                _closeButton.IsPressed = false;
            }
        }

        public void Render()
        {
            if (!_isActive) { return; }
            Raylib.DrawRectangleRounded(_body, 0.08f, 1, LightBrown);
            Raylib.DrawRectangleRoundedLinesEx(_body, 0.1f, 5, 8f, DarkBrown);
            _closeButton.Render();
        }

        private ButtonRectangle _closeButton;
        private Vector2 _position;
        private Vector2 _dimensions;
        private Rectangle _body;
        private bool _isActive;
        public bool IsActive { get => _isActive; set => _isActive = value; }
    }
}
