using Graphics;

namespace jeu
{
    internal class Stuff
    {
        private Weapon weapon;
        private Glove leftGlove;
        private Glove rightGlove;
        private Ring leftRing;
        private Ring rightRing;
        private Shield shield;
        private Belt belt;
        private Boots boots;

        public Stuff()
        {
            weapon = new Weapon("Poing", 1, 0, 0, Sprites._fist, "C'est juste votre poing.", 1);
            leftGlove = null;
            rightGlove = null;
            leftRing = null;
            rightRing = null;
            shield = null;
            belt = null;
            boots = null;
        }

        protected Weapon Weapon { get => weapon; set => weapon = value; }
        protected Glove LeftGlove { get => leftGlove; set => leftGlove = value; }
        protected Glove RightGlove { get => rightGlove; set => rightGlove = value; }
        protected Ring LeftRing { get => leftRing; set => leftRing = value; }
        protected Ring RightRing { get => rightRing; set => rightRing = value; }
        protected Shield Shield { get => shield; set => shield = value; }
        protected Belt Belt { get => belt; set => belt = value; }
        protected Boots Boots { get => boots; set => boots = value; }
    }
}