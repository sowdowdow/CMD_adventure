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
            Stats.Player.Inventory.Stuff.Weapon = new Weapon("Zorg", 1, 2, 3, Sprites._woodenStick, "desc", 5);
            Stats.Player.Inventory.Stuff.LeftGlove = new Glove("Leather Glove", 0, 0, 1, Sprites._leatherGlove, "Un gant en cuir, il ne sert à rien...");
        }
    }
}