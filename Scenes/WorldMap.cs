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
            _currentTile =
                _map.MapTiles[(int)_map.PlayerTileLocation.Y, (int)_map.PlayerTileLocation.X];
            _terrainBackground =
                new Text(_currentTile.Name, new Vector2(52, 42), 20, Color.Red);

            _viewportInventory =
                new Viewport(new Vector2(49, 40), new Vector2(110, 110), true);
        }

        public override void Update()
        {
            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();
            switch (key)
            {
                case KeyboardKey.Up:
                    _map.MovePlayer('N');
                    UpdateCurrentTile();
                    break;
                case KeyboardKey.Down:
                    _map.MovePlayer('S');
                    UpdateCurrentTile();
                    break;
                case KeyboardKey.Left:
                    _map.MovePlayer('W');
                    UpdateCurrentTile();
                    break;
                case KeyboardKey.Right:
                    _map.MovePlayer('E');
                    UpdateCurrentTile();
                    break;
                default:
                    break;
            }

            _currentTile.Update();

            // UpdateTileButtons();

            _viewportInventory.Update();
            if (_currentTile.ActionBottomLeft.IsPressed)
            {
                _viewportInventory.IsActive = true;
            }

            _currentTile.ActionBottomLeft.IsPressed = false;
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

            RenderTerrainBackground();

            RenderTileButtons();

            _viewportInventory.Render();
            _player.Render();

        }

        void RenderTileButtons()
        {
            _currentTile.ActionTopLeft.Render();
            _currentTile.ActionTopRight.Render();
            _currentTile.ActionBottomLeft.Render();
            _currentTile.ActionBottomRight.Render();

            _currentTile.RenderActionText();
        }

        private void UpdateTileButtons()
        {
            _currentTile.ActionTopLeft.Update();
            _currentTile.ActionTopRight.Update();
            _currentTile.ActionBottomLeft.Update();
            _currentTile.ActionBottomRight.Update();
        }

        private void UpdateCurrentTile()
        {
            _currentTile = _map.MapTiles[(int)_map.PlayerTileLocation.Y, (int)_map.PlayerTileLocation.X];
        }

        private void RenderTerrainBackground()
        {

            switch (_currentTile.Name)
            {
                case "Ocean":
                    _terrainBackground.TextData = _currentTile.Name;
                    _terrainBackground.Render();
                    break;
                case "Village":
                    _terrainBackground.TextData = _currentTile.Name;
                    _terrainBackground.Render();
                    break;
                case "Forest":
                    _terrainBackground.TextData = _currentTile.Name;
                    _terrainBackground.Render();
                    break;
                case "Mountain":
                    _terrainBackground.TextData = _currentTile.Name;
                    _terrainBackground.Render();
                    break;
                case "Castle":
                    _terrainBackground.TextData = _currentTile.Name;
                    _terrainBackground.Render();
                    break;
                default:
                    break;
            }
        }

        private Character? _player;
        private Map _map = new Map();

        // Viewports
        Viewport _viewportInventory;

        // Sprites
        Sprite _background =
            new Sprite("world_background", s_origin);
        Sprite _borders =
            new Sprite("world_borders", s_origin);
        Sprite _buttons =
            new Sprite("world_buttons", s_origin);
        Sprite _statusWindows =
            new Sprite("world_status_window", s_origin);
        Text _terrainBackground;
        Terrain _currentTile;

    }
}
