﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jeu
{
    public class Boots : Gear
    {
        public Boots(string name, int attack, int defense, int life, string[] sprite, int description) : base(name, attack, defense, life, sprite, description)
        {
        }
    }
}