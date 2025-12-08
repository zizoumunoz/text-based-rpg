using Raylib_cs;
using System.Numerics;
using VGP133_Final_Assignment.Core;
using VGP133_Final_Assignment.Interfaces;
using static VGP133_Final_Assignment.Core.ResolutionManager;

namespace VGP133_Final_Assignment.Components
{
    public class Sprite : IDrawable
    {
        public Sprite(string textureName, Vector2 position, bool isVisible = true)
        {
            _position = position;
            _isVisible = isVisible;
            _offset = new Vector2(0, 0);
            _texture = AssetManager.GetTexture(textureName);
            // set filter for pixel art sharpness
            Raylib.SetTextureFilter(_texture, TextureFilter.Point);
        }

        // IDrawable inherit
        public void Render()
        {
            Raylib.DrawTextureEx(_texture, (_position + _offset) * UIScale, 0f, UIScale, _tint);
        }

        public void RenderWithOutline()
        {
            // Draw scaled up white version first for outline
            Raylib.DrawTextureEx(
                _texture,
                (_position + _offset) * UIScale,
                0f,
                UIScale + _outlineScale,
                Color.Black
                );
        }

        // IDrawable inherit
        public void Update()
        {
            switch (_isVisible)
            {
                case true:
                    _tint = Color.RayWhite;
                    break;
                default:
                    _tint = new Color(0, 0, 0, 0);
                    break;
            }
        }

        private const float _outlineScale = 0.2f;

        private Texture2D _texture;
        private Color _tint = Color.RayWhite;

        private Vector2 _position;
        private Vector2 _offset;
        private float _scale;
        private bool _isVisible;
        private bool _hasOutline;

        public Vector2 Position { get => _position; set => _position = value; }
        public float Scale { get => _scale; set => _scale = value; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public Vector2 Offset { get => _offset; set => _offset = value; }
        public bool HasOutline { get => _hasOutline; set => _hasOutline = value; }
    }
}
