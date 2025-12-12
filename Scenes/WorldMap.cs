using System.Numerics;
using Raylib_cs;
using VGP133_Final_Assignment.Core;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Game;
using System.Text.Json;
using static VGP133_Final_Assignment.Core.ResolutionManager; // for UIScale


namespace VGP133_Final_Assignment.Scenes
{
    public class WorldMap : Scene
    {
        public WorldMap(SceneHandler sceneHandler) : base(sceneHandler)
        {
            _borders.Offset = new Vector2(24, 16);
            _buttons.Offset = new Vector2(6, 145);
            _statusWindows.Offset = new Vector2(32, 137);

            // get player from file
            string loadedJson = File.ReadAllText("player.json");
            _player = JsonSerializer.Deserialize<Character>(loadedJson);

            _player.SpriteLocation = new Vector2(164, 146);
            _player.HasOutline = true;
            _player.UpdateSprite();
        }

        public override void Update()
        {
            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();
            switch (key)
            {
                case KeyboardKey.Up:
                    _map.MovePlayer('N');
                    break;
                case KeyboardKey.Down:
                    _map.MovePlayer('S');
                    break;
                case KeyboardKey.Left:
                    _map.MovePlayer('W');
                    break;
                case KeyboardKey.Right:
                    _map.MovePlayer('E');
                    break;
                default:
                    break;
            }
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.Black);


            _map.Render();
            _background.Render();
            _borders.Render();
            _buttons.Render();
            _statusWindows.Render();

            Raylib.DrawText("WorldMap Scene", 0, 0, 20, Color.RayWhite);
            Raylib.DrawText($"{_player.CurrentHp}", 45 * UIScale, 192 * UIScale, 10 * UIScale, new Color(178, 139, 120));
            Raylib.DrawText($"{_player.Atk}", 87 * UIScale, 192 * UIScale, 10 * UIScale, new Color(178, 139, 120));
            Raylib.DrawText($"{_player.Def}", 128 * UIScale, 192 * UIScale, 10 * UIScale, new Color(178, 139, 120));

            _player.Render();


        }
        private void DisplayCurrentLocation()
        {

        }

        private Character? _player;
        private Map _map = new Map();

        // Sprites
        Sprite _background =
            new Sprite("world_background", s_origin);
        Sprite _borders =
            new Sprite("world_borders", s_origin);
        Sprite _buttons =
            new Sprite("world_buttons", s_origin);
        Sprite _statusWindows =
            new Sprite("world_status_window", s_origin);
    }
}
