using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace VGP133_Final_Assignment.Components
{
    public class Sprite
    {

        public Sprite(string filePath, Vector2 position, float scale = 1f)
        {
            _position = position;
            _scale = scale;
            _texture = Raylib.LoadTexture(filePath);
            // set filter for pixel art sharpness
            Raylib.SetTextureFilter(_texture, TextureFilter.Point);


        }

        public void Render()
        {
            Raylib.DrawTextureEx(_texture, _position, 0f, _scale, Color.RayWhite);
        }

        public void Update()
        {

        }

        public void Unload()
        {
            Raylib.UnloadTexture(_texture);
        }

        private Texture2D _texture;
        private Vector2 _position;
        private float _scale;

        public Vector2 Position { get => _position; set => _position = value; }
        public float Scale { get => _scale; set => _scale = value; }
    }
}
