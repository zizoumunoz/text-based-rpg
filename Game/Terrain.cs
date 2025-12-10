using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Interfaces;

namespace VGP133_Final_Assignment.Game
{
    public abstract class Terrain : IDrawable
    {
        public abstract void Render();

        public abstract void Update();

        protected string _name = "";
        protected Vector2 _location;
        protected Sprite? _sprite;
        protected List<Monster>? _monsterPool;

    }
}
