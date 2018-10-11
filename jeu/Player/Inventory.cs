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
    }
}