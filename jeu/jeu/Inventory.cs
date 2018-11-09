using jeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    public class Inventory : Action
    {
        public Inventory()
        {
            Stats.Player.Inventory.Display();
        }
    }
}