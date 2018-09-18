using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jeu
{
    public class Weapon : Gear
    {
        protected int speed;

        public Weapon(string name, int attack, int defense, int life, string[] sprite, int description, int speed) : base(name, attack, defense, life, sprite, description)
        {
            this.speed = speed;
        }

        public int Speed { get => speed;}
    }
}