using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jeu
{
    public class Ring : Gear
    {
        public Ring(string p_name, int p_attack, int p_defense, int p_life) : base(p_name, p_attack, p_defense, p_life)
        {
        }
    }
}