using System.Numerics;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game
{
    public class Ocean : Terrain
    {
        public Ocean(Vector2 location, List<Monster>? monsterPool) :
            base(location, monsterPool)
        {
            _name = "Ocean";
            _location = location;
            _sprite = new Sprite("terrain_ocean", _location);
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
