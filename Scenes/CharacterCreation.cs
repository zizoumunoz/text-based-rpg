using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Core;

namespace VGP133_Final_Assignment.Scenes
{
    public class CharacterCreation : Scene
    {
        /// <summary>
        /// Initialize CharacterCreation Scene instance.
        /// </summary>
        /// <param name="sceneHandler">Main scene handler</param>
        public CharacterCreation(SceneHandler sceneHandler) : base(sceneHandler)
        {
            SceneName = "Character Creation";
        }

        public override void Update()
        {
            _nameBox.Update();
            _hairButtonA.Update();


            // reset buttons
            _hairButtonA.IsPressed = false;
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.RayWhite);

            _background.Render();

            Raylib.DrawText("Character Creation Scene", 0, 0, 20, Color.Black);

            _nameBox.Render();
            _hairButtonA.Render();
        }

        private TextInput _nameBox = new TextInput(540, 51, 248, 112);
        private ButtonCircle _hairButtonA = new ButtonCircle(61, 370, 350);

    }
}
