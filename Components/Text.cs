using VGP133_Final_Assignment.Interfaces;
using Raylib_cs;
using System.Numerics;
using static VGP133_Final_Assignment.Core.ResolutionManager;

namespace VGP133_Final_Assignment.Components
{
    public class Text : IDrawable
    {
        public Text(string textData, Vector2 position, int fontSize, Color color)
        {
            _textData = textData;
            _position = position;
            _fontSize = fontSize;
            _color = color;
        }

        public void Render()
        {
            Raylib.DrawText(
                _textData,
                (int)_position.X * UIScale,
                (int)_position.Y * UIScale,
                _fontSize,
                _color
             );
        }

        public void Update()
        {

        }

        private string _textData = "";
        private Vector2 _position;
        private int _fontSize;
        private Color _color;
        private bool _isVisible;


        public string TextData { get => _textData; set => _textData = value; }

        public Color Color { get => _color; set => _color = value; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public Vector2 Position { get => _position; set => _position = value; }
    }
}
