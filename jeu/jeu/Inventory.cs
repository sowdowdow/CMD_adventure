using Graphics;
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
            // This is the way to add a weapon to the player
            //Stats.Player.Inventory.Stuff.Weapon = new Weapon("Zorg", 1, 2, 3, Sprites._woodenStick, "desc", 5);
        }
    }
}