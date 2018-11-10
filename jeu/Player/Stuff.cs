using Graphics;
using System.Collections.Generic;

namespace jeu
{
    public class Stuff
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

        public int Attack
        {
            get
            {
                int totalAttack = 0;
                foreach (Gear gear in GetListOfGear())
                {
                    if (gear != null)
                    {
                        totalAttack += gear.Attack;
                    }
                }
                return totalAttack;
            }
        }

        public int Defense
        {
            get
            {
                int totalDefense = 0;
                foreach (Gear gear in GetListOfGear())
                {
                    if (gear != null)
                    {
                        totalDefense += gear.Defense;
                    }
                }
                return totalDefense;
            }
        }

        public int Life
        {
            get
            {
                int totalLife = 0;
                foreach (Gear gear in GetListOfGear())
                {
                    if (gear != null)
                    {
                        totalLife += gear.Life;
                    }
                }
                return totalLife;
            }
        }

        /**
         * Return the list of all the gears
         */
        public List<Gear> GetListOfGear()
        {
            return new List<Gear> {
                    weapon,
                    leftGlove,
                    rightGlove,
                    leftRing,
                    rightRing,
                    shield,
                    belt,
                    boots,
                };
        }

        public Weapon Weapon { get => weapon; set => weapon = value; }
        public Glove LeftGlove { get => leftGlove; set => leftGlove = value; }
        public Glove RightGlove { get => rightGlove; set => rightGlove = value; }
        public Ring LeftRing { get => leftRing; set => leftRing = value; }
        public Ring RightRing { get => rightRing; set => rightRing = value; }
        public Shield Shield { get => shield; set => shield = value; }
        public Belt Belt { get => belt; set => belt = value; }
        public Boots Boots { get => boots; set => boots = value; }

        public override string ToString()
        {
            string buffer = "";
            foreach (Gear gear in GetListOfGear())
            {
                if (gear != null)
                {
                    buffer += gear.ToString();
                }
            }
            return buffer;
        }
    }
}