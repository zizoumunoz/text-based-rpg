using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using VGP133_Final_Assignment.Core;

namespace VGP133_Final_Assignment.Scenes
{
    public class CharacterCreation : Scene
    {
        public CharacterCreation(SceneHandler sceneHandler) : base(sceneHandler)
        {
            SceneName = "Character Creation";
        }
        public override void Update()
        {
            
        }
        public override void Render()
        {
            Raylib.ClearBackground(Color.RayWhite);
            Raylib.DrawText("Character Creation Scene", 200, 200, 20, Color.DarkGray);
        }

    }
}
