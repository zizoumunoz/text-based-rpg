using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Raylib_cs;
// Custom
using VGP133_Final_Assignment.Scenes;


namespace VGP133_Final_Assignment.Core
{
    public class Game
    {
        public Game()
        {
            _currentScene = new CharacterCreation();
        }

        public void Run()
        {
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                _currentScene?.Render();

                Raylib.EndDrawing();
            }
        }

        private Scene? _currentScene;
    }
}
