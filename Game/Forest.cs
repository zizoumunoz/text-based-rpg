using System.Numerics;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game
{
    public class Forest : Terrain
    {
        public Forest(Vector2 location, List<Monster>? monsterPool) :
            base(location, monsterPool)
        {
            _name = "Forest";
            _location = location;
            _sprite = new Sprite("terrain_forest", _location);
            _rewardChance = 0.5f;
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
