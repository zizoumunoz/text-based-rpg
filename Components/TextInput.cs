using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace VGP133_Final_Assignment.Components
{
    public class TextInput
    {
        public TextInput(int length, int height, int xCoord, int yCoord)
        {
            _width = length;
            _height = height;
            _xCoord = xCoord;
            _yCoord = yCoord;
            _box = new Rectangle(_xCoord, _yCoord, _width, _height);
            _maxChars = 18;
        }

        public void Update()
        {
            _isMouseOnText = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), _box);

            if (_isMouseOnText)
            {
                Raylib.SetMouseCursor(MouseCursor.IBeam);
                if (_textData.Length < _maxChars)
                {
                    int key = Raylib.GetCharPressed();
                    while (key > 0)
                    {
                        if (key >= 32 && key <= 125)
                        {
                            _textData += (char)key;
                        }
                        key = Raylib.GetCharPressed();
                    }

                }
                // while key is returing something. getcharpressed returns zero if nothing pressed
                if (Raylib.IsKeyDown(KeyboardKey.LeftControl) && Raylib.IsKeyPressed(KeyboardKey.Backspace))
                {
                    _textData = "";
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Backspace) && _textData.Length > 0)
                {
                        _textData = _textData.Remove(_textData.Length - 1);
                }
            }
            else
            {
                Raylib.SetMouseCursor(MouseCursor.Arrow);
            }
            if (_isMouseOnText)
            {
                _framesCounter++;
            }
            else { _framesCounter = 0; }
        }

        public void Render()
        {
            Raylib.DrawRectangleRec(_box, new Color(0, 0, 0, 0));
            Raylib.DrawText(_textData, _xCoord + _padding, _yCoord, _fontSize, new Color(178, 139, 120));

            // blinking cursor
            if (_isMouseOnText && (_framesCounter / 20) % 2 == 0)
            {
                int textWidth = Raylib.MeasureText(_textData, _fontSize);
                Raylib.DrawText("_", _xCoord + _padding + textWidth + 5, _yCoord, _fontSize, new Color(178, 139, 120));
            }
        }

        private int _width;
        private int _height;
        private int _xCoord;
        private int _yCoord;
        private int _maxChars;
        private int _framesCounter = 0;
        private const int _padding = 10;
        private const int _fontSize = 50;
        private string _textData = "Name";
        private bool _isMouseOnText;
        private Rectangle _box;

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int XCoord { get => _xCoord; set => _xCoord = value; }
        public int YCoord { get => _yCoord; set => _yCoord = value; }
        public string? TextData { get => _textData; set => _textData = value ?? "Unknown"; }
    }
}
