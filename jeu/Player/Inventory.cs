using Graphics;
using System;
using System.Collections.Generic;

namespace jeu
{
    public class Inventory
    {
        private Stuff _stuff;
        private List<InventoryObjects> _objects;

        public Inventory()
        {
            _stuff = new Stuff();
            _objects = new List<InventoryObjects>();
        }

        public override string ToString()
        {
            return _stuff.ToString() + "\n" + _objects.ToArray().ToString();
        }

        public void Display()
        {
            GraphicTools drawer = new GraphicTools();
            drawer.HorizontalLine(4, '*');
            drawer.VerticalLine(0, '*');
            drawer.HorizontalLine(Console.WindowHeight - 2, '*');
        }
    }
}