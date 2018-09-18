using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jeu
{
    public class Gear
    {
        protected string name;
        protected int attack;
        protected int defense;
        protected int life;
        private string[] sprite;
        private int description;

        public Gear(string name, int attack, int defense, int life, string[] sprite, int description)
        {
            this.name = name;
            this.attack = attack;
            this.defense = defense;
            this.life = life;
            this.sprite = sprite;
            this.description = description;
        }

        public string Name { get => name; }
        public int Attack { get => attack; }
        public int Defense { get => defense; }
        public int Life { get => life; }
        public string[] Sprite { get => sprite; }
        public int Description { get => description; set => description = value; }
    }
}