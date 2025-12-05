using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Text;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game
{
    public class Character
    {
        public Character(HairColor hairColor, Gender gender, Age age, Class playerClass)
        {
            _hairColor = hairColor;
            _gender = gender;
            _age = age;
            _playerClass = playerClass;

            string temp = "Assets/character_creation/character_body.png";
            _playerBody = new Sprite(temp, _spriteLocation, 5);

            // get hair sprite from color and gender
            switch (_hairColor)
            {
                case HairColor.Pink:
                    switch (_gender)
                    {
                        case Gender.Masc:
                            temp = "Assets/character_creation/hair_pink_boy.png";
                            _playerHair = new Sprite(temp, new Vector2(0, 0), 5);
                            break;
                        case Gender.Other:
                            temp = "Assets/character_creation/hair_pink_other.png";
                            _playerHair = new Sprite(temp, new Vector2(0, 0), 5);
                            break;
                        case Gender.Fem:
                            temp = "Assets/character_creation/hair_pink_girl.png";
                            _playerHair = new Sprite(temp, new Vector2(0, 0), 5);
                            break;
                        default:
                            Console.WriteLine("Sprite data not found");
                            break;
                    }
                    break;
                case HairColor.Yellow:
                    switch (_gender)
                    {
                        case Gender.Masc:
                            temp = "Assets/character_creation/hair_yellow_boy.png";
                            _playerHair = new Sprite(temp, new Vector2(0, 0), 5);
                            break;
                        case Gender.Other:
                            temp = "Assets/character_creation/hair_yellow_other.png";
                            _playerHair = new Sprite(temp, new Vector2(0, 0), 5);
                            break;
                        case Gender.Fem:
                            temp = "Assets/character_creation/hair_yellow_girl.png";
                            _playerHair = new Sprite(temp, new Vector2(0, 0), 5);
                            break;
                        default:
                            Console.WriteLine("Sprite data not found");
                            break;
                    }
                    break;
                case HairColor.Blue:
                    switch (_gender)
                    {
                        case Gender.Masc:
                            temp = "Assets/character_creation/hair_blue_boy.png";
                            _playerHair = new Sprite(temp, new Vector2(0, 0), 5);
                            break;
                        case Gender.Other:
                            temp = "Assets/character_creation/hair_blue_other.png";
                            _playerHair = new Sprite(temp, new Vector2(0, 0), 5);
                            break;
                        case Gender.Fem:
                            temp = "Assets/character_creation/hair_blue_girl.png";
                            _playerHair = new Sprite(temp, new Vector2(0, 0), 5);
                            break;
                        default:
                            Console.WriteLine("Sprite data not found");
                            break;
                    }
                    break;
                default:
                    break;
            }

            switch (_playerClass)
            {
                case Class.Knight:
                    temp = "Assets/character_creation/hat_knight.png";
                    _playerHat = new Sprite(temp, _spriteLocation, 5);
                    temp = "Assets/character_creation/clothes_knight.png";
                    _playerHat = new Sprite(temp, _spriteLocation, 5);
                    break;
                case Class.Jester:
                    temp = "Assets/character_creation/hat_jester.png";
                    _playerHat = new Sprite(temp, _spriteLocation, 5);
                    temp = "Assets/character_creation/clothes_default.png";
                    _playerHat = new Sprite(temp, _spriteLocation, 5);
                    break;
                case Class.Wizard:
                    temp = "Assets/character_creation/hat_wizard.png";
                    _playerHat = new Sprite(temp, _spriteLocation, 5);
                    temp = "Assets/character_creation/clothes_default.png";
                    _playerHat = new Sprite(temp, _spriteLocation, 5);
                    break;
                default:
                    break;
            }

            switch (_age)
            {
                case Age.Young:
                    temp = "Assets/character_creation/face_young.png";
                    _playerFace = new Sprite(temp, _spriteLocation, 5);
                    break;
                case Age.Adult:
                    temp = "Assets/character_creation/face_adult.png";
                    _playerFace = new Sprite(temp, _spriteLocation, 5);
                    break;
                case Age.Old:
                    temp = "Assets/character_creation/face_old.png";
                    _playerFace = new Sprite(temp, _spriteLocation, 5);
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {
            
        }

        public void Render()
        {
            _playerHair.Render();
        }

        private Vector2 _spriteLocation;

        private Sprite _playerBody;
        private Sprite _playerHair;
        private Sprite _playerCloak;
        private Sprite _playerHat;
        private Sprite _playerFace;

        private HairColor _hairColor;
        private Gender _gender;
        private Age _age;
        private Class _playerClass;


        public HairColor HairColor { get => _hairColor; set => _hairColor = value; }
        public Gender Gender { get => _gender; set => _gender = value; }
        public Age Age { get => _age; set => _age = value; }
        public Class PlayerClass { get => _playerClass; set => _playerClass = value; }
    }
}
