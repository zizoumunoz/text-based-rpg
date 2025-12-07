using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
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
            _background =
                new Sprite("book", new System.Numerics.Vector2(0f, 0f), 5f);

            _classSelectLeft =
                new ButtonRectangle(18 * _uiScale, 22 * _uiScale, 226 * _uiScale, 12 * _uiScale, "selected_left_heart");
            _classSelectRight =
                new ButtonRectangle(18 * _uiScale, 22 * _uiScale, 323 * _uiScale, 12 * _uiScale, "selected_right_heart");

            _player = new Character(new Vector2(256, 79));
        }

        public override void Update()
        {
            _nameBox.Update();

            // ===== HAIR SELECTION =====
            UpdateButtonGroup(_hairButtonA, _hairButtonB, _hairButtonC);
            if (_hairButtonA.IsPressed)
            {
                _currentHairColor = HairColor.Pink;
                _player.HairColor = _currentHairColor;
                _player.UpdateSprite();
            }
            else if (_hairButtonB.IsPressed)
            {
                _currentHairColor = HairColor.Yellow;
                _player.HairColor = _currentHairColor;
                _player.UpdateSprite();
            }
            else if (_hairButtonC.IsPressed)
            {
                _currentHairColor = HairColor.Blue;
                _player.HairColor = _currentHairColor;
                _player.UpdateSprite();
            }

            ResetButtonGroup(_hairButtonA, _hairButtonB, _hairButtonC);

            // ===== GENDER SELECTION ======
            UpdateButtonGroup(_genderButtonA, _genderButtonB, _genderButtonC);
            if (_genderButtonA.IsPressed)
            {
                _currentGender = Gender.Masc;
                _player.Gender = _currentGender;
                _player.UpdateSprite();
            }
            else if (_genderButtonB.IsPressed)
            {
                _currentGender = Gender.Other;
                _player.Gender = _currentGender;
                _player.UpdateSprite();
            }
            else if (_genderButtonC.IsPressed)
            {
                _currentGender = Gender.Fem;
                _player.Gender = _currentGender;
                _player.UpdateSprite();
            }

            ResetButtonGroup(_genderButtonA, _genderButtonB, _genderButtonC);

            // ===== AGE SELECTION ======
            UpdateButtonGroup(_ageButtonA, _ageButtonB, _ageButtonC);
            if (_ageButtonA.IsPressed)
            {
                _currentAge = Age.Young;
                _player.Age = _currentAge;
                _player.UpdateSprite();
            }
            else if (_ageButtonB.IsPressed)
            {
                _currentAge = Age.Adult;
                _player.Age = _currentAge;
                _player.UpdateSprite();
            }
            else if (_ageButtonC.IsPressed)
            {
                _currentAge = Age.Old;
                _player.Age = _currentAge;
                _player.UpdateSprite();
            }

            ResetButtonGroup(_ageButtonA, _ageButtonB, _ageButtonC);

            UpdateCurrentClass();

            UpdateSelects();
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.RayWhite);

            _background.Render();

            _nameBox.Render();
            RenderButtonGroup(_hairButtonA, _hairButtonB, _hairButtonC);
            RenderButtonGroup(_genderButtonA, _genderButtonB, _genderButtonC);
            RenderButtonGroup(_ageButtonA, _ageButtonB, _ageButtonC);

            _uiHairSelect.Render();
            _uiGenderSelect.Render();
            _uiAgeSelect.Render();

            _classSelectLeft.Render();
            _classSelectRight.Render();


            Raylib.DrawText("Character Creation Scene", 0, 0, 20, Color.Black);
            Raylib.DrawText($"Current hair: {(int)_currentHairColor}", 0, 20, 20, Color.Black);
            Raylib.DrawText($"Current gender: {(int)_currentGender}", 0, 40, 20, Color.Black);
            Raylib.DrawText($"Current age: {(int)_currentAge}", 0, 60, 20, Color.Black);

            RenderCurrentClass();
            RenderStats();
            _player.Render();

        }

        private void RenderStats()
        {
            Raylib.DrawText($"{_player.CurrentHp}", 202 * _uiScale, 75 * _uiScale, 9 * _uiScale, _textColor);
            Raylib.DrawText($"{_player.Atk}", 202 * _uiScale, 98 * _uiScale, 9 * _uiScale, _textColor);
            Raylib.DrawText($"{_player.Def}", 202 * _uiScale, 124 * _uiScale, 9 * _uiScale, _textColor);
        }

        /// <summary>
        /// Update the selection circle indicating which option is active
        /// </summary>
        private void UpdateSelects()
        {
            switch (_currentHairColor)
            {
                case HairColor.Pink:
                    _uiHairSelect.Position = _hairA;
                    break;
                case HairColor.Yellow:
                    _uiHairSelect.Position = _hairB;
                    break;
                case HairColor.Blue:
                    _uiHairSelect.Position = _hairC;
                    break;
                default:
                    break;
            }

            switch (_currentGender)
            {
                case Gender.Masc:
                    _uiGenderSelect.Position = _genderA;
                    break;
                case Gender.Other:
                    _uiGenderSelect.Position = _genderB;
                    break;
                case Gender.Fem:
                    _uiGenderSelect.Position = _genderC;
                    break;
                default:
                    break;
            }

            switch (_currentAge)
            {
                case Age.Young:
                    _uiAgeSelect.Position = _ageA;
                    break;
                case Age.Adult:
                    _uiAgeSelect.Position = _ageB;
                    break;
                case Age.Old:
                    _uiAgeSelect.Position = _ageC;
                    break;
                default:
                    break;
            }
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

        private void UpdateCurrentClass()
        {
            _classSelectLeft.Update();
            _classSelectRight.Update();

            if (_classSelectLeft.IsPressed)
            {
                switch (_player.PlayerClass)
                {
                    case Class.Knight:
                        _player.PlayerClass = Class.Wizard;
                        break;
                    case Class.Jester:
                        _player.PlayerClass = Class.Knight;
                        break;
                    case Class.Wizard:
                        _player.PlayerClass = Class.Jester;
                        break;
                    default:
                        break;
                }
                _classSelectLeft.IsPressed = false;
                Console.WriteLine($"Current class: {_player.PlayerClass}");
                _player.UpdateSprite();
                _player.UpdateStats();
            }
            else if (_classSelectRight.IsPressed)
            {
                switch (_player.PlayerClass)
                {
                    case Class.Knight:
                        _player.PlayerClass = Class.Jester;
                        break;
                    case Class.Jester:
                        _player.PlayerClass = Class.Wizard;
                        break;
                    case Class.Wizard:
                        _player.PlayerClass = Class.Knight;
                        break;
                    default:
                        break;
                }
                _classSelectRight.IsPressed = false;
                _player.UpdateSprite();
                _player.UpdateStats();
            }
        }

        private void RenderCurrentClass()
        {
            string classString = "";

            switch (_player.PlayerClass)
            {
                case Class.Knight:
                    classString = "Knight";
                    break;
                case Class.Jester:
                    classString = "Jester";
                    break;
                case Class.Wizard:
                    switch (_player.Gender)
                    {
                        case Gender.Masc:
                            classString = "Wizard";
                            break;
                        case Gender.Other:
                            classString = "Whiz";
                            break;
                        case Gender.Fem:
                            classString = "Witch";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    classString = "Unknown";
                    break;

            }

            Raylib.DrawText(classString, 249 * _uiScale, 13 * _uiScale, 20 * _uiScale, new Color(178, 139, 120));
        }

        private static Color _textColor = new Color(178, 139, 120);

        private HairColor _currentHairColor = HairColor.Pink;
        private Age _currentAge = Age.Young;
        private Gender _currentGender = Gender.Masc;
        private Class _currentClass = Class.Knight;

        private const int _uiScale = 5;

        private Character _player;

        // Sprites
        private Sprite _background;
        private Sprite _uiHairSelect =
            new Sprite("selected_circle", new Vector2(0 * _uiScale, 0 * _uiScale), _uiScale);
        private Sprite _uiGenderSelect =
            new Sprite("selected_circle", new Vector2(0 * _uiScale, 0 * _uiScale), _uiScale);
        private Sprite _uiAgeSelect =
            new Sprite("selected_circle", new Vector2(0 * _uiScale, 0 * _uiScale), _uiScale);

        private TextInput _nameBox = new TextInput(540, 51, 248, 112);

        private ButtonCircle _hairButtonA = new ButtonCircle(61, 74 * _uiScale, 70 * _uiScale);
        private ButtonCircle _hairButtonB = new ButtonCircle(61, 104 * _uiScale, 68 * _uiScale);
        private ButtonCircle _hairButtonC = new ButtonCircle(61, 134 * _uiScale, 70 * _uiScale);

        private ButtonCircle _genderButtonA = new ButtonCircle(61, 74 * _uiScale, 550);
        private ButtonCircle _genderButtonB = new ButtonCircle(61, 104 * _uiScale, 540);
        private ButtonCircle _genderButtonC = new ButtonCircle(61, 134 * _uiScale, 550);

        private ButtonCircle _ageButtonA = new ButtonCircle(61, 74 * _uiScale, 750);
        private ButtonCircle _ageButtonB = new ButtonCircle(61, 104 * _uiScale, 740);
        private ButtonCircle _ageButtonC = new ButtonCircle(61, 134 * _uiScale, 750);

        // Locations for selections
        private Vector2 _hairA = new Vector2(61 * _uiScale, 57 * _uiScale);
        private Vector2 _hairB = new Vector2(91 * _uiScale, 55 * _uiScale);
        private Vector2 _hairC = new Vector2(121 * _uiScale, 57 * _uiScale);

        private Vector2 _genderA = new Vector2(61 * _uiScale, 97 * _uiScale);
        private Vector2 _genderB = new Vector2(91 * _uiScale, 95 * _uiScale);
        private Vector2 _genderC = new Vector2(121 * _uiScale, 97 * _uiScale);

        private Vector2 _ageA = new Vector2(61 * _uiScale, 137 * _uiScale);
        private Vector2 _ageB = new Vector2(91 * _uiScale, 135 * _uiScale);
        private Vector2 _ageC = new Vector2(121 * _uiScale, 137 * _uiScale);

        // Hitboxes
        private ButtonRectangle _classSelectLeft;
        private ButtonRectangle _classSelectRight;
    }
}
