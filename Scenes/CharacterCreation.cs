using System.Numerics;
using System.Text.Json;
using System.IO;
using Raylib_cs;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Core;
using VGP133_Final_Assignment.Game;
using static VGP133_Final_Assignment.Core.ResolutionManager;

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
                new Sprite("book", s_origin);

            _classSelectLeft =
                new ButtonRectangle(18, 22, 226, 12, "selected_left_heart");
            _classSelectRight =
                new ButtonRectangle(18, 22, 323, 12, "selected_right_heart");

            _forwardArrow =
                new ButtonRectangle(16, 17, 339, 165, "selected_forward");
            _backArrow =
                new ButtonRectangle(16, 17, 32, 161, "selected_back");

            _player = new Character(new Vector2(256, 79));
        }

        public override void Update()
        {
            _nameBox.Update();
            _player.Name = _nameBox.TextData;
            // ===== HAIR SELECTION =====
            UpdateButtonGroup(_hairButtonA, _hairButtonB, _hairButtonC);
            if (_hairButtonA.IsPressed)
            {
                _currentHairColor = HairColor.Yellow;
                _player.HairColor = _currentHairColor;
                _player.UpdateSprite();
            }
            else if (_hairButtonB.IsPressed)
            {
                _currentHairColor = HairColor.Pink;
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

            _backArrow.Update();
            _forwardArrow.Update();
            CheckForwardArrow();
            CheckBackArrow();
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

            RenderCurrentClass();
            RenderStats();
            _backArrow.Render();
            _forwardArrow.Render();
            _player.Render();

        }

        private void RenderStats()
        {
            Raylib.DrawText($"{_player.CurrentHp}", 202 * UIScale, 75 * UIScale, 9 * UIScale, _textColor);
            Raylib.DrawText($"{_player.Atk}", 202 * UIScale, 98 * UIScale, 9 * UIScale, _textColor);
            Raylib.DrawText($"{_player.Def}", 202 * UIScale, 124 * UIScale, 9 * UIScale, _textColor);
        }

        /// <summary>
        /// Update the selection circle indicating which option is active
        /// </summary>
        private void UpdateSelects()
        {
            switch (_currentHairColor)
            {
                case HairColor.Yellow:
                    _uiHairSelect.Position = _hairA;
                    break;
                case HairColor.Pink:
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

            Raylib.DrawText(classString, 249 * UIScale, 13 * UIScale, 20 * UIScale, new Color(178, 139, 120));
        }

        private void CheckForwardArrow()
        {
            if (_forwardArrow.IsPressed)
            {
                // save character logic
                Console.WriteLine("Serialzing player");
                Console.WriteLine($"Class {_player.PlayerClass}");
                Console.WriteLine($"Gender {_player.Gender}");
                Console.WriteLine($"Age {_player.Age}");
                Console.WriteLine($"HairColor {_player.HairColor}");
                string json = JsonSerializer.Serialize(_player, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("player.json", json);
                _forwardArrow.IsPressed = false;
                Handler.CurrentScene = new WorldMap(Handler);
            }
        }

        private void CheckBackArrow()
        {
            if (_backArrow.IsPressed)
            {
                Handler.CurrentScene = new MainMenu(Handler);
            }
        }

        private static Color _textColor = new Color(178, 139, 120);

        private HairColor _currentHairColor = HairColor.Yellow;
        private Age _currentAge = Age.Young;
        private Gender _currentGender = Gender.Masc;
        private Class _currentClass = Class.Knight;

        private Character _player;

        // Sprites
        private Sprite _background;
        private Sprite _uiHairSelect =
            new Sprite("selected_circle", s_origin);
        private Sprite _uiGenderSelect =
            new Sprite("selected_circle", s_origin);
        private Sprite _uiAgeSelect =
            new Sprite("selected_circle", s_origin);

        private TextInput _nameBox = new TextInput(540, 51, 248, 112);

        private ButtonCircle _hairButtonA = new ButtonCircle(61, 74, 70);
        private ButtonCircle _hairButtonB = new ButtonCircle(61, 104, 68);
        private ButtonCircle _hairButtonC = new ButtonCircle(61, 134, 70);

        private ButtonCircle _genderButtonA = new ButtonCircle(61, 74, 110);
        private ButtonCircle _genderButtonB = new ButtonCircle(61, 104, 108);
        private ButtonCircle _genderButtonC = new ButtonCircle(61, 134, 110);

        private ButtonCircle _ageButtonA = new ButtonCircle(61, 74, 150);
        private ButtonCircle _ageButtonB = new ButtonCircle(61, 104, 148);
        private ButtonCircle _ageButtonC = new ButtonCircle(61, 134, 150);

        // Locations for selections
        private Vector2 _hairA = new Vector2(61, 57);
        private Vector2 _hairB = new Vector2(91, 55);
        private Vector2 _hairC = new Vector2(121, 57);

        private Vector2 _genderA = new Vector2(61, 97);
        private Vector2 _genderB = new Vector2(91, 95);
        private Vector2 _genderC = new Vector2(121, 97);

        private Vector2 _ageA = new Vector2(61, 137);
        private Vector2 _ageB = new Vector2(91, 135);
        private Vector2 _ageC = new Vector2(121, 137);

        // Hitboxes
        private ButtonRectangle _classSelectLeft;
        private ButtonRectangle _classSelectRight;

        private ButtonRectangle _forwardArrow;
        private ButtonRectangle _backArrow;
    }
}
