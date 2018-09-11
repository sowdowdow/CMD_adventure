using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    public class Action
    {
        protected Sprite_box sprites;
        protected GraphicTools drawer;

        public Action()
        {
            sprites = new Sprite_box();
            drawer = new GraphicTools();

            //First: Clean the map
            drawer.ClearInterface();
        }
    }
}