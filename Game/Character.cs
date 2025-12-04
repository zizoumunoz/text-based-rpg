using System;
using System.Collections.Generic;
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
        }


        private Sprite _playerBody;
        private Sprite _playerHair;
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
