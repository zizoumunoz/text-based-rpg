using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Core;
using VGP133_Final_Assignment.Game;

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
            UpdateButtonGroup(_hairButtonA, _hairButtonB, _hairButtonC);

            if (_hairButtonA.IsPressed)
            {
                _currentHairColor = HairColor.Pink;
            }
            else if (_hairButtonB.IsPressed)
            {
                _currentHairColor = HairColor.Yellow;
            }
            else if (_hairButtonC.IsPressed)
            {
                _currentHairColor = HairColor.Blue;
            }

            ResetButtonGroup(_hairButtonA, _hairButtonB, _hairButtonC);

            UpdateButtonGroup(_genderButtonA, _genderButtonB, _genderButtonC);

            if (_genderButtonA.IsPressed)
            {
                _currentGender = Gender.Masc;
            }
            else if (_genderButtonB.IsPressed)
            {
                _currentGender = Gender.Other;
            }
            else if (_genderButtonC.IsPressed)
            {
                _currentGender = Gender.Fem;
            }

            ResetButtonGroup(_genderButtonA, _genderButtonB, _genderButtonC);

            UpdateButtonGroup(_ageButtonA, _ageButtonB, _ageButtonC);
            if (_ageButtonA.IsPressed)
            {
                _currentAge = Age.Young;
            }
            else if (_ageButtonB.IsPressed)
            {
                _currentAge = Age.Adult;
            }
            else if (_ageButtonC.IsPressed)
            {
                _currentAge = Age.Old;
            }

            ResetButtonGroup(_ageButtonA, _ageButtonB, _ageButtonC);
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.RayWhite);

            _background.Render();

            _nameBox.Render();
            RenderButtonGroup(_hairButtonA, _hairButtonB, _hairButtonC);
            RenderButtonGroup(_genderButtonA, _genderButtonB, _genderButtonC);
            RenderButtonGroup(_ageButtonA, _ageButtonB, _ageButtonC);

            Raylib.DrawText("Character Creation Scene", 0, 0, 20, Color.Black);
            Raylib.DrawText($"Current hair: {(int)_currentHairColor}", 0, 20, 20, Color.Black);
            Raylib.DrawText($"Current gender: {(int)_currentGender}", 0, 40, 20, Color.Black);
            Raylib.DrawText($"Current age: {(int)_currentAge}", 0, 60, 20, Color.Black);

            _player.Render();
        }

        private void RenderButtonGroup(ButtonCircle buttonA, ButtonCircle buttonB, ButtonCircle buttonC)
        {
            buttonA.Render();
            buttonB.Render();
            buttonC.Render();
        }

        private void UpdateButtonGroup(ButtonCircle buttonA, ButtonCircle buttonB, ButtonCircle buttonC)
        {
            buttonA.Update();
            buttonB.Update();
            buttonC.Update();
        }

        private void ResetButtonGroup(ButtonCircle buttonA, ButtonCircle buttonB, ButtonCircle buttonC)
        {
            buttonA.IsPressed = false;
            buttonB.IsPressed = false;
            buttonC.IsPressed = false;
        }



        private HairColor _currentHairColor;
        private Age _currentAge;
        private Gender _currentGender;

        private Character _player = new Character(HairColor.Blue, Gender.Other, Age.Young, Class.Jester);

        private TextInput _nameBox = new TextInput(540, 51, 248, 112);

        private ButtonCircle _hairButtonA = new ButtonCircle(61, 370, 350);
        private ButtonCircle _hairButtonB = new ButtonCircle(61, 520, 340);
        private ButtonCircle _hairButtonC = new ButtonCircle(61, 670, 350);

        private ButtonCircle _genderButtonA = new ButtonCircle(61, 370, 550);
        private ButtonCircle _genderButtonB = new ButtonCircle(61, 520, 540);
        private ButtonCircle _genderButtonC = new ButtonCircle(61, 670, 550);

        private ButtonCircle _ageButtonA = new ButtonCircle(61, 370, 750);
        private ButtonCircle _ageButtonB = new ButtonCircle(61, 520, 740);
        private ButtonCircle _ageButtonC = new ButtonCircle(61, 670, 750);




    }
}
