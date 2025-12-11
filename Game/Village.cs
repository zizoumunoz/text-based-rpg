using System.Numerics;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game
{
    public class Village : Terrain
    {
        public Village(Vector2 location, List<Monster>? monsterPool) : base(location, monsterPool)
        {
            _name = "Village";
            _location = location;
            _sprite = new Sprite("terrain_village", _location);
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
        public override void Render()
        {
            _sprite.Render();
        }
    }
}
