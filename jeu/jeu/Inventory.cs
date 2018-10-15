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
            Console.Write(Stats.Player.Inventory.ToString());
            Stats.Player.Inventory.Display();
        }
    }
}