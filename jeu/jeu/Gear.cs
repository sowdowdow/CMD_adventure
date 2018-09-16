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

        public Gear(string p_name, int p_attack, int p_defense, int p_life)
        {
            name = p_name;
            attack = p_attack;
            defense = p_defense;
            life = p_life;
        }

        public string Name { get => name; }
        public int Attack { get => attack; }
        public int Defense { get => defense; }
        public int Life { get => life; }
    }
}