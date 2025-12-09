using VGP133_Final_Assignment.Interfaces;

namespace VGP133_Final_Assignment.Game
{
    public abstract class Monster : IDrawable
    {
        public void Render()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void BasicAttack()
        {

        }

        public void SpecialAttack()
        {

        }

        // Monster Attributes
        private string _name = "";
        private int _atk;
        private int _def;
        private int _hp;
        private int _goldDropped;
        private int _xpDropped;

        private float _specialAtkChance;
    }
}
