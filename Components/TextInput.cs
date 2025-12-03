using System;
using System.Collections.Generic;
using System.Text;

namespace VGP133_Final_Assignment.Components
{
    public class TextInput
    {
        public TextInput(int length, int height, int xCoord, int yCoord)
        {
            _length = length;
            _height = height;
            _xCoord = xCoord;
            _yCoord = yCoord;
        }

        private int _length;
        private int _height;
        private int _xCoord;
        private int _yCoord;
        private string? _textData;
        public int Length { get => _length; set => _length = value; }
        public int Height { get => _height; set => _height = value; }
        public int XCoord { get => _xCoord; set => _xCoord = value; }
        public int YCoord { get => _yCoord; set => _yCoord = value; }
        public string? TextData { get => _textData; set => _textData = value; }
    }
}
