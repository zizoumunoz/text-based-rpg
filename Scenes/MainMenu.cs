using VGP133_Final_Assignment.Core;
using Raylib_cs;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Scenes
{
    public class MainMenu : Scene
    {
        public MainMenu(SceneHandler sceneHandler) : base(sceneHandler)
        {
            _newGame =
                new ButtonRectangle(73, 17, 67, 64, "main_menu_options", true);
            _loadGame =
                new ButtonRectangle(73, 17, 67, 84, "", true);
            _settings =
                new ButtonRectangle(73, 17, 67, 104, "", true);
            _exit =
                new ButtonRectangle(73, 17, 67, 124, "", true);

            _background = new Sprite("book_empty", s_origin);

            
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.White);
            _background.Render();
            Raylib.DrawText("Main Menu Scene", 200, 200, 20, Color.Black);
            _newGame.Render();
            _loadGame.Render();
            _settings.Render();
            _exit.Render();
        }

        public override void Update()
        {
            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();
            switch (key)
            {
                case KeyboardKey.One:
                    Handler.CurrentScene = new CharacterCreation(Handler);
                    break;
                case KeyboardKey.Two:
                    Handler.CurrentScene = new WorldMap(Handler);
                    break;
                default:
                    break;
            }

            _newGame.Update();
            _loadGame.Update();
            _settings.Update();
            _exit.Update();

            if (_newGame.IsPressed)
            {
                Console.WriteLine("Pressed new game");
                Handler.CurrentScene = new CharacterCreation(Handler);
                _newGame.IsPressed = false;
            }
            else if (_loadGame.IsPressed)
            {
                Console.WriteLine("Pressed load game");
                
                _loadGame.IsPressed = false;
            }
            else if (_settings.IsPressed)
            {
                Console.WriteLine("Pressed settings");
                _settings.IsPressed = false;
            }
            else if (_exit.IsPressed)
            {
                Console.WriteLine("Pressed exit");
                _exit.IsPressed = false;
            }

        }

        private ButtonRectangle _newGame;
        private ButtonRectangle _loadGame;
        private ButtonRectangle _settings;
        private ButtonRectangle _exit;

        private Sprite _background;

    }
}
