using System.Collections.Generic;

namespace jeu
{
    internal class Inventory
    {
        protected Stuff _stuff;
        protected List<InventoryObjects> _objects;

        public Inventory()
        {
            _stuff = new Stuff();
            _objects = new List<InventoryObjects>();
        }

        public override string ToString()
        {
            return _stuff.ToString() + _objects.ToString();
        }
    }
}