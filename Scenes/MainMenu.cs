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
                new ButtonRectangle(106, 17, 30, 62, "", true);
            _loadGame =
                new ButtonRectangle(106, 17, 30, 89, "", true);
            _settings =
                new ButtonRectangle(106, 17, 30, 118, "", true);
            _exit =
                new ButtonRectangle(106, 17, 30, 151, "", true);
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.White);
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

    }
}
