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
            _maxChars = 24;
        }

        public void Update()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), _box))
            {
                _isMouseOnText = true;
            }
            else
            {
                _isMouseOnText = false;
            }
            if (_isMouseOnText && _textData.Length < _maxChars)
            {
                Raylib.SetMouseCursor(MouseCursor.IBeam);
                int key = Raylib.GetCharPressed();

                // while key is returing something. getcharpressed returns zero if nothing pressed
                while (key > 0)
                {
                    if (key >= 32 && key <= 125)
                    {
                        _textData += (char)key;
                    }
                    key = Raylib.GetCharPressed();
                }

                if (Raylib.IsKeyPressed(KeyboardKey.Backspace) && _textData.Length > 0)
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
            Raylib.DrawRectangleRec(_box, Color.Red);
            Raylib.DrawText(_textData, _xCoord, _yCoord, 50, Color.White);

            // blinking cursor
            if (_isMouseOnText && (_framesCounter / 20) % 2 == 0)
            {
                int textWidth = Raylib.MeasureText(_textData, 50);
                Raylib.DrawText("_", _xCoord + textWidth, _yCoord, 50, Color.Black);
            }
        }

        private int _width;
        private int _height;
        private int _xCoord;
        private int _yCoord;
        private int _maxChars;
        private int _framesCounter = 0;
        private string _textData = "Name";
        private bool _isMouseOnText;
        private Rectangle _box;

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int XCoord { get => _xCoord; set => _xCoord = value; }
        public int YCoord { get => _yCoord; set => _yCoord = value; }
        public string? TextData { get => _textData; set => _textData = value; }
    }
}
