using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jeu
{
    public class Belt : Gear
    {
        public Belt(string name, int attack, int defense, int life, string[] sprite, string description) : base(name, attack, defense, life, sprite, description)
        {
        }
    }
}