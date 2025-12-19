using System.Numerics;
using Raylib_cs;
using VGP133_Final_Assignment.Core;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Game;
using System.Text.Json;
using static VGP133_Final_Assignment.Core.ResolutionManager;
using VGP133_Final_Assignment.Game.Monsters; // for UIScale


namespace VGP133_Final_Assignment.Scenes
{
    public class WorldMap : Scene
    {
        public WorldMap(SceneHandler sceneHandler) : base(sceneHandler)
        {
            _castleBackground =
                new Sprite("terrain_background_castle", s_origin);
            _castleBackground.Offset = new Vector2(23, 16);

            _mountainBackground =
                new Sprite("terrain_background_mountains", s_origin);
            _mountainBackground.Offset = new Vector2(23, 16);

            _villageBackground =
                new Sprite("terrain_background_village", s_origin);
            _villageBackground.Offset = new Vector2(23, 16);

            _forestBackground =
                new Sprite("terrain_background_forest", s_origin);
            _forestBackground.Offset = new Vector2(23, 16);

            _terrainBackground = _villageBackground;
            _terrainBackground.Offset = new Vector2(23, 16);

            _borders.Offset = new Vector2(24, 16);
            _buttons.Offset = new Vector2(6, 145);
            _statusWindows.Offset = new Vector2(32, 137);

            _itemShopInventory = new Inventory();
            _weaponShopInventory = new Inventory();

            _itemShopInventory.Items.Add(new Item("Health Potion", "Consumable", 1, 10));
            _itemShopInventory.Items.Add(new Item("Attack Potion", "Consumable", 1, 2));
            _itemShopInventory.Items.Add(new Item("Defense Potion", "Consumable", 1, 2));

            _weaponShopInventory.Items.Add(new Item("Sword", "Equipable", 1, 10));
            _weaponShopInventory.Items.Add(new Item("Shield", "Equipable", 1, 10));
            _weaponShopInventory.Items.Add(new Item("Armor", "Equipable", 1, 10));

            // get player from file
            string loadedJson = File.ReadAllText("player.json");
            _player = JsonSerializer.Deserialize<Character>(loadedJson);
            _player.SpriteLocation = new Vector2(164, 146);
            _player.HasOutline = true;
            _player.UpdateSprite();

            _player.CurrentHp--;

            // set map AFTER loading player
            _map = new Map(_player);

            _currentTile =
                _map.MapTiles[(int)_map.PlayerTileLocation.Y, (int)_map.PlayerTileLocation.X];

            _inventoryViewport =
                new Viewport(new Vector2(49, 40), new Vector2(110, 110), "Inventory", false);
            _itemsViewport =
                new Viewport(new Vector2(49, 40), new Vector2(110, 110), "Item Shop", false);
            _weaponViewport =
                new Viewport(new Vector2(49, 40), new Vector2(110, 110), "Weapon Shop", false);
            _currentViewport = _inventoryViewport;

            _statusText = new Text("", new Vector2(27, 166), 20, GameColors.DarkBrown);
        }

        public override void Update()
        {
            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();
            if (!_currentTile.HasMonster)
            {
                switch (key)
                {
                    case KeyboardKey.Up:
                        _map.MovePlayer('N');
                        _currentViewport.IsActive = false;
                        UpdateCurrentTile();
                        UpdateCurrentViewport();
                        break;
                    case KeyboardKey.Down:
                        _map.MovePlayer('S');
                        _currentViewport.IsActive = false;
                        UpdateCurrentTile();
                        UpdateCurrentViewport();
                        break;
                    case KeyboardKey.Left:
                        _map.MovePlayer('W');
                        _currentViewport.IsActive = false;
                        UpdateCurrentTile();
                        UpdateCurrentViewport();
                        break;
                    case KeyboardKey.Right:
                        _map.MovePlayer('E');
                        _currentViewport.IsActive = false;
                        UpdateCurrentTile();
                        UpdateCurrentViewport();
                        break;
                    default:
                        break;
                }
            }
            else if (key != KeyboardKey.Null)
            {
                Console.WriteLine("[DEBUG] Can't move, monster present. Try to flee.");
            }

            _currentTile.Update();

            _currentViewport.Update();
            UpdateTileButtons();

        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.Black);

            _map.Render();
            RenderTerrainBackground();
            _background.Render();
            _borders.Render();
            _buttons.Render();
            _statusWindows.Render();

            Raylib.DrawText("WorldMap Scene", 0, 0, 20, Color.RayWhite);
            Raylib.DrawText($"{_player.CurrentHp}", 45 * UIScale, 192 * UIScale, 10 * UIScale, new Color(178, 139, 120));
            Raylib.DrawText($"{_player.Atk}", 87 * UIScale, 192 * UIScale, 10 * UIScale, new Color(178, 139, 120));
            Raylib.DrawText($"{_player.Def}", 128 * UIScale, 192 * UIScale, 10 * UIScale, new Color(178, 139, 120));


            RenderTileButtons();

            _currentViewport.Render();
            _player.Render();
            _statusText.Render();

        }
        private void UpdateTileButtons()
        {
            switch (_currentTile.Name)
            {
                case "Forest":
                case "Castle":
                case "Mountain":
                    if (_currentTile.ActionBottomLeft.IsPressed)
                    {
                        _currentViewport = _inventoryViewport;
                        _currentViewport.IsActive = true;
                        _currentTile.ActionBottomLeft.IsPressed = false;
                    }
                    break;
                case "Village":
                    if (_currentTile.ActionTopLeft.IsPressed)
                    {
                        _currentViewport = _itemsViewport;
                        _currentViewport.IsActive = true;
                        _currentTile.ActionTopLeft.IsPressed = false;
                    }
                    else if (_currentTile.ActionTopRight.IsPressed)
                    {
                        _currentViewport = _weaponViewport;
                        _currentViewport.IsActive = true;
                        _currentTile.ActionTopRight.IsPressed = false;
                    }
                    else if (_currentTile.ActionBottomLeft.IsPressed)
                    {
                        _player.CurrentHp = _player.MaxHp;
                        _currentTile.ActionBottomLeft.IsPressed = false;
                    }
                    else if (_currentTile.ActionBottomRight.IsPressed)
                    {
                        Handler.CurrentScene = new CharacterCreation(Handler);
                        _currentTile.ActionBottomRight.IsPressed = false;
                    }
                    break;
                default:
                    _currentViewport = _itemsViewport;
                    break;
            }
        }

        private void RenderTileButtons()
        {
            _currentTile.ActionTopLeft.Render();
            _currentTile.ActionTopRight.Render();
            _currentTile.ActionBottomLeft.Render();
            _currentTile.ActionBottomRight.Render();

            _currentTile.RenderActionText();
        }

        private void UpdateCurrentViewport()
        {
            switch (_currentTile.Name)
            {
                case "Forest":
                case "Castle":
                case "Mountain":
                    _currentViewport = _inventoryViewport;
                    break;
                case "Village":
                    break;
                default:
                    _currentViewport = _itemsViewport;
                    break;
            }
        }

        private void UpdateCurrentTile()
        {
            _currentTile = _map.MapTiles[(int)_map.PlayerTileLocation.Y, (int)_map.PlayerTileLocation.X];
            Random rng = new Random();
            if (_currentTile.Name == "Forest")
            {
                if (rng.Next(100) < 50)
                {
                    // monster
                    _currentTile.HasMonster = true;

                    _currentMonster = GenerateMonster((MonsterType)rng.Next(5), Variant.Forest);

                    _statusText.TextData = $"A {_currentMonster.Name} has appeared!";

                }
                else
                {
                    _player.Gold += 10;
                    _statusText.TextData = $"{_player.Name} has received 10 gold!";
                }
            }
            else if (_currentTile.Name == "Mountain")
            {
                if (rng.Next(100) < 50)
                {
                    // monster
                    _currentTile.HasMonster = true;

                    _currentMonster = GenerateMonster((MonsterType)rng.Next(5), Variant.Mountain);

                    _statusText.TextData = $"A {_currentMonster.Name} has appeared!";

                }
                else
                {
                    _player.Gold += 20;
                    _statusText.TextData = $"{_player.Name} has received 10 gold!";
                }
            }
        }

        private Monster GenerateMonster(MonsterType monster, Variant variant)
        {
            switch (monster)
            {
                case MonsterType.PrairieDog:
                    return new PrarieDog(variant);
                case MonsterType.Slime:
                    return new Slime(variant);
                case MonsterType.Medusa:
                    return new Medusa(variant);
                case MonsterType.Crow:
                    return new Crow(variant);
                case MonsterType.Golem:
                    return new Golem(variant);
                default:
                    return new Golem(variant);
                    break;
            }
        }

        private void RenderTerrainBackground()
        {

            switch (_currentTile.Name)
            {
                case "Ocean":
                    _terrainBackground = _villageBackground;
                    _terrainBackground.Render();
                    break;
                case "Village":
                    _terrainBackground = _villageBackground;
                    _terrainBackground.Render();
                    break;
                case "Forest":
                    _terrainBackground = _forestBackground;
                    _terrainBackground.Render();
                    break;
                case "Mountain":
                    _terrainBackground = _mountainBackground;
                    _terrainBackground.Render();
                    break;
                case "Castle":
                    _terrainBackground = _castleBackground;
                    _terrainBackground.Render();
                    break;
                default:
                    break;
            }

            if (_currentTile.HasMonster)
            {
                _currentMonster.Render();
            }
        }

        private Character? _player;
        private Map _map;
        private Inventory _itemShopInventory;
        private Inventory _weaponShopInventory;

        // Monster pool
        private Monster _currentMonster;

        // Viewports
        Viewport _currentViewport;
        Viewport _weaponViewport;
        Viewport _itemsViewport;
        Viewport _inventoryViewport;

        // Text
        Text _statusText;

        // Sprites
        Sprite _background =
            new Sprite("world_background", s_origin);
        Sprite _borders =
            new Sprite("world_borders", s_origin);
        Sprite _buttons =
            new Sprite("world_buttons", s_origin);
        Sprite _statusWindows =
            new Sprite("world_status_window", s_origin);
        Sprite _terrainBackground;
        Sprite _villageBackground;
        Sprite _mountainBackground;
        Sprite _castleBackground;
        Sprite _forestBackground;

        Terrain _currentTile;
    }
}
