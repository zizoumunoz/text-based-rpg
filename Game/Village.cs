using Raylib_cs;
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

            Vector2 offset = new Vector2(5, 2);

            _actionsText[0] =
                new Text("Item Shop", _actionTopLeft.PositionRaw + offset, 20, Color.White);
            _actionsText[1] =
                new Text("Weapon Shop", _actionTopRight.PositionRaw + offset, 20, Color.White);
            _actionsText[2] =
                new Text("Inn", _actionBottomLeft.PositionRaw + offset, 20, Color.White);
            _actionsText[3] =
                new Text("Barber Shop", _actionBottomRight.PositionRaw + offset, 20, Color.White);
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
            for (int i = 0; i < _actionsText.Length; i++)
            {
                _actionsText[i].Render();
            }
        }
    }
}
