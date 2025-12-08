using System;
using System.Collections.Generic;
using System.Text;
using VGP133_Final_Assignment.Core;
using Raylib_cs;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Scenes
{
    public class MainMenu : Scene
    {
        public MainMenu(SceneHandler sceneHandler) : base(sceneHandler)
        {

        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.White);
            Raylib.DrawText("Main Menu Scene", 200, 200, 20, Color.Black);
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
        }
    }
}
