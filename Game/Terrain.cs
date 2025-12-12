using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Interfaces;

namespace VGP133_Final_Assignment.Game
{
    public abstract class Terrain : IDrawable
    {
        protected Terrain( Vector2 location, List<Monster>? monsterPool)
        {
            _location = location;
            _monsterPool = monsterPool;
        }

        public abstract void Render();

        public abstract void Update();

        private string name = "";
        private Vector2 location;
        protected Sprite? _sprite;
        protected List<Monster> _monsterPool;

        protected string Name { get => name; set => name = value; }
        protected Vector2 Location { get => location; set => location = value; }
    }
}
