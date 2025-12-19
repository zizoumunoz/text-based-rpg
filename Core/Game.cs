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
            AssetManager.LoadAssets("Assets/character_creation");
            AssetManager.LoadAssets("Assets/world_map");
            _sceneHandler.CurrentScene = new MainMenu(_sceneHandler);
        }

        public void Run()
        {

            while (!Raylib.WindowShouldClose())
            {
                _sceneHandler.CurrentScene?.Update();
                Raylib.BeginDrawing();

                _sceneHandler.CurrentScene?.Render();
                Raylib.EndDrawing();
            }

            AssetManager.UnloadAssets();
        }

        private SceneHandler _sceneHandler = new SceneHandler();
    }
}
