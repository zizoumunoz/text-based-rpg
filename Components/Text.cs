using VGP133_Final_Assignment.Interfaces;
using Raylib_cs;

namespace VGP133_Final_Assignment.Components
{
    public class Text : IDrawable
    {
        public Text(string textData, float x, float y, int fontSize, Color color)
        {
            _textData = textData;
            _x = x;
            _y = y;
            _fontSize = fontSize;
            _color = color;
        }

        public void Render()
        {
            Raylib.DrawText(_textData, (int)_x, (int)_y, _fontSize, _color);
        }

        public void Update()
        {
            
        }

        private string _textData = "";
        private float _x;
        private float _y;
        private int _fontSize;
        private Color _color;
        private bool _isVisible;


        public string TextData { get => _textData; set => _textData = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public Color Color { get => _color; set => _color = value; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
    }
}
