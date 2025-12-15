using System.Numerics;
using Raylib_cs;
using VGP133_Final_Assignment.Interfaces;
using static VGP133_Final_Assignment.Core.ResolutionManager;

namespace VGP133_Final_Assignment.Components
{
    public class ButtonRectangle : IDrawable
    {
        public ButtonRectangle(int width, int height, int x, int y, string texturePath, bool render = false)
        {
            _width = width * UIScale;
            _height = height * UIScale;
            _x = x * UIScale;
            _y = y * UIScale;
            _posRaw = new Vector2(x, y);
            _hitbox = new Rectangle(_x, _y, _width, _height);
            _texture =
                new Sprite(texturePath, new Vector2(x, y));

            if (render)
            {
                _color = new Color(255, 0, 0, 50);
            }
            else
            {
                _color = new Color(0, 0, 0, 0);
            }
        }

        public ButtonRectangle(Vector2 dimensions, Vector2 position, string texturePath, bool render = false)
        {
            _width = (int)dimensions.X * UIScale;
            _height = (int)dimensions.Y * UIScale;
            _x = (int)position.X * UIScale;
            _y = (int)position.Y * UIScale;
            _posRaw = new Vector2(_x, _y);
            _hitbox = new Rectangle(_x, _y, _width, _height);
            _texture =
                new Sprite(texturePath, new Vector2(_x, _y));

            if (render)
            {
                _color = new Color(255, 0, 0, 50);
            }
            else
            {
                _color = new Color(0, 0, 0, 0);
            }
        }

        // IDrawable
        public void Update()
        {
            // check hover
            _isMouseHovering = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), _hitbox);

            _texture.IsVisible = _isMouseHovering;

            // toggle is clicked
            if (_isMouseHovering && Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                _isPressed = true;
            }
            _texture.Update();
        }

        // IDrawable
        public void Render()
        {
            Raylib.DrawRectangle(_x, _y, _width, _height, _color);
            _texture.Render();
        }

        private bool _isMouseHovering;
        private bool _isPressed;
        private Rectangle _hitbox;
        private Sprite _texture;
        private Color _color;

        private Vector2 _posRaw;
        private int _width;
        private int _height;
        private int _x;
        private int _y;

        public Vector2 PositionRaw { get => _posRaw; set => _posRaw = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public Sprite Texture { get => _texture; set => _texture = value; }
        public bool IsPressed { get => _isPressed; set => _isPressed = value; }
    }
}
