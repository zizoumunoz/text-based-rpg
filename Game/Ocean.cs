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
            _actionBottomLeft.Update();
            _actionBottomRight.Update();
            _actionTopLeft.Update();
            _actionTopRight.Update();
        }
        public override void Render()
        {
            _sprite.Render();
        }

        public override void RenderActionText()
        {
        }
    }
}
