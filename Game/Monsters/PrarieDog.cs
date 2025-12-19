using System.Numerics;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game.Monsters
{
    public class PrarieDog : Monster
    {
        public PrarieDog(Variant variant) : base(variant)
        {
            _name = "Prairie Dog";
            _atk = 1;
            _def = 0;
            _hp = 1;
            _goldDropped = 1;
            _xpDropped = 1;
            _specialAtkChance = 10f;
            _spriteOffset = new Vector2(91, 115);

            ApplyVariant();
        }

        public override void Render()
        {
            _sprite.Render();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        private void ApplyVariant()
        {
            switch (_variant)
            {
                case Variant.Forest:
                    _sprite = new Sprite("enemy_dog", _spriteOffset);
                    break;
                case Variant.Mountain:
                    _sprite = new Sprite("enemy_dog_mountain", _spriteOffset);
                    _name = "Mountain Dog";
                    _atk *= 2;
                    _def *= 2;
                    _hp *= 1.5f;
                    _goldDropped *= 2;
                    _xpDropped *= 1.5f;
                    break;
                case Variant.Boss:
                    _atk *= 2.5f;
                    _def *= 2.5f;
                    _hp *= 1.5f;
                    _goldDropped *= 2;
                    _xpDropped *= 1.5f;
                    break;
                default:
                    Console.WriteLine("Could not apply variant for prarie dog");
                    break;
            }
        }
    }
}
