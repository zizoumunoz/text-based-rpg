using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace VGP133_Final_Assignment.Components
{
    public class Sprite
    {

        public Sprite(string filePath, Vector2 position, float scale = 1f, bool isVisible = true)
        {
            _position = position;
            _scale = scale;
            _texture = Raylib.LoadTexture(filePath);
            _isVisible = isVisible;

            // set filter for pixel art sharpness
            Raylib.SetTextureFilter(_texture, TextureFilter.Point);

        }

        public void Render()
        {
            Raylib.DrawTextureEx(_texture, _position, 0f, _scale, _tint);
        }

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

        public void Unload()
        {
            Raylib.UnloadTexture(_texture);
        }

        private Texture2D _texture;
        private Color _tint = Color.RayWhite;

        private Vector2 _position;
        private float _scale;
        private bool _isVisible;


        public Vector2 Position { get => _position; set => _position = value; }
        public float Scale { get => _scale; set => _scale = value; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
    }
}
