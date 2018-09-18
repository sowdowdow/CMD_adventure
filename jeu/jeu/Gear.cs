using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jeu
{
    public class Gear
    {
        protected string _name;
        protected int _attack;
        protected int _defense;
        protected int _life;
        private string[] _sprite;
        private int _description;

        public Gear(string name, int attack, int defense, int life, string[] sprite, int description)
        {
            this._name = name;
            this._attack = attack;
            this._defense = defense;
            this._life = life;
            this._sprite = sprite;
            this._description = description;
        }

        public string Name { get => _name; }
        public int Attack { get => _attack; }
        public int Defense { get => _defense; }
        public int Life { get => _life; }
        public string[] Sprite { get => _sprite; }
        public int Description { get => _description; set => _description = value; }
    }
}