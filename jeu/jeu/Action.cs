using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    public class Action
    {
        protected Sprite_box _sprites;
        protected GraphicTools _drawer;

        public Action()
        {
            _sprites = new Sprite_box();
            _drawer = new GraphicTools();

            //First: Clean the map
            _drawer.ClearInterface();
        }
    }
}